import { Component } from "@angular/core";
import { FormsModule }   from "@angular/forms";
      
class Item{
    purchase: string;
    done: boolean;
    price: number;
      
    constructor(purchase: string, price: number) {
   
        this.purchase = purchase;
        this.price = price;
        this.done = false;
    }
}
  
@Component({
    selector: "purchase-app",
    standalone: true,
    imports: [FormsModule],
    styleUrl: "app.style.css",
    templateUrl: "app.template.html"
})
export class AppComponent { 
}