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

const routes: Routes = [
  { path: '', component: HeroPageComponent },

  { path: 'login', component: LoginComponent },

  // --- Protected User Route ---
  {
    path: 'my-bookings',
    component: MyBookingsComponent,
    canActivate: [authGuard], // <-- Use the guard
  },

  // --- Protected Admin Route ---
 {
    path: 'admin-dashboard',
    component: AdminDashboardComponent,
    canActivate: [authGuard],
    data: { role: 'Admin' }
  },
  {
  path: 'admin/create-user',
  component: UserFormComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
  },
  {
    path: 'admin/guesthouses',
    component: GuesthouseListComponent,
    canActivate: [authGuard],
    data: { role: 'Admin' }
  },
  {
    path: 'admin/guesthouse/new', // Create
    component: GuesthouseFormComponent,
    canActivate: [authGuard],
    data: { role: 'Admin' }
  },
  {
    path: 'admin/guesthouse/edit/:id', // Edit
    component: GuesthouseFormComponent,
    canActivate: [authGuard],
    data: { role: 'Admin' }
  },
  {
  path: 'admin/rooms',
  component: RoomListComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
},
{
  path: 'admin/room/new',
  component: RoomFormComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
},
{
  path: 'admin/room/edit/:id',
  component: RoomFormComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
},
{
  path: 'admin/bookings',
  component: BookingListComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
},
{
  path: 'admin/beds',
  component: BedListComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
},
{
  path: 'admin/bed/new',
  component: BedFormComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
},
{
  path: 'admin/bed/edit/:id',
  component: BedFormComponent,
  canActivate: [authGuard],
  data: { role: 'Admin' }
},
{
  path: 'my-bookings',
  component: MyBookingsComponent,
  canActivate: [authGuard],
  data: { role: 'User' } // <-- Fix
},
{
  path: 'new-booking', 
  component: NewBookingComponent,
  canActivate: [authGuard],
  data: { role: 'User' } // <-- Fix
},
  // Redirect any other route to home
  { path: '**', redirectTo: '' },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
