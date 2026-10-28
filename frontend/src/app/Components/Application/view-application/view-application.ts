import { Component,OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ApplicationService } from '../../../Services/application-service';
import { Application, ApplicationRequest } from '../../../Models/models';

@Component({
  selector: 'app-view-application',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule
  ],
  templateUrl: './view-application.html',
  styleUrl: './view-application.css',
})
export class ViewApplication implements OnInit {

  applications: Application[]=[];

  constructor(private applicationService: ApplicationService) {}

  ngOnInit(): void {
    this.loadAllApplications();
  }

  loadAllApplications():void{
    this.applicationService.getAll().subscribe(data=>this.applications=data);
  }

}
