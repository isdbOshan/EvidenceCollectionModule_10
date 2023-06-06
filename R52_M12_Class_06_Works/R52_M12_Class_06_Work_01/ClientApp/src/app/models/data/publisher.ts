import { Book } from "./book";

export interface Publisher {
  publisherId?:number;
  publisherName?:string;
  address?:string;
  book?:Book[];

}

