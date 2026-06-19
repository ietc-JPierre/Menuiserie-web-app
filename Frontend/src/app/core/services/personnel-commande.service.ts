import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';

import { PersonnelCommande } from '../../models/personnel-commande.model';

@Injectable({
  providedIn: 'root'
})
export class PersonnelCommandeService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/personnels-commandes`;

  items = signal<PersonnelCommande[]>([]);

  load() {
    this.http
      .get<PersonnelCommande[]>(this.apiUrl)
      .subscribe(data => this.items.set(data));
  }
}