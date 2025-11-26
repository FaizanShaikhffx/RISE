import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common'; // <-- 1. IMPORT CommonModule
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import {HTTP_INTERCEPTORS, HttpClientModule} from "@angular/common/http";
import { LoginComponent } from './components/login/login.component'
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeroPageComponent, SafeHtmlPipe } from './components/home/home.component';
import { MyBookingsComponent } from './components/my-bookings/my-bookings.component';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';
import { GuesthouseListComponent } from './components/admin/guesthouse-list/guesthouse-list.component';
import { GuesthouseFormComponent } from './components/admin/guesthouse-form/guesthouse-form.component';
import { RoomListComponent } from './components/admin/room-list/room-list.component';
import { RoomFormComponent } from './components/admin/room-form/room-form.component';
import { BookingListComponent } from './components/admin/booking-list/booking-list.component';
import { BedListComponent } from './components/admin/bed-list/bed-list.component';
import { BedFormComponent } from './components/admin/bed-form/bed-form.component';
import { UserFormComponent } from './components/admin/user-form/user-form.component';
import { NewBookingComponent } from './components/new-booking/new-booking.component';
import { ForgotPasswordComponent } from './components/forgot-password/forgot-password.component';
import { ResetPasswordComponent } from './components/reset-password/reset-password.component';
import { AdminLayoutComponent } from './components/admin/admin-layout/admin-layout.component';
import { AdminSidebarComponent } from './components/admin/admin-sidebar/admin-sidebar.component';
import { AdminTopbarComponent } from './components/admin/admin-topbar/admin-topbar.component';
import { AuditLogComponent } from './components/admin/audit-log/audit-log.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { NgApexchartsModule } from 'ng-apexcharts';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeroPageComponent,
    SafeHtmlPipe,
    MyBookingsComponent,
    AdminDashboardComponent,
    NavbarComponent,
    GuesthouseListComponent,
    GuesthouseFormComponent,
    RoomListComponent,
    RoomFormComponent,
    BookingListComponent,
    BedListComponent,
    BedFormComponent,
    UserFormComponent,
    NewBookingComponent,
    ForgotPasswordComponent,
    ResetPasswordComponent,
    AdminLayoutComponent,
    AdminSidebarComponent,
    AdminTopbarComponent,
    AuditLogComponent,
    UserProfileComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule, 
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    NgApexchartsModule,
    BrowserAnimationsModule, 
    ToastrModule.forRoot({   
      timeOut: 3000,
      positionClass: 'toast-bottom-right', 
      preventDuplicates: true,
    })
    
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
