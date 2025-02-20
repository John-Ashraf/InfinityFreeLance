import { Routes } from '@angular/router';
import { ContactusComponent } from './components/contactus/contactus.component';
import { DesignComponent } from './components/design/design.component';

import { AboutusComponent } from './components/aboutus/aboutus.component';
import { OrderComponent } from './components/order/order.component';
import { ProductsComponent } from './components/products/products.component';
import { DetailsComponent } from './components/details/details.component';
import { HomePageComponent } from './components/home/home.component';
import { AddProductComponent } from './components/add-product/add-product.component';

export const routes: Routes = [

    {path:"home" , component:HomePageComponent},
    {path:"contactus" , component:ContactusComponent},
    {path:"design" , component:DesignComponent},
    {path:'products' , component:ProductsComponent},
    {path:'details/:id' , component:DetailsComponent},
    {path:'aboutus' , component:AboutusComponent},
    {path:'order' , component:OrderComponent},
    {path:'addProducts' , component:AddProductComponent},
];
