import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PublisherService } from 'src/app/services/publisher.service';

@Component({
  selector: 'app-publisher-create',
  templateUrl: './publisher-create.component.html',
  styleUrls: ['./publisher-create.component.css']
})
export class PublisherCreateComponent {
// publisher: Publisher={};
// publisherForm : FormGroup=new FormGroup({
//   publisherName : new FormControl('', [Validators.required,Validators.maxLength(50)]),
//   address: new FormControl('', [Validators.required,Validators.maxLength(50)])
// });
publisher:Publisher = {};
publisherForm:FormGroup = new FormGroup({
  publisherName:new FormControl('', [Validators.required, Validators.maxLength(50)]),
  address:new FormControl('', [Validators.required, Validators.maxLength(50)])
  });
constructor(
  private publisherSvc :PublisherService,
  private notifySvc: NotifyService
){}

get f(){
  return this.publisherForm.controls;
}
save()
{
  if(this.publisherForm.invalid) return;
  Object.assign(this.publisher, this.publisherForm.value);
  console.log(this.publisher);
  this.publisherSvc.post(this.publisher)
  .subscribe({
    next:r=>{
      this.notifySvc.notify("Data Saved", 'Dismissed');
      this.publisher={};
      this.publisherForm.reset({});
      this.publisherForm.markAsPristine();
      this.publisherForm.markAsUntouched();
    },
    error:err=>{
      console.log(err);
      this.notifySvc.notify("Failed to save data", 'Dismissed');
    }
  })
}}
