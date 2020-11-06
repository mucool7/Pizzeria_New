import { Product } from './Product.model';

export class Order {
  public OrderNo: number;
  public OrderNumber: string;
  public OrderDate: Date;
  public Products: Product[];
  public TotalPrice: number;
}
