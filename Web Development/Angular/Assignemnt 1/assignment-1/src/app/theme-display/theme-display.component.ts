import { Component, Input, OnChanges, OnInit, OnDestroy, SimpleChanges, AfterViewInit } from '@angular/core';

@Component({
  selector: 'app-theme-display',
  templateUrl: './theme-display.component.html',
  styleUrls: ['./theme-display.component.css']
})
export class ThemeDisplayComponent implements OnChanges, AfterViewInit, OnDestroy {
  @Input() theme!: string;

  ngOnChanges(changes: SimpleChanges): void {
    if (changes) {
      console.log(`Theme changed to: ${this.theme}`);
    }
  }

  ngAfterViewInit(): void {
    console.log('Child view has finished loading.');
  }

  ngOnDestroy(): void {
    console.log('Goodbye!');
  }
}
