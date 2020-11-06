import { SubPart } from './SubPart';

export class Part {
  public PartNo: number;
  public Name: string;
  public IsImage: Boolean;
  public SubTypes: SubPart[]=[];
}
