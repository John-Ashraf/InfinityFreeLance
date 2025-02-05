import { Routes } from '@angular/router';
import { ContactusComponent } from './components/contactus/contactus.component';
import { DesignComponent } from './components/design/design.component';

export const routes: Routes = [
    {path:"contactus" , component:ContactusComponent},
    {path:"design" , component:DesignComponent},
];
