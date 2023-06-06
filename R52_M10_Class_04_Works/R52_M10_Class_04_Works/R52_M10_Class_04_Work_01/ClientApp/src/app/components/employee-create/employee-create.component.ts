import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Department } from 'src/app/models/data/department';
import { Employee } from 'src/app/models/data/employee';
import { NotifyService } from 'src/app/services/common/notify.service';
import { EmployeeService } from 'src/app/services/data/employee.service';

@Component({
  selector: 'app-employee-create',
  templateUrl: './employee-create.component.html',
  styleUrls: ['./employee-create.component.css']
})
export class EmployeeCreateComponent {
employee:Employee={};
departments :Department[] =[];
gradeOption :{label:string, value:number}[] =[];
employeeForm :FormGroup = new FormGroup({
employeeName : new FormControl('', Validators.required),
grade: new FormControl(undefined, Validators.required),
designation: new FormControl('', Validators.required),
departmentId:new FormControl('', Validators.required)

});
constructor(
  private employeeSvc: EmployeeService,
  private notifySvc: NotifyService
){}
get f(){
  return this.employeeForm.controls;
}

save(){
  if(this.employeeForm.invalid) return;
  Object.assign(this.employee, this.employeeForm.valid);
  this.employeeSvc.post(this.employee)
  .subscribe({
    next:r=>{
      this.notifySvc.notify("Data Save Successfully", "Dismissed");
      this.employee={};
      this.employeeForm.reset({});
      this.employeeForm.markAsPristine();
      this.employeeForm.markAsUntouched();
    },
    error:err=>{
      console.log(err);
      this.notifySvc.notify("Failed to save data", "Dismissed");
    }
  })
}

}
