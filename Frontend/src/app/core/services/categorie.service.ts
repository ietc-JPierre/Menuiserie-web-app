import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';
import { Categorie } from '../../models/categorie.model';

@Injectable({
  providedIn: 'root'
})
export class CategorieService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/categories`;

  categories = signal<Categorie[]>([]);

  load() {
    this.http
      .get<Categorie[]>(this.apiUrl)
      .subscribe(data => this.categories.set(data));
  }

  create(categorie: Categorie) {
    return this.http.post(this.apiUrl, categorie);
  }

  update(categorie: Categorie) {
    return this.http.put(
      `${this.apiUrl}/${categorie.id_Categorie}`,
      categorie
    );
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}