import { Component } from '@angular/core';

@Component({
  selector: 'app-product-page',
  templateUrl: './product-page.component.html',
  styleUrls: ['./product-page.component.css']
})
export class ProductPageComponent {
  product = {
    name: "Super headphone", 
    price: 99.99, 
    inStock: true
  }
}
