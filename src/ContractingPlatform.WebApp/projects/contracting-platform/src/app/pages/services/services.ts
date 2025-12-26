import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { map, catchError, of, startWith } from 'rxjs';
import {
  HeroSection,
  ServiceCard,
  SectionHeader,
} from 'contracting-platform-components';
import { ApiService } from '../../services';

@Component({
  selector: 'app-services',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    HeroSection,
    ServiceCard,
    SectionHeader,
  ],
  templateUrl: './services.html',
  styleUrl: './services.scss',
})
export class Services {
  private apiService = inject(ApiService);

  private fallbackServices = [
    { serviceId: '1', name: 'Kitchen Renovation', slug: 'kitchen-renovation', description: 'Transform your kitchen into the heart of your home with custom cabinetry, premium countertops, and state-of-the-art appliances.', icon: 'kitchen', imageUrl: '', displayOrder: 1 },
    { serviceId: '2', name: 'Bathroom Renovation', slug: 'bathroom-renovation', description: 'Create your dream bathroom with modern fixtures, elegant tile work, and luxurious finishes that combine style with functionality.', icon: 'bathtub', imageUrl: '', displayOrder: 2 },
    { serviceId: '3', name: 'Basement Finishing', slug: 'basement-finishing', description: 'Maximize your living space with professional basement finishing, including waterproofing, insulation, and complete build-outs.', icon: 'home', imageUrl: '', displayOrder: 3 },
    { serviceId: '4', name: 'Water Damage Restoration', slug: 'water-damage-restoration', description: '24/7 emergency water damage restoration services. We handle extraction, drying, and complete restoration to pre-loss condition.', icon: 'water_damage', imageUrl: '', displayOrder: 4 },
    { serviceId: '5', name: 'Roofing & Exterior', slug: 'roofing-exterior', description: 'Complete roofing services including repair, replacement, and maintenance. Protect your home with quality materials and expert installation.', icon: 'roofing', imageUrl: '', displayOrder: 5 },
    { serviceId: '6', name: 'General Contracting', slug: 'general-contracting', description: 'Full-service general contracting for residential and commercial projects. From planning to completion, we manage every detail.', icon: 'construction', imageUrl: '', displayOrder: 6 },
    { serviceId: '7', name: 'Fire Damage Restoration', slug: 'fire-damage-restoration', description: 'Comprehensive fire and smoke damage restoration. We handle cleanup, deodorization, and complete rebuilding services.', icon: 'local_fire_department', imageUrl: '', displayOrder: 7 },
    { serviceId: '8', name: 'Sidewalk & DOT Violations', slug: 'sidewalk-dot-violations', description: 'Expert sidewalk replacement and DOT violation resolution. We handle permits, repairs, and ensure code compliance.', icon: 'warning', imageUrl: '', displayOrder: 8 },
  ];

  viewModel$ = this.apiService.getServices().pipe(
    catchError(() => of(this.fallbackServices)),
    startWith(this.fallbackServices),
    map(services => ({ services }))
  );

  onServiceClick(): void {
    window.location.href = '/contact';
  }
}
