import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MegaMenuModule } from 'primeng/megamenu';
import { Button } from 'primeng/button';
import { CommonModule, NgClass, NgIf } from '@angular/common';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: true,
  imports: [RouterModule,
    MegaMenuModule,
    NgIf,
    NgClass,
    Button,
    
  ],
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'homes';
}
