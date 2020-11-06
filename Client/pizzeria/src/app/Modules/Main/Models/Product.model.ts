import { Part } from './Part';

export class Product {
  public ProductNo: number;
  public ProductType: number;
  public Parts: Part[]=[];
  public TotalPrice: number=0;
  public Name:string;
  public Image:string;
}
