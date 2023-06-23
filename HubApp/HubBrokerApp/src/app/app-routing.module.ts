import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StudentRegistationComponent } from './student-registation/student-registation.component';
import { AdminSideComponent } from './admin-side/admin-side.component';
import { DocumentsFileComponent } from './documents-file/documents-file.component';

const routes: Routes = [
  {path:'',redirectTo:'/registration',pathMatch:'full'},
  { path:'registration',component:StudentRegistationComponent },
 {path:'admin-side',component:AdminSideComponent},
 {path:'documents-file',component:DocumentsFileComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
