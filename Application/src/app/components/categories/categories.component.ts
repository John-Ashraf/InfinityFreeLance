import { Component, OnInit } from '@angular/core';
import { ApiProductsService } from '../../services/api-products.service';
import { CommonModule } from '@angular/common';
import { SpinnerComponent } from "../spinner/spinner.component";
import { RouterLink } from '@angular/router';
import { Iproduct } from '../../models/iproduct';
import { Icategory } from '../../models/icategory';
import { TranslateModule, TranslatePipe, TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-categories',
  imports: [CommonModule, SpinnerComponent, RouterLink, TranslateModule,TranslatePipe],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent {
  products: Iproduct[] = [];
  categories: Icategory[] = [];
  loading: boolean = false;
  selectedCategory: number = -1; // Default to "All"
  showProducts: boolean[] = []; // Controls the animation state of each card
  currentLanguage: string = 'en'; // Default language


  constructor(private service: ApiProductsService, private translate: TranslateService) {
    this.currentLanguage = this.translate.currentLang || 'en'; // Get current language
  }

  ngOnInit(): void {
    this.getProducts();
    this.getCategories();
  }

  getProducts(): void {
    this.loading = true;
    this.products = [];
    this.showProducts = [];

    this.service.getAllProducts().subscribe({
      next: (res: any) => {
        this.loading = false;
        this.products = res.data;
        this.triggerAnimation();
      },
      error: (err) => {
        this.loading = false;
        alert(err);
      }
    });
  }

  getCategories(): void {
    this.loading = true;
    this.service.getAllCategories().subscribe({
      next: (res: any) => {
        this.loading = false;
        this.categories = res.data;
      },
      error: (err) => {
        this.loading = false;
        alert(err);
      }
    });
  }

  filterByCategory(categoryId: number): void {
    this.selectedCategory = categoryId;
    this.showProducts = [];
    if (categoryId === -1) {
      this.getProducts();
    } else {
      this.getSpecifcCategories(categoryId);
    }
  }

  getSpecifcCategories(categoryId: number): void {
    this.loading = true;
    this.products = [];
    this.showProducts = [];

    this.service.getProductByCategories(categoryId).subscribe({
      next: (res: any) => {
        this.loading = false;
        this.products = res.data;
        this.triggerAnimation();
      },
      error: (err) => {
        this.loading = false;
        alert(err);
      }
    });
  }

  triggerAnimation(): void {
    this.products.forEach((_, index) => {
      setTimeout(() => {
        this.showProducts[index] = true;
      }, index * 200); // Delay each card by 200ms
    });
  }

  getCategoryName(category: Icategory): string {
    return this.currentLanguage === 'ar' ? category.nameAr : category.name;
  }
}
