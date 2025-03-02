import { Component, OnInit, HostListener } from '@angular/core';
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
export class NavComponent implements OnInit {
    isSidebarCollapsed = false;
    isProfileMenuVisible = false;
    constructor(
        private authService: AuthService,
        private router: Router
    ) { }
    ngOnInit() {
        this.isSidebarCollapsed = localStorage.getItem('isSidebarCollapsed') === 'true';
        // this.isProfileMenuVisible = localStorage.getItem('isProfileMenuVisible') === 'true';
    }

    // Переключение сайдбара
    toggleSidebar() {
        this.isSidebarCollapsed = !this.isSidebarCollapsed;
        localStorage.setItem('isSidebarCollapsed', this.isSidebarCollapsed.toString());
    }

    // Переключение меню профиля
    toggleProfileMenu() {
        this.isProfileMenuVisible = !this.isProfileMenuVisible;
        localStorage.setItem('isProfileMenuVisible', this.isProfileMenuVisible.toString());
    }

    // Закрытие меню профиля при клике вне его
    @HostListener('document:click', ['$event'])
    closeProfileMenu(event: MouseEvent) {
        const profileButton = document.getElementById('profileButton');
        if (event.target !== profileButton && !profileButton?.contains(event.target as Node)) {
            this.isProfileMenuVisible = false;
        }
    }

    // Переключение аккордеона
    toggleAccordion(event: MouseEvent) {
        const header = event.currentTarget as HTMLElement;
        header.classList.toggle('active');
        const submenu = header.nextElementSibling as HTMLElement;
        if (submenu.style.display === 'block') {
            submenu.style.display = 'none';
        } else {
            submenu.style.display = 'block';
        }
    }

    logout() {
        // Перенаправляем на страницу авторизации
        localStorage.removeItem('jt');
        this.router.navigate(['/login']);
    }
}