import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';

import { Commande } from '../../models/commande.model';

@Injectable({
  providedIn: 'root'
})
export class CommandeService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/commandes`;

  commandes = signal<Commande[]>([]);

  load() {
    this.http
      .get<Commande[]>(this.apiUrl)
      .subscribe(data => this.commandes.set(data));
  }
  create(commande: Commande) {
    return this.http.post(this.apiUrl, commande);
  }

  update(commande: Commande) {
    return this.http.put(`${this.apiUrl}/${commande.id_Commande}`, commande);
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}