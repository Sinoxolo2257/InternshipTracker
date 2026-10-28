import { Routes } from '@angular/router';
import {ViewApplication} from './Components/Application/view-application/view-application';
import { ViewCompanies } from './Components/Company/view-companies/view-companies';
import { Dashboard } from './Components/dashboard/dashboard';
import { ViewDocs } from './Components/Settings/Docs/view-docs/view-docs';
import { ViewUsers } from './Components/User/view-users/view-users';
import { ViewPersonalInfo} from './Components/Settings/view-personal-info/view-personal-info';


export const routes: Routes = [
    {path: ' ', redirectTo:'dashboard',pathMatch:'full'},
    {path:'dashboard',component:Dashboard},
    {path:'view-application',component:ViewApplication},
    {path:'view-companies', component:ViewCompanies},
    {path:'view-docs',component:ViewDocs},
    {path:'view-users',component:ViewUsers},
    {path: 'view-personal-info', component: ViewPersonalInfo}
];
