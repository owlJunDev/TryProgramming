import { Injectable } from "@angular/core";
import { CanActivate, Router } from "@angular/router";
import { AuthService } from "./auth.service";

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    constructor(private authService: AuthService, private router: Router) { };

    canActivate(): boolean {
        const token = localStorage.getItem('jt');
        if (this.authService.isAuthenticated() || token !== null) {
            return true;
        } else {
            this.router.navigate(['/login']);
            return false;
        }
    }
}