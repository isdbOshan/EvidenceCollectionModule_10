import { Format } from "src/app/environment/app-constant";

export interface Book {
    bookId?:number;
  title?:string;
  releaseDate?:Date|string;
  format?:Format;
  coverPrice?:number;
  publisherId?:number;
}
