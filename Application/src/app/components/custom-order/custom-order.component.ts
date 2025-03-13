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
  selector: 'app-custom-order',
  imports: [CommonModule, FormsModule],
  templateUrl: './custom-order.component.html',
  styleUrl: './custom-order.component.css'
})
export class CustomOrderComponent implements OnInit {
  orderData: Iorder = {
    ProductId: 10,
    Quantity: 0,
    Phone: '',
    smallSize: 'Small',
    mediumSize: 'Medium',
    largeSize: 'Large',
    xlSize: 'XL',
    xxlSize: 'XXL',
    smallQuantity: 0,
    mediumQuantity: 0,
    largeQuantity: 0,
    xlQuantity: 0,
    xllQuantity: 0,
    Address: '',
    Notes: '',
    PicsCustom: [], // This will hold the selected files
    date: new Date().toISOString(),
    price: 0,
    totalPrice: 0,
  };

  previewUrls: string[] = []; // Holds preview URLs for selected images
  // productDetails: any;
  // id!: number;
  // data!: IproductById;

  constructor(
    private orderService: OrderServiceService,
    private router: Router,
    private service: ApiProductsService,
    private route: ActivatedRoute,
  ) {
    // this.id = Number(this.route.snapshot.paramMap.get("id"));
  }

  ngOnInit(): void {
    // this.getProductDetails();
  }

  // getProductDetails() {
  //   this.service.getproductById(this.id).subscribe({
  //     next: (res: any) => {
  //       this.data = res.data;
  //       console.log(this.data);
  //     }
  //   });
  // }

  // Handle file selection
  onFileSelected(event: any): void {
    const files = event.target.files;
    if (files) {
      this.handleFiles(files);
    }
  }

  // Handle files (common logic for file selection and drag-and-drop)
  handleFiles(files: FileList): void {
    for (let i = 0; i < files.length; i++) {
      const file = files[i];
      if (file.type.startsWith('image/')) {
        this.orderData.PicsCustom.push(file); // Add file to orderData.PicsCustom

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
    this.orderData.PicsCustom.splice(index, 1); // Remove file from orderData.PicsCustom
    this.previewUrls.splice(index, 1); // Remove preview URL
  }

  calculateTotalPrice() {
    this.orderData.totalPrice = this.orderData.price * this.orderData.Quantity;
  }

  onQuantityChange(): void {
    this.calculateTotalPrice();
  }

  // Handle form submission
  order(): void {
    const totalQuantity = this.orderData.smallQuantity +
      this.orderData.mediumQuantity +
      this.orderData.largeQuantity +
      this.orderData.xlQuantity +
      this.orderData.xllQuantity;

    const sizeDetails =
      `${this.orderData.smallSize}: ${this.orderData.smallQuantity}, ` +
      `${this.orderData.mediumSize}: ${this.orderData.mediumQuantity}, ` +
      `${this.orderData.largeSize}: ${this.orderData.largeQuantity}, ` +
      `${this.orderData.xlSize}: ${this.orderData.xlQuantity}, ` +
      `${this.orderData.xxlSize}: ${this.orderData.xllQuantity}`;

    const formData = new FormData();
    formData.append('ProductId', this.orderData.ProductId.toString());
    formData.append('Phone', this.orderData.Phone);
    formData.append('Notes', this.orderData.Notes);
    formData.append('Quantity', totalQuantity.toString());
    formData.append('Address', this.orderData.Address);
    formData.append('size', sizeDetails);

    // Append each photo file
    this.orderData.PicsCustom.forEach((file, index) => {
      formData.append(`PicsCustom[${index}]`, file);
    });

    console.log(this.orderData);
    this.orderService.postOrder(formData).subscribe({
      next: (res: any) => {
        Swal.fire({
          title: "Order Added Successfully",
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