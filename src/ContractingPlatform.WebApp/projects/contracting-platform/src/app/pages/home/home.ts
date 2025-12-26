import { Component, inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { combineLatest, map, of, catchError, startWith } from 'rxjs';
import {
  HeroSection,
  Statistic,
  ServiceCard,
  TrustBadge,
  SectionHeader,
} from 'contracting-platform-components';
import { ApiService } from '../../services';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    CommonModule,
    RouterModule,
    HeroSection,
    Statistic,
    ServiceCard,
    TrustBadge,
    SectionHeader,
  ],
  templateUrl: './home.html',
  styleUrl: './home.scss',
})
export class Home {
  private apiService = inject(ApiService);

  private fallbackServices = [
    { serviceId: '1', name: 'Kitchen Renovation', slug: 'kitchen', description: 'Transform your kitchen into the heart of your home.', icon: 'kitchen', imageUrl: '', displayOrder: 1 },
    { serviceId: '2', name: 'Bathroom Renovation', slug: 'bathroom', description: 'Create your dream bathroom with modern fixtures.', icon: 'bathtub', imageUrl: '', displayOrder: 2 },
    { serviceId: '3', name: 'Basement Finishing', slug: 'basement', description: 'Maximize your living space with basement finishing.', icon: 'home', imageUrl: '', displayOrder: 3 },
    { serviceId: '4', name: 'Water Damage Restoration', slug: 'water-damage', description: '24/7 emergency water damage restoration services.', icon: 'water_damage', imageUrl: '', displayOrder: 4 },
    { serviceId: '5', name: 'Roofing & Exterior', slug: 'roofing', description: 'Complete roofing services including repair and replacement.', icon: 'roofing', imageUrl: '', displayOrder: 5 },
    { serviceId: '6', name: 'General Contracting', slug: 'general', description: 'Full-service general contracting for all projects.', icon: 'construction', imageUrl: '', displayOrder: 6 },
  ];

  private fallbackStatistics = [
    { statisticId: '1', value: '37', label: 'Years of Experience', suffix: '+', displayOrder: 1 },
    { statisticId: '2', value: '6,500', label: 'Projects Completed', suffix: '+', displayOrder: 2 },
    { statisticId: '3', value: '5', label: 'NYC Boroughs Served', suffix: null, displayOrder: 3 },
    { statisticId: '4', value: '24/7', label: 'Emergency Response', suffix: null, displayOrder: 4 },
  ];

  private fallbackTrustBadges = [
    { trustBadgeId: '1', icon: 'verified', title: 'NYC Licensed', subtitle: 'General Contractor', displayOrder: 1 },
    { trustBadgeId: '2', icon: 'workspace_premium', title: 'BBB Accredited', subtitle: 'A+ Rating', displayOrder: 2 },
    { trustBadgeId: '3', icon: 'security', title: 'Fully Insured', subtitle: 'Licensed & Bonded', displayOrder: 3 },
    { trustBadgeId: '4', icon: 'family_restroom', title: 'Family Owned', subtitle: 'Since 1987', displayOrder: 4 },
  ];

  viewModel$ = combineLatest([
    this.apiService.getServices().pipe(
      catchError(() => of(this.fallbackServices)),
      startWith(this.fallbackServices)
    ),
    this.apiService.getStatistics().pipe(
      catchError(() => of(this.fallbackStatistics)),
      startWith(this.fallbackStatistics)
    ),
    this.apiService.getTrustBadges().pipe(
      catchError(() => of(this.fallbackTrustBadges)),
      startWith(this.fallbackTrustBadges)
    ),
  ]).pipe(
    map(([services, statistics, trustBadges]) => ({
      services: services.slice(0, 6),
      statistics,
      trustBadges,
    }))
  );

  onGetEstimate(): void {
    window.location.href = '/contact';
  }

  onCallNow(): void {
    window.location.href = 'tel:7185502779';
  }
}
