import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { throwError } from 'rxjs';
import { Format } from 'src/app/environment/app-constant';
import { Book } from 'src/app/models/data/book';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { BookService } from 'src/app/services/data/book.service';
import { PublisherService } from 'src/app/services/data/publisher.service';

@Component({
  selector: 'app-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.css']
})
export class BookCreateComponent implements OnInit {
 
  book:Book = {};
  publishers:Publisher[] =[];
  formatOptions: { label: string, value: number }[] = [];
  bookForm:FormGroup = new FormGroup ({
    
    title: new FormControl('', Validators.required), 
    releaseDate: new FormControl(undefined, Validators.required),
    format: new FormControl(undefined, Validators.required),
    coverPrice: new FormControl(undefined, Validators.required),
    publisherId: new FormControl(undefined, Validators.required)
  });
  constructor(
    private bookService:BookService,
    private publisherService:PublisherService,
    private notifyService:NotifyService,
    private datePipe:DatePipe
  ){}
  get f(){
    return this.bookForm.controls;
  }
  save(){
      if(this.bookForm.invalid) return;
      Object.assign(this.book, this.bookForm.value);
      
      this.book.releaseDate = <string>this.datePipe.transform(this.book.releaseDate, "yyyy-MM-dd");
      //console.log(this.book)
      this.bookService.post(this.book)
      .subscribe({
        next: r=>{
          this.notifyService.notify("Book saved", "DISMISS");
          this.book={};
          this.bookForm.reset({});
          
        },
        error:err=>{
          this.notifyService.notify('Failed to save book', 'DISMISS');
          throwError(()=> err.message || err);
        }
      })
  }
  ngOnInit(): void {
    Object.keys(Format).filter(
      (type) => isNaN(<any>type) && type !== 'values'
    ).forEach((v: any, i) => {
      this.formatOptions.push({ label: v, value: Number(Format[v]) });
    });
    this.publisherService.get()
    .subscribe({
      next: r=>{
        this.publishers=r;
        
      },
      error:err=>{
        this.notifyService.notify('Failed to load pub;lishers', 'DISMISS');
        throwError(()=> err.message || err);
      }
    });
  }
}
