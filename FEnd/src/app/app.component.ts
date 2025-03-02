import { Component } from "@angular/core";
import { RouterOutlet } from "@angular/router";
import { AuthService } from "./auth/auth.service";

@Component({
    selector: "app",
    standalone: true,
    imports: [RouterOutlet],
    template: "<router-outlet></router-outlet>"
})
export class AppComponent {}