import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { SwitchCaseComponent } from './switch-case/switch-case.component';
import { LoopsComponent } from './loops/loops.component';

@NgModule({
  declarations: [
    AppComponent,
    SwitchCaseComponent,
    LoopsComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
