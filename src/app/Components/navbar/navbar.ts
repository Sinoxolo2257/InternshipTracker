import { Component } from '@angular/core';
import { RouterLink, RouterLinkActive } from '@angular/router';
import { LucideDynamicIcon, LucideHouse, LucideFileUser, LucideBuildingComplex, LucideSettings, LucideListCollapse} from '@lucide/angular';

@Component({
  selector: 'app-navbar',
  imports: [RouterLink, RouterLinkActive, LucideDynamicIcon],
  templateUrl: './navbar.html',
  styleUrl: './navbar.css',
})
export class Navbar {
  isCollapsed = false;
  toggleIcon = LucideListCollapse;

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