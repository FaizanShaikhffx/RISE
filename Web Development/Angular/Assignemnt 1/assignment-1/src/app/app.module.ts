import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { ThemeManagerComponent } from './theme-manager/theme-manager.component';
import { ThemeDisplayComponent } from './theme-display/theme-display.component';

@NgModule({
  declarations: [
    AppComponent,
    ThemeManagerComponent,
    ThemeDisplayComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
