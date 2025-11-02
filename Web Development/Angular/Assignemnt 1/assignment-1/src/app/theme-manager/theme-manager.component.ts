import { Component } from '@angular/core';

@Component({
  selector: 'app-theme-manager',
  templateUrl: './theme-manager.component.html',
  styleUrls: ['./theme-manager.component.css']
})
export class ThemeManagerComponent {
  currentTheme = 'Light';
  showChild = true;

  toggleTheme() {
    this.currentTheme = this.currentTheme === 'Light' ? 'Dark' : 'Light';
  }

  toggleChild() {
    this.showChild = !this.showChild;
  }
}
