import { Component, input  } from '@angular/core';
import { House } from '../../interfaces/house';
import { NgFor } from '@angular/common';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-housing-location',
  standalone: true,
  templateUrl: './housing-location.component.html',
  styleUrl: './housing-location.component.scss',
  imports: [RouterLink]
})
export class HousingLocationComponent {
  housingLocation = input.required<House>(); 
  //required input do te thote qe parent component duhet te jape vleren e housingLocation
}
