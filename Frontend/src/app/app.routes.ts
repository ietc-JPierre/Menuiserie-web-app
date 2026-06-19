import { Routes } from '@angular/router';
import { authGuard } from './core/guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'dashboard', pathMatch: 'full' },

  { path: 'login', loadComponent: () => import('./pages/login/login').then(m => m.Login) },
  { path: 'register', loadComponent: () => import('./pages/register/register').then(m => m.Register) },

  { path: 'dashboard', canActivate: [authGuard], loadComponent: () => import('./pages/dashboard/dashboard').then(m => m.Dashboard) },
  { path: 'clients', canActivate: [authGuard], loadComponent: () => import('./pages/clients/clients').then(m => m.Clients) },
  { path: 'produits', canActivate: [authGuard], loadComponent: () => import('./pages/produits/produits').then(m => m.Produits) },
  { path: 'categories', canActivate: [authGuard], loadComponent: () => import('./pages/categories/categories').then(m => m.Categories) },
  { path: 'commandes', canActivate: [authGuard], loadComponent: () => import('./pages/commandes/commandes').then(m => m.Commandes) },
  { path: 'chantiers', canActivate: [authGuard], loadComponent: () => import('./pages/chantiers/chantiers').then(m => m.Chantiers) },
  { path: 'personnels', canActivate: [authGuard], loadComponent: () => import('./pages/personnels/personnels').then(m => m.Personnels) },
  { path: 'dimensions', canActivate: [authGuard], loadComponent: () => import('./pages/dimensions/dimensions').then(m => m.Dimensions) },
  { path: 'commande-produits', canActivate: [authGuard], loadComponent: () => import('./pages/commande-produits/commande-produits').then(m => m.CommandeProduits) },

  { path: '**', redirectTo: 'dashboard' }
];