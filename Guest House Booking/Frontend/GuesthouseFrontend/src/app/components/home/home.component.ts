import { Component, HostListener, OnInit, Pipe, PipeTransform } from '@angular/core';
import { DomSanitizer, SafeHtml } from '@angular/platform-browser';

// A custom pipe to render SVG strings safely
@Pipe({ name: 'safeHtml' })
export class SafeHtmlPipe implements PipeTransform {
  constructor(private sanitizer: DomSanitizer) {}
  transform(value: string): SafeHtml {
    return this.sanitizer.bypassSecurityTrustHtml(value);
  }
}

@Component({
  selector: 'app-hero-page',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HeroPageComponent implements OnInit {
  // --- State for Header ---
  isOpen = false;
  isScrolled = false;

  // --- State for Hero Stats ---
  stats = [
    { number: '10+', label: 'Guesthouses' },
    { number: '1K+', label: 'Approved Bookings' }, // 
    { number: '24/7', label: 'Support' },
  ];

  // --- State for Search Bar ---
  searchQuery = {
    guesthouse: '',
    checkIn: '',
    guests: '2',
  };

  // --- State for Featured Guesthouses ---
  destinations = [
    {
      id: 1,
      name: 'Sunrise Villa',
      image: 'https://images.unsplash.com/photo-1566073771259-6a8506099945?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60',
      price: '$50/night',
      rating: 4.9,
      reviews: 328,
      description: 'A beautiful villa with a pool and modern amenities.',
    },
    {
      id: 2,
      name: 'The Downtown Lodge',
      image: 'https://images.unsplash.com/photo-1520250497591-112f2f40a3f4?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60',
      price: '$45/night',
      rating: 4.8,
      reviews: 456,
      description: 'Perfect for city explorers, right in the heart of downtown.',
    },
    {
      id: 3,
      name: 'Lakeview Retreat',
      image: 'https://images.unsplash.com/photo-1582719508461-905c673771fd?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60',
      price: '$60/night',
      rating: 4.9,
      reviews: 512,
      description: 'Stunning views and a peaceful environment by the lake.',
    },
    {
      id: 4,
      name: 'City Center Inn',
      image: 'https://images.unsplash.com/photo-1540541338287-41700207ced6?ixlib=rb-4.0.3&auto=format&fit=crop&w=800&q=60',
      price: '$40/night',
      rating: 4.7,
      reviews: 389,
      description: 'Affordable, clean, and convenient for short stays.',
    },
  ];

  // --- State for Features ---
  // Icon SVGs (as strings)
  shieldIcon =
    '<path d="M12 22s8-4 8-10V5l-8-3-8 3v7c0 6 8 10 8 10z"></path>';
  bedIcon =
    '<path d="M2 4v16"></path><path d="M2 10h20"></path><path d="M13 18v-5h5v5"></path><path d="M6 18v-5h5v5"></path><path d="M4 10V6a2 2 0 0 1 2-2h12a2 2 0 0 1 2 2v4"></path>';
  historyIcon =
    '<path d="M3 3v18h18"></path><path d="M21 17.5v-1.5h-5.5l-2.5 2.5-2.5-5-3 3.5"></path>';
  mailIcon =
    '<rect width="20" height="16" x="2" y="4" rx="2"></rect><path d="m22 7-8.97 5.7a1.94 1.94 0 0 1-2.06 0L2 7"></path>';

  features = [
    {
      icon: this.shieldIcon,
      title: 'Admin Approval', // 
      description:
        'All bookings are confirmed by an admin, ensuring no double-bookings or conflicts. ',
    },
    {
      icon: this.bedIcon,
      title: 'Bed-Level Availability', // 
      description:
        'Check availability for specific beds in each room for your selected dates. ',
    },
    {
      icon: this.historyIcon,
      title: 'Booking History', // 
      description:
        'Easily view your past and current booking requests and their approval status. ',
    },
    {
      icon: this.mailIcon,
      title: 'Instant Notifications', // 
      description:
        'Receive email notifications as soon as your booking request is submitted and approved. ',
      
    },
  ];

  constructor() {}

  ngOnInit(): void {}

  // --- HostListener for Header scroll detection ---
  @HostListener('window:scroll', [])
  onWindowScroll() {
    this.isScrolled = window.scrollY > 10;
  }
}