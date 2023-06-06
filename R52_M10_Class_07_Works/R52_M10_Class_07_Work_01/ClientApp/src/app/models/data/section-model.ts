import { ProductModel } from "./product-model";


export interface SectionModel {
  sectionId?:number;
  sectionName?:string;
  products?:ProductModel[];

}
