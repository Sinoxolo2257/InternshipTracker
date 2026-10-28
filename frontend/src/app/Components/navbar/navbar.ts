import { Component, inject } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { AuthService } from '../../Services/auth-service';
import { LucideDynamicIcon, LucideHouse, LucideFileUser, LucideBuildingComplex, LucideSettings, LucideListCollapse, LucideLogOut } from '@lucide/angular';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, RouterLinkActive, LucideDynamicIcon],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {
  isCollapsed = false;
  toggleIcon = LucideListCollapse;
  auth=inject(AuthService);
  logoutIcon = LucideLogOut;

  navbarItems = [
    { label: 'Dashboard', route: 'dashboard', icon: LucideHouse },
    { label: 'Applications', route: 'view-application', icon: LucideFileUser },
    { label: 'Companies', route: 'view-companies', icon: LucideBuildingComplex },
    { label: 'Settings', route: 'view-personal-info', icon: LucideSettings },
  ];

  toggleNavbar() {
    this.isCollapsed = !this.isCollapsed;
  }
}