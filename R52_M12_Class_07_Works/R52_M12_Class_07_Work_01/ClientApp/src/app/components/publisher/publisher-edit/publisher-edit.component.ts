import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { throwError } from 'rxjs';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PublisherService } from 'src/app/services/data/publisher.service';

@Component({
  selector: 'app-publisher-edit',
  templateUrl: './publisher-edit.component.html',
  styleUrls: ['./publisher-edit.component.css']
})
export class PublisherEditComponent implements OnInit {
  publisher:Publisher = {};
  publisherForm:FormGroup = new FormGroup({
   publisherName: new FormControl('', Validators.required),
   address: new FormControl('', Validators.required)
  });
  constructor(
   private publisherService:PublisherService,
   private notifyService:NotifyService,
   private activateRoute:ActivatedRoute
  ){}
  
  get f(){
   return this.publisherForm.controls;
  }
  save() {
   if(this.publisherForm.invalid) return;
   Object.assign(this.publisher, this.publisherForm.value);
   this.publisherService.put(this.publisher)
   .subscribe({
    next:r=>{
      this.notifyService.notify("Data Updated", "DISMISS");

    },
      error:err=>{
        this.notifyService.notify("Failed to save publisher", "DISMISS");
        throwError(()=> err.message || err);
      }
   })
  }
  ngOnInit(): void {
    let id:number = this.activateRoute.snapshot.params['id'];
    this.publisherService.getById(id)
    .subscribe({
      next:r=>{
        this.publisher = r;
        this.publisherForm.patchValue(this.publisher);
      },
      error:err=>{
        this.notifyService.notify("Failed to load publisher", "DISMISS");
        throwError(()=> err.message || err);
      }

    });
  }
}
