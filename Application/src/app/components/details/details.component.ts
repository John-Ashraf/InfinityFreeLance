import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ApiProductsService } from '../../services/api-products.service';
import { CommonModule } from '@angular/common';
import { IproductById } from '../../models/iproduct-by-id';

@Component({
    selector: 'app-details',
    templateUrl: './details.component.html',
    styleUrls: ['./details.component.css'],
    standalone: true,
    imports: [CommonModule,RouterLink]

})
export class DetailsComponent implements OnInit {
    id!: number;
    data!:IproductById ;
    constructor(private service: ApiProductsService, private route: ActivatedRoute) {
        this.id = Number(this.route.snapshot.paramMap.get("id"));
        // console.log(this.id)
    }
    ngOnInit(): void {
        this.getProductDetails()
    }
    getProductDetails() {
        this.service.getproductById(this.id).subscribe({
            next: (res: any) => {
                this.data = res.data;
            }
        })
    }

  
}