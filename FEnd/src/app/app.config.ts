import { provideRouter, Routes } from "@angular/router";
import { ApplicationConfig } from "@angular/core";
// import { NgModule } from "@angular/core";
import { AuthGuard } from "./auth/auth.guard"
 
// routong
import {MainComponent} from "./page/main/main.component";
import {LoginComponent} from "./page/login/login.component";
// import {LoginComponent} from "./page/login/login.component";

 
const appRoutes: Routes =[
    { path: "", component: MainComponent, canActivate: [AuthGuard]},
    { path: "login", component: LoginComponent},
    // { path: "**", component: NotFoundComponent }
];
 
export const appConfig: ApplicationConfig = {
  providers: [provideRouter(appRoutes)]
};