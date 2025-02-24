import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "../../auth/auth.service";
import { FormsModule } from '@angular/forms';

@Component({
    selector: "main-app",
    standalone: true,
    imports: [FormsModule],
    templateUrl: "main.template.html",
    styleUrl: "main.style.css"
})
export class MainComponent { }