import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { BookingService, BookingDto } from 'src/app/services/booking.service';

import {
  ApexAxisChartSeries,
  ApexChart,
  ApexXAxis,
  ApexYAxis,
  ApexDataLabels,
  ApexTooltip,
  ApexStroke,
  ApexNonAxisChartSeries,
  ApexLegend,
  ApexPlotOptions,
  ApexFill
} from 'ng-apexcharts';

export type ChartOptions = {
  series: ApexAxisChartSeries | ApexNonAxisChartSeries;
  chart: ApexChart;
  xaxis: ApexXAxis;
  yaxis: ApexYAxis;
  stroke: ApexStroke;
  tooltip: ApexTooltip;
  dataLabels: ApexDataLabels;
  plotOptions: ApexPlotOptions;
  labels: string[];
  legend: ApexLegend;
  fill: ApexFill;
  colors: string[];
  states: any;
  grid: any;
};

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
})
export class AdminDashboardComponent implements OnInit {
  adminName: string = '';
  
  // Stats
  pendingBookingCount: number = 0;
  totalBookings: number = 0;
  approvedCount: number = 0;
  rejectedCount: number = 0;

  // Data Store
  allBookings: BookingDto[] = [];
  currentChartFilter: 'Day' | 'Week' | 'Month' = 'Day';

  // --- THIS IS THE FIX (1/2) ---
  isDataLoaded = false; // Controls when the charts render

  // Charts
  public trendChartOptions: Partial<ChartOptions> | any;
  public statusChartOptions: Partial<ChartOptions> | any;

  constructor(
    private authService: AuthService,
    private bookingService: BookingService
  ) {
    this.initCharts();
  }

  ngOnInit(): void {
    this.authService.user$.subscribe(user => {
      if (user) this.adminName = user.userName;
    });

    this.bookingService.getAllBookings().subscribe(bookings => {
      this.allBookings = bookings;
      this.processStats();
      this.updateChartFilter('Day');
      
      // --- THIS IS THE FIX (2/2) ---
      // Only show the charts AFTER data is processed
      this.isDataLoaded = true; 
    });
  }

  processStats() {
    this.totalBookings = this.allBookings.length;
    this.pendingBookingCount = this.allBookings.filter(b => b.status === 'Pending').length;
    this.approvedCount = this.allBookings.filter(b => b.status === 'Approved').length;
    this.rejectedCount = this.allBookings.filter(b => b.status === 'Rejected').length;

    this.statusChartOptions.series = [
      this.approvedCount, 
      this.pendingBookingCount, 
      this.rejectedCount
    ];
  }

  updateChartFilter(filter: 'Day' | 'Week' | 'Month') {
    this.currentChartFilter = filter;
    const groupedData: { [key: string]: number } = {};

    this.allBookings.forEach(b => {
      const date = new Date(b.createdDate);
      let key = '';

      if (filter === 'Day') {
        key = date.toLocaleDateString('en-US', { month: 'short', day: 'numeric' });
      } 
      else if (filter === 'Week') {
        const startOfWeek = new Date(date);
        startOfWeek.setDate(date.getDate() - date.getDay());
        const endOfWeek = new Date(startOfWeek);
        endOfWeek.setDate(startOfWeek.getDate() + 6);
        const startStr = startOfWeek.toLocaleDateString('en-US', { month: 'short', day: 'numeric' });
        const endStr = endOfWeek.toLocaleDateString('en-US', { month: 'short', day: 'numeric' });
        key = `${startStr} - ${endStr}`;
      } 
      else if (filter === 'Month') {
        key = date.toLocaleDateString('en-US', { month: 'long', year: 'numeric' });
      }

      groupedData[key] = (groupedData[key] || 0) + 1;
    });

    const categories = Object.keys(groupedData);
    const data = Object.values(groupedData);

    this.trendChartOptions.series = [{
      name: "Bookings",
      data: data
    }];
    this.trendChartOptions.xaxis = {
      categories: categories
    };
  }

  initCharts() {
    // Trend Chart
    this.trendChartOptions = {
      series: [{ name: "Bookings", data: [] }],
      chart: {
        type: "bar",
        height: 350,
        toolbar: { show: false },
        fontFamily: 'Inter, sans-serif'
      },
      plotOptions: {
        bar: {
          horizontal: false,
          columnWidth: '45%',
          borderRadius: 4
        },
      },
      colors: ['#3B82F6'], 
      dataLabels: { enabled: false },
      stroke: { show: true, width: 2, colors: ['transparent'] },
      xaxis: { 
        categories: [],
        axisBorder: { show: false },
        axisTicks: { show: false }
      },
      yaxis: {
        forceNiceScale: true,
        decimalsInFloat: 0,
        labels: {
          formatter: function (val: number) {
            return val ? Math.floor(val).toString() : "0";
          }
        }
      },
      grid: {
        show: true,
        borderColor: '#f3f4f6',
        strokeDashArray: 4,
      },
      tooltip: { theme: 'light' },
      states: {
        hover: { filter: { type: 'lighten', value: 0.05 } },
        active: { filter: { type: 'none' } }
      }
    };

    // Status Chart
    this.statusChartOptions = {
      series: [0, 0, 0],
      chart: {
        type: "donut",
        height: 350,
        fontFamily: 'Inter, sans-serif'
      },
      labels: ["Approved", "Pending", "Rejected"],
      colors: ['#10B981', '#EAB308', '#EF4444'],
      legend: { position: 'bottom' },
      dataLabels: { enabled: false },
      plotOptions: {
        pie: {
          donut: {
            size: '70%', 
            labels: {
              show: true,
              total: {
                show: true,
                label: 'Total',
                color: '#64748b',
                formatter: function (w: any) {
                  return w.globals.seriesTotals.reduce((a: any, b: any) => a + b, 0);
                }
              }
            }
          },
          expandOnClick: false 
        }
      },
      states: {
        hover: { filter: { type: 'none' } },
        active: { filter: { type: 'none' } }
      },
      tooltip: { enabled: true, theme: 'light' }
    };
  }
}