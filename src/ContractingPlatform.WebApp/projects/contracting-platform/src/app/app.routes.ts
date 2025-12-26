import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: '',
    loadComponent: () => import('./pages/home').then(m => m.Home),
  },
  {
    path: 'services',
    loadComponent: () => import('./pages/services').then(m => m.Services),
  },
  {
    path: 'contact',
    loadComponent: () => import('./pages/contact').then(m => m.Contact),
  },
  {
    path: '**',
    redirectTo: '',
  },
];
