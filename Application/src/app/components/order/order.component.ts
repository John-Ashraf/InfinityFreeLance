import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Iorder } from '../../models/iorder';
import { OrderServiceService } from '../../services/order-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiProductsService } from '../../services/api-products.service';
import { IproductById } from '../../models/iproduct-by-id';

@Component({
  selector: 'app-order',
  imports: [CommonModule, FormsModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent implements OnInit {
  // Define the orderData object to hold form data
  orderData: Iorder = {
    ProductName: '',
    Quantity: 0,
    PhoneNumber: '',
    Size: '',
    Address: '',
    Message: '',
    Photos: [], // This will hold the selected files
    date: new Date().toISOString(), // Reset date
    price: 0, // Add this field
    totalPrice: 0, // Add this field
  };

  previewUrls: string[] = [];
  productDetails: any;
  id!: number;
  data!: IproductById;

  constructor(
    private orderService: OrderServiceService,
    private router: Router,
    private service: ApiProductsService,
    private route: ActivatedRoute,
  ) {
    this.id = Number(this.route.snapshot.paramMap.get("id"));
  }

  ngOnInit(): void {
    this.productDetails = this.router.getCurrentNavigation()?.extras.state?.['product'];
    if (this.productDetails) {
      this.orderData.ProductName = this.productDetails.name;
      this.orderData.price = this.productDetails.price;
      this.calculateTotalPrice();
      this.getProductDetails();
    }
  }

  getProductDetails() {
    this.service.getproductById(this.id).subscribe({
      next: (res: any) => {
        this.data = res.data;
      }
    });
  }

  // Handle file selection
  onFileSelected(event: any): void {
    const files = event.target.files;
    if (files) {
      this.handleFiles(files);
    }
  }

  // Handle drag-and-drop
  onDrop(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();

    if (event.dataTransfer && event.dataTransfer.files) {
      const files = event.dataTransfer.files;
      this.handleFiles(files);
    }
  }

  // Prevent default behavior for drag-over
  onDragOver(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
  }

  // Handle files (common logic for file selection and drag-and-drop)
  handleFiles(files: FileList): void {
    for (let i = 0; i < files.length; i++) {
      const file = files[i];
      if (file.type.startsWith('image/')) {
        this.orderData.Photos.push(file); // Add file to orderData.Photos

        // Create a preview URL for the image
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.previewUrls.push(e.target.result);
        };
        reader.readAsDataURL(file);
      }
    }
  }

  // Remove an image
  removeImage(index: number): void {
    this.orderData.Photos.splice(index, 1); // Remove file from orderData.Photos
    this.previewUrls.splice(index, 1); // Remove preview URL
  }
  calculateTotalPrice(){
    this.orderData.totalPrice = this.orderData.price * this.orderData.Quantity;
  }
  onQuantityChange(): void {
    this.calculateTotalPrice();
  }


  // Handle form submission
  order(form: NgForm): void {
    if (form.valid) {
      // Send the orderData object to the server
      this.orderService.postOrder(this.orderData).subscribe({
        next: (res: any) => {
          console.log('Order submitted successfully', res);
          // Reset the form and clear selected files
          // form.resetForm();
          // this.orderData = {
          //   ProductName: '',
          //   Quantity: 0,
          //   PhoneNumber: '',
          //   Size: '',
          //   Address: '',
          //   Message: '',
          //   Photos: []
          // };
          // this.previewUrls = [];
        },
        error: (err: any) => {
          console.log('Error submitting order', err);
        }
      });
    }
  }
}