import { Routes } from '@angular/router';
import { ViewApplication } from './Components/Application/view-application/view-application';
import { ViewCompanies } from './Components/Company/view-companies/view-companies';
import { Dashboard } from './Components/dashboard/dashboard';
import { ViewDocs } from './Components/Settings/Docs/view-docs/view-docs';
import { ViewPersonalInfo } from './Components/Settings/view-personal-info/view-personal-info';
import { authGuard } from './Gaurds/auth-guard';

export const routes: Routes = [
  {
    path: 'login',
    loadComponent: () => import('./Components/Login/login/login').then(m => m.Login),
  },
  {
    path: 'register',
    loadComponent: () => import('./Components/register/register').then(m => m.Register),
  },
  {
    path: '',
    canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: Dashboard },
      { path: 'view-application', component: ViewApplication },
      { path: 'view-companies', component: ViewCompanies },
      { path: 'view-docs', component: ViewDocs },
      { path: 'view-personal-info', component: ViewPersonalInfo },
    ],
  },
  { path: '**', redirectTo: '' },
];