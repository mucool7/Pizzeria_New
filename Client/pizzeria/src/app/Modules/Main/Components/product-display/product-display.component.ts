import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Product } from '../../Models/Product.model';
import { HomeService } from '../../Providers/home.service';

@Component({
  selector: 'app-product-display',
  templateUrl: './product-display.component.html',
  styleUrls: ['./product-display.component.css']
})
export class ProductDisplayComponent implements OnInit {

  constructor(private api : HomeService,private router:Router) { }

  @Input() Product :Product = new Product();
  DummyImage:string ="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSNBpt8DYWWjND6wxBfv91oF5Uy281yOcQPBg&usqp=CAU";

  ngOnInit(): void {
  }

  AddToOrder(product:Product){

    let products:Product[]=[]
    products.push(product)
    this.api.AddToOrder(products).subscribe(res=>{

       this.router.navigate(['/orderplaced'],{queryParams:{q:res.OrderNumber}})
    },err=>{
      console.log(err)
    })
  }

  Customize(product:Product){

    this.router.navigate(['/custom'],{queryParams:{prno:product.ProductNo}})

  }

}
