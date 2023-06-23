import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatCardModule,} from '@angular/material/card';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatIconModule} from '@angular/material/icon';
import {MatListModule} from '@angular/material/list';
import { FormsModule } from '@angular/forms';
import {MatTabsModule} from '@angular/material/tabs';
import { StudentRegistationComponent } from './student-registation/student-registation.component';
import {MatFormFieldModule} from '@angular/material/form-field';

import { MatTableModule,MatTable } from '@angular/material/table'
import {ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatSelectModule } from '@angular/material/select';
import {NgFor} from '@angular/common';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { AdminSideComponent } from './admin-side/admin-side.component';

@NgModule({
  declarations: [
    AppComponent,
    StudentRegistationComponent,
    AdminSideComponent,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatTabsModule,
    FormsModule,
    MatSidenavModule,
    MatCardModule,
    MatFormFieldModule,
    MatTableModule ,
   ReactiveFormsModule,
    HttpClientModule,
    MatSelectModule,
    NgFor,
    MatProgressBarModule,
    MatButtonModule,
    MatInputModule,
],
  exports:[ MatTableModule ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
