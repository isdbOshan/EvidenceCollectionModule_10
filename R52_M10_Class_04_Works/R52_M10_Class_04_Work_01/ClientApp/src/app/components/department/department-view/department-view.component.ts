import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatTableDataSource } from '@angular/material/table';
import { Department } from 'src/app/models/data/department';
import { DepartmentService } from 'src/app/services/data/department.service';

@Component({
  selector: 'app-department-view',
  templateUrl: './department-view.component.html',
  styleUrls: ['./department-view.component.css']
})
export class DepartmentViewComponent {
department: Department= {};
// dataSource:MatTableDataSource

departmentForm: FormGroup= new FormGroup({
  departmentName: new FormControl('', [Validators.required, Validators.maxLength(50)])
});
constructor(private departmentSvc:DepartmentService){}
get f(){
  return this.departmentForm.controls;
}
save(){
  if(this.departmentForm.invalid) return;
  Object.assign(this.department, this.departmentForm.value);
  this.departmentSvc.post(this.department)
  .subscribe({
    next: r=>{
      this.department= {};
      this.departmentForm.reset({});
    },
    error:err=>{
      console.log(err);
    }
  })
}
}
