import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-author-bio',
  templateUrl: './author-bio.component.html',
  styleUrls: ['./author-bio.component.css']
})
export class AuthorBioComponent {
  @Input() authorName: string = ""; 
}
