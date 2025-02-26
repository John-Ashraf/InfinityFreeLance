// admin.routes.ts
import { Routes } from '@angular/router';
import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { AdminProductsComponent } from './admin-products/admin-products.component';
import { AdminLoginComponent } from './admin-login/admin-login.component';
import { AddProductComponent } from './add-product/add-product.component';
// import { AdminGuard } from '../guards/admin.guard'; // Import the guard

export const adminRoutes: Routes = [
  {
    path: 'dashboard',
    component: AdminDashboardComponent,
    // canActivate: [AdminGuard] // Protect this route
  },
  {
    path: 'products',
    component: AdminProductsComponent,
    // canActivate: [AdminGuard] // Protect this route
  },
  {
    path: 'login',
    component: AdminLoginComponent
  },
  { path: 'addProducts', component: AddProductComponent },
  {
    path: '',
    redirectTo: 'dashboard',
    pathMatch: 'full' // Default route
  },

];