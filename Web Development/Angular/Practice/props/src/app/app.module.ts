import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import { ParentComponent } from './parent/parent.component';
import { ChildComponent } from './child/child.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { WelcomeMessageComponent } from './welcome-message/welcome-message.component';
import { ProductPageComponent } from './product-page/product-page.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { ArticleHostComponent } from './article-host/article-host.component';
import { AuthorBioComponent } from './author-bio/author-bio.component';

@NgModule({
  declarations: [
    AppComponent,
    ParentComponent,
    ChildComponent,
    UserProfileComponent,
    WelcomeMessageComponent,
    ProductPageComponent,
    ProductDetailsComponent,
    ArticleHostComponent,
    AuthorBioComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
