import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { AdminModel } from '../admin-model';
import { StudentServicesService } from '../student-services.service';
@Component({
  selector: 'app-admin-side',
  templateUrl: './admin-side.component.html',
  styleUrls: ['./admin-side.component.css']
})
export class AdminSideComponent {
  public dataSource = new MatTableDataSource<AdminModel>();

 // stu:AdminModel=new AdminModel();
  public displayedColumns = [
    'name',
    'emailAddress',
    'contectNo',
    'cV',
    'download',

  ];
   adminModel!: AdminModel[];

  constructor( public Services: StudentServicesService, private httpClient:HttpClient){}
  ngOnInit(): void {
    this.getallstudentList();
    //this.dataSource.sort = this.sort;
  }

  public getallstudentList() {
    this.Services.getApplicantList().subscribe((data) => {

    //  console.log("ddd",data)
this.adminModel=data
    console.log("Abbh",data);
    this.dataSource = new MatTableDataSource(this.adminModel);

    });
  };
// public getApplicationList(){
//   this.Services.getApplicantList().subscribe((data)=>{
//     this.adminModel=data;
//     this.dataSource=new MatTableDataSource(this.adminModel);
//   })
// }

public downloadfile(id:number,ContentType:string){
return this.httpClient.get("https://localhost:44329/api/StudentMasters/Download/${DocId}",{responseType:'blob'}).subscribe((result:Blob)=>{
  const blob=new Blob([result],{type:ContentType});
 // window.open(URL);
  console.log("Success")
})
}
}
