import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-footer',
  standalone: true,
  imports: [CommonModule, RouterModule, MatIconModule],
  templateUrl: './footer.html',
  styleUrl: './footer.scss',
})
export class Footer {
  currentYear = new Date().getFullYear();

  quickLinks = [
    { path: '/', label: 'Home' },
    { path: '/services', label: 'Services' },
    { path: '/contact', label: 'Contact' },
  ];

  services = [
    { path: '/services', label: 'Kitchen Renovation' },
    { path: '/services', label: 'Bathroom Renovation' },
    { path: '/services', label: 'Basement Finishing' },
    { path: '/services', label: 'Water Damage Restoration' },
    { path: '/services', label: 'Roofing' },
    { path: '/services', label: 'General Contracting' },
  ];

  boroughs = ['Manhattan', 'Brooklyn', 'Queens', 'Bronx', 'Staten Island'];
}
