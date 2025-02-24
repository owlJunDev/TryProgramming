import { Component } from "@angular/core";
import { Router } from "@angular/router";
import { AuthService } from "../../auth/auth.service";
import { FormsModule } from '@angular/forms';
// import { FormsModule } from "@angular/forms";

@Component({
    selector: "login-app",
    standalone: true,
    imports: [FormsModule],
    templateUrl: "login.template.html",
    styleUrl: "login.style.css"
})
export class LoginComponent {
    url: string = "http://localhost:5000";
    username: string;
    password: string;
    errorMessage: string;
    showError: boolean = false;

    constructor(
        private authService: AuthService,
        private router: Router
    ) { }

    login() {
        this.authService.login();
        this.router.navigate(['']); // Перенаправление на главную страницу после входа
    }

    errorMess(err: string) {
        this.showError = true;
        this.errorMessage = err;
        setTimeout(() => {
            this.showError = false;
        }, 5000);
    }

    onSubmit() {
        if (this.username == null || this.password == null) {
            this.errorMess("Произошла ошибка при отправке формы!")
            return;
        }
        let body = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json;charset=utf-8'
            },
            body: JSON.stringify({
                "username": this.username,
                "pass": this.password
            })
        };
        fetch(this.url + "/api/auth/login", body).then(async resp => {
            if (resp.ok) {
                resp.json().then(res => {
                    localStorage.setItem("jt", res["value"]["access_token"]);
                    console.log(res["value"]["access_token"]); 
                    console.log(localStorage.getItem("jt")); 
                    this.login();
                })
            } else {
                const data = await resp.json();
                this.errorMess(data.value['err']);                
            }
        });
    }

}