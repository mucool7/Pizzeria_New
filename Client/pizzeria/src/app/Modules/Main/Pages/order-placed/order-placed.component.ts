import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-order-placed',
  templateUrl: './order-placed.component.html',
  styleUrls: ['./order-placed.component.css']
})
export class OrderPlacedComponent implements OnInit {

  constructor(private activatedRoute:ActivatedRoute) { }
  public OrderNumber:String

  ngOnInit(): void {

    this.activatedRoute.queryParams.subscribe(query=>{

      if(query.q){
        this.OrderNumber = query.q;
      }
    })

  }

}
