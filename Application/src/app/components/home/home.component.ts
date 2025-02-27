import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiProductsService } from '../../services/api-products.service';
import { RouterLink } from '@angular/router';
import { Iproduct } from '../../models/iproduct';


@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomePageComponent {
  products: Iproduct[] = [];
  categories: any[] = [];
  loading: boolean = false;
  constructor(private service: ApiProductsService) { }
  ngOnInit(): void {
    this.getProducts();
  }
  getProducts() {
    this.loading = true;
    this.service.getAllProducts().subscribe({
      next: (res: any) => {
        this.products = res.data.slice(0, 3);
        this.loading = false
      },
      error: (err) => {
        this.loading = false
        alert(err)
      }

    })
  }
}