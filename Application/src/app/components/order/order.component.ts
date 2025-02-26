import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { Iorder } from '../../models/iorder';
import { OrderServiceService } from '../../services/order-service.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ApiProductsService } from '../../services/api-products.service';
import { IproductById } from '../../models/iproduct-by-id';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-order',
  imports: [CommonModule, FormsModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent implements OnInit {
  // Define the orderData object to hold form data
  orderData: Iorder = {
    ProductId: 0,
    Quantity: 0,
    Phone: '',
    size: 'Small ',
    smallSize: 'Small ',
    mediumSize: 'Medium ',
    largeSize: 'Large',
    xlSize: 'XL',
    xxlSize: 'XXL',
    Address: '',
    Notes: '',
    PicsCustom: [], // This will hold the selected files
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
    this.getProductDetails();
  }

  getProductDetails() {
    this.service.getproductById(this.id).subscribe({
      next: (res: any) => {
        this.data = res.data;
        console.log(this.data);
      }
    });
  }

  // Handle file selection
  // onFileSelected(event: any): void {
  //   const files = event.target.files;
  //   if (files) {
  //     this.handleFiles(files);
  //   }
  // }

  // // Handle drag-and-drop
  // onDrop(event: DragEvent): void {
  //   event.preventDefault();
  //   event.stopPropagation();

  //   if (event.dataTransfer && event.dataTransfer.files) {
  //     const files = event.dataTransfer.files;
  //     this.handleFiles(files);
  //   }
  // }

  // // Prevent default behavior for drag-over
  // onDragOver(event: DragEvent): void {
  //   event.preventDefault();
  //   event.stopPropagation();
  // }

  // // Handle files (common logic for file selection and drag-and-drop)
  // handleFiles(files: FileList): void {
  //   for (let i = 0; i < files.length; i++) {
  //     const file = files[i];
  //     if (file.type.startsWith('image/')) {
  //       this.orderData.PicsCustom.push(file); // Add file to orderData.Photos

  //       // Create a preview URL for the image
  //       const reader = new FileReader();
  //       reader.onload = (e: any) => {
  //         this.previewUrls.push(e.target.result);
  //       };
  //       reader.readAsDataURL(file);
  //     }
  //   }
  // }

  // Remove an image
  // removeImage(index: number): void {
  //   this.orderData.PicsCustom.splice(index, 1); // Remove file from orderData.Photos
  //   this.previewUrls.splice(index, 1); // Remove preview URL
  // }
  calculateTotalPrice(){
    this.orderData.totalPrice = this.orderData.price * this.orderData.Quantity;
  }
  onQuantityChange(): void {
    this.calculateTotalPrice();
  }


  // Handle form submission
  order(): void {
    console.log("inorder")
    const formData = new FormData();
    formData.append('ProductId', this.data.id.toString());
    formData.append('Phone', this.orderData.Phone);
    formData.append('Notes', this.orderData.Notes);
    formData.append('Quantity', this.orderData.Quantity.toString());
    formData.append('Address', this.orderData.Address);
    formData.append('size', this.orderData.size+": "+this.orderData.Quantity.toString());
    this.orderData.PicsCustom.forEach((file) => {
      formData.append('PicsCustom', file, file.name);
    });
    console.log(formData);
    this.orderService.postOrder(formData).subscribe({
      next: (res: any) => {
        console.log('Order submitted successfully', res);
        Swal.fire({
                    title: "Order Added Successful",
                    icon: "success",
                    draggable: true
                  });
      },
      error: (err: any) => {
        console.log('Error submitting order', err);
        Swal.fire({
                    icon: "error",
                    title: `${err.message}`,
                    text: "Something went wrong!",
                  });
      }
    });
  }
}