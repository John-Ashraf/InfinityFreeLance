import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
interface ProductData {
  Name: string;
  Description: string;
  Price: string;
  Catid:string;
  Photos: File[];
}
interface category{
  id:number;
  name:string;
}

@Component({
  selector: 'app-order',
  imports: [CommonModule],
  templateUrl: './order.component.html',
  styleUrl: './order.component.css'
})
export class OrderComponent {
  categoryList!:category[];
  product: ProductData = {
    Name: '',
    Description: '',
    Price: '',
    Catid: '',
    Photos: []
  };
  selectedFiles: File[] = [];
  previewUrls: string[] = [];
  onFileSelected(event: any): void {
    const files = event.target.files;
    if (files) {
      for (let i = 0; i < files.length; i++) {
        this.selectedFiles.push(files[i]);
        this.product.Photos.push(files[i]);
        
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
    this.product.Photos.splice(index, 1);
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
          this.product.Photos.push(files[i]);
          
          const reader = new FileReader();
          reader.onload = (e: any) => {
            this.previewUrls.push(e.target.result);
          };
          reader.readAsDataURL(files[i]);
        }
      }
    }
  }
}
