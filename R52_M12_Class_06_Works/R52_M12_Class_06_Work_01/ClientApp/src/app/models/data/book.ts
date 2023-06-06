import { Format } from "../constants/app-constant";

export interface Book {
  bookId?:number;
  title?:string;
  releaseDate?:Date;
  format?:Format;
  coverPrice?:number;
  publisherId?:number;

}

