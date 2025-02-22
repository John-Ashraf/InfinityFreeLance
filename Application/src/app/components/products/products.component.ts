import { Component, OnInit } from '@angular/core';
import { ApiProductsService } from '../../services/api-products.service';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from "../spinner/spinner.component";
import { RouterLink } from '@angular/router';
import { Iproduct } from '../../models/iproduct';
import { Icategory } from '../../models/icategory';

@Component({
  selector: 'app-products',
  imports: [CommonModule, SpinnerComponent,RouterLink],
  templateUrl: './products.component.html',
  styleUrl: './products.component.css'
})
export class ProductsComponent implements OnInit {
  products:Iproduct[]=[];
  categories:Icategory[]=[];
  loading:boolean=false;
   constructor(private service:ApiProductsService){}
  ngOnInit(): void {
    this.getProducts();
    this. getCategories();
  }
  getProducts(){
    this.loading =true;
    this.service.getAllProducts().subscribe({
      next:(res:any)=> 
        {
          this.products = res.data
          this.loading =false
        },  
      error:(err)=>
      {
          this.loading =false
          alert(err)
      }

    })
  }

  getCategories(){
    this.loading =true
    this.service.getAllCategories().subscribe({
      next:(res:any)=>
      {
        this.loading =false
        this.categories = res.data
        // console.log(res)
      },
      error:(err)=>
      {
        this.loading =false
        alert(err)
      }

    })
  }

  filterCategories(event:any){
    let value =event.target.value;
    (value==="all")?this.getProducts():this.getSpecifcCategories(value);
    console.log(value);
  }

  getSpecifcCategories(keyword:string){
    this.loading =true
    this.service.getProductByCategories(keyword).subscribe({
      next:(res:any)=>
      {
        // console.log(res),
        this.loading =false
        this.products = res
      },
      error:(err)=>
      {
        this.loading =false
        alert(err)
      }
    })
  }
}
