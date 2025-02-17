// import { Component, OnInit } from '@angular/core';
// import { Router } from '@angular/router';
// import { Iproduct } from '../../models/iproduct';
// import { ApiProductsService } from '../../services/api-products.service';
// import { CommonModule } from '@angular/common';

// @Component({
//     selector: 'app-blogs',
//     templateUrl: './blogs.component.html',
//     styleUrls: ['./blogs.component.css'],
//     standalone: true,
//     imports: [CommonModule]
// })
// export class BlogsComponent implements OnInit {
//     products: Iproduct[] = [] as Iproduct[];
//     // products=[{"name":'peter'}];

//     constructor(private apiService: ApiProductsService, private router: Router) { }

//     ngOnInit(): void {
//         this.apiService.getAllProducts().subscribe({
//             next: (data: Iproduct[]) => this.products = data,
//             error: (err: any) => console.log(err)
//         });
//     }

//     navigateToDetails(id: number): void {
//         this.router.navigate(['/details', id]);
//     }
// }