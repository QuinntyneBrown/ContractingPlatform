import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../environments';

export interface ServiceDto {
  serviceId: string;
  name: string;
  slug: string;
  description: string;
  icon: string;
  imageUrl: string;
  displayOrder: number;
}

export interface StatisticDto {
  statisticId: string;
  value: string;
  label: string;
  suffix: string | null;
  displayOrder: number;
}

export interface TrustBadgeDto {
  trustBadgeId: string;
  icon: string;
  title: string;
  subtitle: string | null;
  displayOrder: number;
}

export interface CreateLeadRequest {
  fullName: string;
  email: string;
  phone: string;
  serviceType: string;
  projectAddress?: string;
  message?: string;
  preferredContactMethod: string;
}

export interface LeadDto {
  leadId: string;
  fullName: string;
  email: string;
  phone: string;
  serviceType: string;
  projectAddress: string | null;
  message: string | null;
  preferredContactMethod: string;
  status: string;
  createdAt: string;
}

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private http = inject(HttpClient);
  private baseUrl = environment.baseUrl;

  getServices(): Observable<ServiceDto[]> {
    return this.http.get<ServiceDto[]>(`${this.baseUrl}/api/services`);
  }

  getService(slug: string): Observable<ServiceDto> {
    return this.http.get<ServiceDto>(`${this.baseUrl}/api/services/${slug}`);
  }

  getStatistics(): Observable<StatisticDto[]> {
    return this.http.get<StatisticDto[]>(`${this.baseUrl}/api/statistics`);
  }

  getTrustBadges(): Observable<TrustBadgeDto[]> {
    return this.http.get<TrustBadgeDto[]>(`${this.baseUrl}/api/trustbadges`);
  }

  createLead(request: CreateLeadRequest): Observable<LeadDto> {
    return this.http.post<LeadDto>(`${this.baseUrl}/api/leads`, request);
  }
}
