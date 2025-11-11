import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { StudentListComponent } from './student-list/student-list.component';
import { StudentDataComponent } from './student-data/student-data.component';
import { StudentServiceService } from './services/student-service.service';

@NgModule({
  declarations: [
    AppComponent,
    StudentListComponent,
    StudentDataComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [
    StudentServiceService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
