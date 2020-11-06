import { Component, OnInit } from '@angular/core';
import { Product } from '../../Models/Product.model';
import { HomeService } from '../../Providers/home.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private api:HomeService) { }

  Products:Product[]=[]

  ngOnInit(): void {

    this.api.GetCatlogs().subscribe(products=>{
      this.Products =products;

      console.log(this.Products);
    })


  }

}
