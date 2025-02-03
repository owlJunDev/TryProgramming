import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "../../auth/auth.service";
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
    selector: "login-app",
    templateUrl: "login.template.html"
})
export class LoginComponent {
    loginForm: FormGroup;
    url: String;

    constructor(
        private formBuilder: FormBuilder,
        private authService: AuthService,
        private router: Router
    ) {
        this.url = "http://localhost:5000";
        this.loginForm = this.formBuilder.group({
            username: ['', Validators.required],
            password: ['', Validators.required]
        });
    }

    login() {
        this.authService.login();
        this.router.navigate(['/main']); // Перенаправление на главную страницу после входа
    }
    sendMessage(): void {
        fetch(this.url + "/test/free", {
            method: "GET",
            headers: {}
        }).then(async resp => {
            alert(resp.ok);
            console.log(resp);
        })
    }
    sendMessageAuth(): void {
        fetch(this.url + "/test/auth", {
            method: "GET",
            headers: {
                "Accept": "application/json",
                "Authorization": "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoib3dsIiwiZXhwIjoxNzM4NTQ3NzY4LCJpc3MiOiJNeUF1dGhTZXJ2ZXIiLCJhdWQiOiJNeUF1dGhDbGllbnQifQ.DaK3xt5uH4APUcLr2mK9JpJp3TIQmCcBVT5-qPbNXSc"
            }
        }).then(async resp => {
            alert(resp.ok);
            console.log(resp);
        })
    }
    onSubmit(): void {
        if (this.loginForm.valid) {
            const { username, password } = this.loginForm.value;
            // Здесь можно добавить логику для аутентификации пользователя
            console.log('Username:', username);
            console.log('Password:', password);
            // Например, вызвать сервис для логина
        } else {
            console.log('Форма не валидна');
        }
    }

}