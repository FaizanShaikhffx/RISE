import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeroPageComponent } from './components/home/home.component';
import { LoginComponent } from './components/login/login.component';
import { MyBookingsComponent } from './components/my-bookings/my-bookings.component';
import { authGuard } from './guards/auth.guard';
import { AdminDashboardComponent } from './components/admin-dashboard/admin-dashboard.component';
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
import { AuditLogComponent } from './components/admin/audit-log/audit-log.component';

const routes: Routes = [
  // --- Public Routes ---
  { path: '', component: HeroPageComponent },
  { path: 'login', component: LoginComponent },
  { path: 'forgot-password', component: ForgotPasswordComponent },
  { path: 'reset-password', component: ResetPasswordComponent },

  // --- Protected User Routes ---
  {
    path: 'my-bookings',
    component: MyBookingsComponent,
    canActivate: [authGuard],
    data: { role: 'User' }
  },
  {
    path: 'new-booking', 
    component: NewBookingComponent,
    canActivate: [authGuard],
    data: { role: 'User' }
  },

  // --- NEW Admin Layout Route ---
  // All admin pages will now live inside this "shell"
  {
    path: 'admin',
    component: AdminLayoutComponent,
    canActivate: [authGuard],
    data: { role: 'Admin' }, // This guard protects ALL child routes
    children: [
      { path: 'dashboard', component: AdminDashboardComponent },
      
      { path: 'guesthouses', component: GuesthouseListComponent },
      { path: 'guesthouse/new', component: GuesthouseFormComponent },
      { path: 'guesthouse/edit/:id', component: GuesthouseFormComponent },
      
      { path: 'rooms', component: RoomListComponent },
      { path: 'room/new', component: RoomFormComponent },
      { path: 'room/edit/:id', component: RoomFormComponent },
      
      { path: 'beds', component: BedListComponent },
      { path: 'bed/new', component: BedFormComponent },
      { path: 'bed/edit/:id', component: BedFormComponent },
      
      { path: 'bookings', component: BookingListComponent },
      { path: 'create-user', component: UserFormComponent },

      { path: 'audit-logs', component: AuditLogComponent }, // <-- 2. ADD THE ROUTE
      
      // { path: 'audit-logs', component: AuditLogComponent }, // Add this when ready
      
      // Redirects /admin to /admin/dashboard
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' } 
    ]
  },

  // --- Wildcard Route (MUST BE LAST) ---
  { path: '**', redirectTo: '' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }