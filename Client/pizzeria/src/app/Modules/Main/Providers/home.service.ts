import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpService } from 'src/app/Shared/Providers/http.service';
import { Order } from '../Models/Order';
import { Part } from '../Models/Part';
import { Product } from '../Models/Product.model';
import { SubPart } from '../Models/SubPart';

@Injectable({
  providedIn: 'root'
})
export class HomeService {

  constructor(private http:HttpService) { }

   GetCatlogs():Observable<Product[]>{

    return this.http.get<Product[]>("catlog/GetReadyProducts")
   }

   GetProduct(productNo):Observable<Product[]>{

    return this.http.get<Product[]>("catlog/GetProduct?prno="+productNo)
   }

   AddToOrder(products:Product[]):Observable<any>{

    return this.http.post<any>("order/AddToOrder",products)
   }

   GetPartWithSubParts():Observable<Part[]>{
     return this.http.get<Part[]>("Masters/GetParts")
   }

   GetParts():Observable<Part[]>{
    return this.http.get<Part[]>("Masters/GetParts")
  }

  GetSubParts():Observable<SubPart[]>{
    return this.http.get<SubPart[]>("Masters/GetSubParts")
  }
  GetOrders(str:string):Observable<Order[]>{
    return this.http.get<Order[]>("order/GetOrders");
  }
}
