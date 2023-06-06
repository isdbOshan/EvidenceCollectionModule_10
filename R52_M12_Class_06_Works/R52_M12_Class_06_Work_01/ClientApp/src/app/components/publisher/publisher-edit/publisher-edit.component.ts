import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PublisherService } from 'src/app/services/publisher.service';
import {ActivatedRoute} from '@angular/router';

@Component({
  selector: 'app-publisher-edit',
  templateUrl: './publisher-edit.component.html',
  styleUrls: ['./publisher-edit.component.css']
})
export class PublisherEditComponent implements OnInit{
publisher: Publisher={};
publisherForm:FormGroup = new FormGroup({
  publisherName: new FormControl('', [Validators.required, Validators.maxLength(50)]),
  address: new FormControl('', [Validators.required, Validators.maxLength(50)]),
})
  activatedRoute: any;
constructor(
  private publisherSvc: PublisherService,
  private notifySvc: NotifyService
){}

get f(){
  return this.publisherForm.controls;
}
save(){
  if(this.publisherForm.invalid) return;
  Object.assign(this.publisher, this.publisherForm.value);
  this.publisherSvc.put(this.publisher)
  .subscribe({
    next:r=>{
      this.notifySvc.openSnackBar("Data Updated Successfully", "DISMISS");
    },
    error: err=>{
      this.notifySvc.openSnackBar("Failed to Update", "DISMISS")
    }
  })
}
ngOnInit(): void {

  let id:number = this.activatedRoute.snapshot.params['id'];
  this.publisherSvc.getById(id)
  .subscribe({
    next:r=>{
      console.log(r);
      this.publisher=r;
      this.publisherForm.patchValue(this.publisher)
    },
    error:err=>{
      console.log(err.message || err);
      this.notifySvc.openSnackBar("Failed to load Product", "DISMISS");
    }
  })
}


}
