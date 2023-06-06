import { Product } from "./product";

export interface Section {
    sectionId?:number;
    sectionName?:string;
    product?:Product[];
}
