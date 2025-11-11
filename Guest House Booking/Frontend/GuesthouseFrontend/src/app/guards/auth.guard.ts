import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  // Check 1: Is the user logged in?
  if (authService.isLoggedIn()) {
    
    // Check 2: Does the route require a specific role?
    const requiredRole = route.data['role'];
    const userRole = authService.getRole();

    if (requiredRole && userRole !== requiredRole) {
      // --- WRONG ROLE ---
      // The user is logged in, but their role is wrong.
      // (e.g., Admin trying to access a User page)

      // Redirect them to their *correct* dashboard.
      if (userRole === 'Admin') {
        return router.createUrlTree(['/admin-dashboard']);
      } else {
        return router.createUrlTree(['/my-bookings']);
      }
    }

    // --- SUCCESS ---
    // User is logged in AND has the correct role (or no role is required)
    return true;
  }

  // --- NOT LOGGED IN ---
  // Redirect them to the login page
  return router.createUrlTree(['/login']);
};