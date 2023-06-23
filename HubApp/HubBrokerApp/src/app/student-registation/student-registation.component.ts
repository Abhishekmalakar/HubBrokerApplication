import { Component, ElementRef, ViewChild } from '@angular/core';
import Swal from 'sweetalert2';
import {NgFor} from '@angular/common';



import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { StudentModel } from '../student-model';
import { StudentServicesService } from '../student-services.service';
import { CompanyModel } from '../company-model';
import { HttpErrorResponse,HttpProgressEvent, HttpEventType, HttpRequest, HttpResponse } from '@angular/common/http';
import { of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Component({
  selector: 'app-student-registation',
  templateUrl: './student-registation.component.html',
  styleUrls: ['./student-registation.component.css']
})
export class StudentRegistationComponent {

  form!: FormGroup;
  companies!: CompanyModel[];
  emp: StudentModel = new StudentModel();
  selectedFiles:File[]|undefined;
  empFormGroup: FormGroup = new FormGroup({
    firstName: new FormControl,
    lastName: new FormControl,
    emailAddress: new FormControl,
    mob: new FormControl,
    currentAddress:new FormControl,
    permanentAddress:new FormControl,
    jobId:new FormControl,
    docId:new FormControl,
    fileUpload:new FormControl

  });
  @ViewChild('UploadFileInput')
  uploadFileInput!: ElementRef;
  docFile = 'Select File';
  constructor(
    private fb: FormBuilder,private services:StudentServicesService){}


    ngOnInit() {
     this. SaveEmployeeDetails();
     this.GetallCompanyMaster();
    }




  SaveEmployeeDetails():void{


    if(this.docFile!=null){


    }
    this.services.postEmployee(this.emp).subscribe((data:any)=>{

       Swal.fire({
        title: 'Success',
        text: 'You Have  Successfull Registered',
        icon: 'success',
        confirmButtonText: 'Success',

       })
       });
    }

    public GetallCompanyMaster = () => {
      this.services.GetallCompanyMaster().subscribe((data) => {
        // console.log(data)
        this.companies = data as CompanyModel[];
        // console.log(this.companies);
      });
    };

    handleFileInput(event:any) :void{
      this.selectedFiles=event.currentTarget.files
      }


      onSubmit():void{
        if(this.selectedFiles && this.selectedFiles.length>0){
          const formData = new FormData();
          for(let file of this.selectedFiles){
            formData.append('files',file);

          }
          this.services.upload(formData).subscribe(data=>{
            console.log(data);
          });
        }
    }

}



