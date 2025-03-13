import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApiProductsService } from '../../services/api-products.service';
import { RouterLink } from '@angular/router';
import { Iproduct } from '../../models/iproduct';
import { Icategory } from '../../models/icategory';
import { CategoryServiceService } from '../../services/category-service.service';
import { TranslateService, TranslateModule } from '@ngx-translate/core';
import { TranslatePipe } from '@ngx-translate/core';

@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [CommonModule, RouterLink, TranslateModule, TranslatePipe], // Add TranslatePipe here
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomePageComponent {
  products: Iproduct[] = [];
  categories: Icategory[] = [];
  loading: boolean = false;
  currentLanguage: string = 'en'; // Default language

  constructor(
    private serviceProducts: ApiProductsService,
    private serviceCategory: CategoryServiceService,
    private translate: TranslateService
  ) {
    this.currentLanguage = this.translate.currentLang || 'en'; // Get current language
  }

  ngOnInit(): void {
    this.getProducts();
    this.getCategory();
  }

  getProducts() {
    this.loading = true;
    this.serviceProducts.getAllProducts().subscribe({
      next: (res: any) => {
        this.products = res.data.slice(0, 3);
        this.loading = false;
      },
      error: (err) => {
        this.loading = false;
        alert(err);
      }
    });
  }

  getCategory() {
    this.serviceCategory.getListOfCategory().subscribe({
      next: (res: any) => {
        this.categories = res.data;
      },
      error: (err) => {
        this.loading = false;
        alert(err);
      }
    });
  }

  getCategoryName(category: Icategory): string {
    return this.currentLanguage === 'ar' ? category.nameAr : category.name;
  }
}