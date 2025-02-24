import { Component, Input } from '@angular/core';
import { Router } from "@angular/router";
import { AuthService } from "../../auth/auth.service";
import { RouterOutlet } from "@angular/router";

@Component({
    selector: 'app-nav',
    templateUrl: './nav.component.html',
    standalone: true,
    imports: [RouterOutlet],
    styleUrl: './nav.component.css'
})
export class NavComponent {
    constructor(
        private authService: AuthService,
        private router: Router
    ) { }
    toggleSidebar() {
        const sidebar = document.getElementById('sidebar');
        sidebar.classList.toggle('collapsed');
    }
    
    toggleProfileMenu() {
        const profileMenu = document.getElementById('profileMenu');
        profileMenu.style.display = profileMenu.style.display === 'block' ? 'none' : 'block';
    }
    
    goToProfile() {
        alert('Переход на страницу профиля');
        // window.location.href = '/profile';
    }
    
    logout() {
        // Перенаправляем на страницу авторизации
        this.router.navigate(['/login']);
    }
}