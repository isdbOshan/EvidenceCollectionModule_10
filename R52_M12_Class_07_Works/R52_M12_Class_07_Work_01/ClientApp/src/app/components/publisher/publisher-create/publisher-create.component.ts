import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { throwError } from 'rxjs';
import { Publisher } from 'src/app/models/data/publisher';
import { NotifyService } from 'src/app/services/common/notify.service';
import { PublisherService } from 'src/app/services/data/publisher.service';

@Component({
  selector: 'app-publisher-create',
  templateUrl: './publisher-create.component.html',
  styleUrls: ['./publisher-create.component.css']
})
export class PublisherCreateComponent {
 publisher:Publisher = {};
 publisherForm:FormGroup = new FormGroup({
  publisherName: new FormControl('', Validators.required),
  address: new FormControl('', Validators.required)
 });
 constructor(
  private publisherService:PublisherService,
  private notifyService:NotifyService
 ){}
 get f(){
  return this.publisherForm.controls;
 }
 save() {
  if(this.publisherForm.invalid) return;
  Object.assign(this.publisher, this.publisherForm.value);
  this.publisherService.post(this.publisher)
  .subscribe({
    next: r=>{
      this.notifyService.notify("Data saved", "DISMISS");
      this.publisher={};
      
      this.publisherForm.markAsPristine();
      this.publisherForm.markAsUntouched();
    },
    error:err=>{
      this.notifyService.notify('Failed to save publishers', 'DISMISS');
      throwError(()=> err.message || err);
    }
  })
 }
}
