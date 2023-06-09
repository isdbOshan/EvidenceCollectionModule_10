import { Manager } from "./manager";
import { Section } from "./section";

export interface Product {
    productId?:number;
    productName?:string;
    sectionId?:number;
    sections?:Section;
    managers?:Manager[];
}
