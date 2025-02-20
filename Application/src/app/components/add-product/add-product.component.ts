// add-product.component.ts
import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoryServiceService } from '../../services/category-service.service';
import { ApiProductsService } from '../../services/api-products.service';

interface ProductData {
  name: string;
  decription: string;
  price: string;
  CatId:string;
  photos: File[];
}
interface category{
  id:number;
  name:string;
}

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent implements OnInit {
  categoryList!:category[];
  product: ProductData = {
    name: '',
    decription: '',
    price: '',
    CatId: '',
    photos: []
  };
  constructor(private categoryservice:CategoryServiceService,private productservice:ApiProductsService){
    
  }
  ngOnInit(): void {
    //console.log("init0");
    this.getlistCategory();
  }
  getlistCategory(){
    //console.log("in");
    this.categoryservice.getListOfCategory().subscribe(
      {
        
        next:(res:any)=> 
          {
            this.categoryList = res.data
           // console.log(this.categoryList);
          },  
        error:(err)=>
        {
            
            alert(err)
        }
      }
    );
  }

  // businessTypes = [
  //   'Manufacturer',
  //   'Distributor',
  //   'Retailer',
  //   'Service Provider',
  //   'Wholesaler',
  //   'Other'
  // ];
 

  selectedFiles: File[] = [];
  previewUrls: string[] = [];

  onFileSelected(event: any): void {
    const files = event.target.files;
    if (files) {
      for (let i = 0; i < files.length; i++) {
        this.selectedFiles.push(files[i]);
        this.product.photos.push(files[i]);
        
        // Create preview for the image
        const reader = new FileReader();
        reader.onload = (e: any) => {
          this.previewUrls.push(e.target.result);
        };
        reader.readAsDataURL(files[i]);
      }
    }
  }

  removeImage(index: number): void {
    this.selectedFiles.splice(index, 1);
    this.previewUrls.splice(index, 1);
    this.product.photos.splice(index, 1);
  }

  onDragOver(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
  }

  onDrop(event: DragEvent): void {
    event.preventDefault();
    event.stopPropagation();
    
    if (event.dataTransfer && event.dataTransfer.files) {
      const files = event.dataTransfer.files;
      for (let i = 0; i < files.length; i++) {
        if (files[i].type.startsWith('image/')) {
          this.selectedFiles.push(files[i]);
          this.product.photos.push(files[i]);
          
          const reader = new FileReader();
          reader.onload = (e: any) => {
            this.previewUrls.push(e.target.result);
          };
          reader.readAsDataURL(files[i]);
        }
      }
    }
  }

  register(): void {
    console.log('Submitted product data:', this.product);
    // Here you would typically send the data to your backend
    // Reset form after submission if needed
    this.productservice.AddProduct(this.product).subscribe({

      next:(res:any)=> 
        {
          console.log("done");
        },  
      error:(err)=>
      {
          console.log(this.product);
          alert(err)
      }
    });
  }
}