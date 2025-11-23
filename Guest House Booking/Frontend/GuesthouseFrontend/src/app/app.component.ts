import { Component } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router'; // 1. Import Router
import { filter } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  title = 'GuesthouseFrontend';
  isAdminRoute = false; // 2. Add this property

  constructor(private router: Router) { // 3. Inject Router
    
    // 4. Add this logic to the constructor
    this.router.events.pipe(
      filter((event): event is NavigationEnd => event instanceof NavigationEnd)
    ).subscribe((event: NavigationEnd) => {
      // Check if the current URL starts with /admin
      this.isAdminRoute = event.urlAfterRedirects.startsWith('/admin');
    });
  }
}