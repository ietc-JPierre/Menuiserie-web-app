import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';
import { Produit } from '../../models/produit.model';

@Injectable({
  providedIn: 'root'
})
export class ProduitService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/produits`;

  produits = signal<Produit[]>([]);

  load() {
    this.http
      .get<Produit[]>(this.apiUrl)
      .subscribe(data => this.produits.set(data));
  }

  getById(id: number) {
    return this.http.get<Produit>(
      `${this.apiUrl}/${id}`
    );
  }

  create(produit: Produit) {
    return this.http.post(this.apiUrl, produit);
  }

  update(produit: Produit) {
    return this.http.put(
      `${this.apiUrl}/${produit.id_Produit}`,
      produit
    );
  }

  delete(id: number) {
    return this.http.delete(
      `${this.apiUrl}/${id}`
    );
  }
}