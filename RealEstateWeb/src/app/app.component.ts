import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: true,
  imports: [RouterModule],
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'homes';
}
