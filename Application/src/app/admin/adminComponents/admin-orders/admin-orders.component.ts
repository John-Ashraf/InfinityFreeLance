import { Component, OnInit } from '@angular/core';
import { IorderAdmin } from '../../../models/iordersAdmin';
import { OrderServiceService } from '../../../services/order-service.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin-orders',
  imports: [CommonModule],
  templateUrl: './admin-orders.component.html',
  styleUrl: './admin-orders.component.css'
})
export class AdminOrdersComponent implements OnInit {
  orders: IorderAdmin[] = [];
  constructor(private orderService: OrderServiceService) { }
  ngOnInit(): void {
    this.getOrders();
  }
  getOrders() {
    this.orderService.getAllOrders().subscribe({
      next: (res: any) => {
        this.orders = res.data;
        console.log(res.data);
      },
      error: (err: any) => {
        alert(err.message)
      }
    })
  }
  deleteOrder(id:number){
    this.orderService.deleteOrder(id).subscribe({
      next:(res:any)=>{
        alert("delete successful")
      },
      error: (err: any) => {
        alert(err.message)
      }
    })
  }
}
