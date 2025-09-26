import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { SecondComponent } from './second/second.component';
import { InlineTempleteComponent } from './inline-templete/inline-templete.component';
import { InlineStyleComponent } from './inline-style/inline-style.component';
import { InlineStyleTemplateComponent } from './inline-style-template/inline-style-template.component';
import { DataBindingComponent } from './data-binding/data-binding.component';

@NgModule({
  declarations: [
    AppComponent,
    SecondComponent,
    InlineTempleteComponent,
    InlineStyleComponent,
    InlineStyleTemplateComponent,
    DataBindingComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
