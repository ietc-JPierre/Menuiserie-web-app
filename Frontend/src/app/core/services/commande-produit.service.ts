import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';
import { CommandeProduit } from '../../models/commande-produit.model';

@Injectable({
  providedIn: 'root'
})
export class CommandeProduitService {
  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/commandes-produits`;

  commandeProduits = signal<CommandeProduit[]>([]);

  load() {
    this.http
      .get<CommandeProduit[]>(this.apiUrl)
      .subscribe(data => this.commandeProduits.set(data));
  }

  create(item: CommandeProduit) {
    return this.http.post(this.apiUrl, item);
  }

  delete(idProduit: number, idDimension: number, idCommande: number) {
    return this.http.delete(
      `${this.apiUrl}/${idProduit}/${idDimension}/${idCommande}`
    );
  }
}