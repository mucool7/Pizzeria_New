import { query } from '@angular/animations';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { Part } from '../../Models/Part';
import { Product } from '../../Models/Product.model';
import { SubPart } from '../../Models/SubPart';
import { HomeService } from '../../Providers/home.service';

@Component({
  selector: 'app-customize',
  templateUrl: './customize.component.html',
  styleUrls: ['./customize.component.css']
})
export class CustomizeComponent implements OnInit {

  constructor(private api:HomeService,private activatedRoute:ActivatedRoute,private router:Router) { }

  Parts:Part[]=[]
  Product:Product = new Product();
  SelectedSubType
  SubParts:SubPart[]=[]
  CustomizationSelections:string;
  DummyImage ="https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSNBpt8DYWWjND6wxBfv91oF5Uy281yOcQPBg&usqp=CAU"

  FormArry= new FormArray([]);
  Form = new FormGroup({
    Name: new FormControl(null,Validators.required),
    ProductNo:new FormControl(null),
    ProductType:new FormControl(null),
    Parts : this.FormArry,
    TotalPrice :new FormControl(0)

  })

  SelectedPart;

  ngOnInit(): void {

    let req = forkJoin([
      this.api.GetParts(),
      this.api.GetSubParts()
    ])

    req.subscribe(response=>{
      this.Parts = response[0];
      this.SelectedPart = this.Parts[0].PartNo;
      this.SubParts = response[1];

      return;
    })

    this.activatedRoute.queryParams.subscribe(res=>{
      if(res.prno){
        this.api.GetProduct(res.prno).subscribe(product=>{
          this.Product = product[0];
        })
      }
    })


  }

  IsSelected(partNo:number,SubPartNo:number){

    let selectedPart = this.Product.Parts.filter(x=>x.PartNo == partNo);
    if(selectedPart.length>0){

      return selectedPart[0].SubTypes.filter(x=>x.SubPartNo == SubPartNo).length>0
    }

  }

  validate():string{
    let msg ="";

    if(!this.Product.Name){
      msg="Please enter the pizza name."
    }
    else{

      this.Parts.forEach(part=>{

        if(!msg && this.Product.Parts.filter(x=>x.PartNo == part.PartNo).length<=0){
          msg="Choose an option for "+part.Name+" "
          this.SelectedPart = part.PartNo;
        }
      })


    }


    return msg;
  }

  AddToOrder(){

    let Products:Product[]=[];
    this.Product.ProductType=3;
    Products.push(this.Product);

    let val = this.validate();

    if(val){
      alert(val);
      return
    }
    this.api.AddToOrder(Products).subscribe(res=>{


      this.router.navigate(['/orderplaced'],{queryParams:{q:res.OrderNumber}})
    })
  }

  updateProduct(partNo:number,SubPartNo:number){

    this.Product.Parts = this.Product.Parts.filter(x=>x.PartNo != partNo);
    let part = this.Parts.filter(x=>x.PartNo == partNo);

    part.forEach(p=>{
      p.SubTypes = this.SubParts.filter(x=>x.SubPartNo == SubPartNo && x.PartNo ==partNo);
    })


    this.Product.Parts=[...this.Product.Parts,...part];

    let TotalParts = this.Parts.length;
    setTimeout(()=>{
    this.SelectedPart = this.Parts.find(x=>x.PartNo== partNo+1 &&  (x.PartNo)<=TotalParts).PartNo;

    },100)

    this.UpdatePrice();
  }


  // UpdateProduct(){

  //   this._SetProduct();




  // }

  // PlaceOrder(){

  //   console.log(this.Product)
  // }

  private UpdatePrice(){
    this.Product.TotalPrice=0;
     this.Product.Parts.forEach((x:any)=>{

      //y.SubTypes = x.SubTypes.filter(sub=> x.SelectedSub && sub.SubPartNo == x.SelectedSub);
      this.Product.TotalPrice += x.SubTypes.reduce((a,x)=>a+=Number(x.Price),0)
      //return y;
    })

    this.CustomizationSelections = this.Product.Parts.map(x=>{

      return x.SubTypes[0]?.Name;
    }).join(' | ')
  }

  GetSelectedSubPart(partNo:number):SubPart{

    try{
    return this.Product.Parts.filter(x=>x.PartNo ==partNo)[0].SubTypes[0];

    }
    catch(ex){
      return new SubPart();
    }
  }




}
