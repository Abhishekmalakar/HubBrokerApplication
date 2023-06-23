import { Injectable } from '@angular/core';
import { HttpClient, HttpRequest } from '@angular/common/http';
import { retry, catchError, } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { StudentModel } from './student-model';
import {  HttpEvent, HttpErrorResponse,
         HttpEventType } from  '@angular/common/http';
import { FileUpload } from './file-upload';
import { map } from  'rxjs/operators';
import { AdminModel } from './admin-model';
import { DocumnetList } from './documnet-list';
import { Documents } from './documents';

@Injectable({
  providedIn: 'root'
})





export class StudentServicesService {

  private REST_API_SERVER = "https://localhost:44329/api";
  constructor(private httpClient:HttpClient) { }




  public postEmployee(employee : StudentModel){
    return this.httpClient.post(this.REST_API_SERVER +"/StudentMasters/postStudentData",employee);
   }


   public GetallCompanyMaster(){
    return this.httpClient.get(this.REST_API_SERVER +"/StudentMasters/allVacancy");
  }

public getStudentList(){
  return this.httpClient.get<AdminModel[]>(this.REST_API_SERVER +"/StudentMasters/getstudentList");
}

public getApplicantList(){
  return this.httpClient.get<AdminModel[]>(this.REST_API_SERVER +"/StudentMasters/getapplicationList")
}
public upload(files:FormData){
  return this.httpClient.post<any>(this.REST_API_SERVER +"/StudentMasters/uploaddoc",files)
}

public download(DocId:number){
  return this.httpClient.get(this.REST_API_SERVER +"/StudentMasters/Download" + DocId);
}
}


