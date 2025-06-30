import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationFacade } from '../../store/application/application.facade';
import { UserApplication } from '../../interfaces/userApplication';

@Component({
  selector: 'app-application',
  standalone: true,
  templateUrl: './application.component.html',
  styleUrl: './application.component.scss',
  imports: [CommonModule]
})
export class ApplicationComponent implements OnInit {
  private readonly applicationFacade = inject(ApplicationFacade);
  applications: UserApplication[] = [];

  ngOnInit() {
    this.applicationFacade.getApplications();
    this.applicationFacade.applications$.subscribe(apps => {
      this.applications = apps;
    });
  }
}
