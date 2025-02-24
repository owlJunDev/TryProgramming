import { provideRouter, Routes } from "@angular/router";
import { ApplicationConfig } from "@angular/core";
// import { NgModule } from "@angular/core";
import { AuthGuard } from "./auth/auth.guard"

//templates
import { NavComponent } from "./template/nav/nav.component";

// routong
import { MainComponent } from "./page/main/main.component";
import { LoginComponent } from "./page/login/login.component";
// import {LoginComponent} from "./page/login/login.component";


const appRoutes: Routes = [
  {
    path: "",
    component: NavComponent,
    children: [
      { path: "", component: MainComponent, canActivate: [AuthGuard] }
    ]
  },
  { path: "login", component: LoginComponent },
  // { path: "**", component: NotFoundComponent }
];

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(appRoutes)]
};