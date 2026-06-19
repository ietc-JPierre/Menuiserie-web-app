import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';

import { Chantier } from '../../models/chantier.model';

@Injectable({
  providedIn: 'root'
})
export class ChantierService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/chantiers`;

  chantiers = signal<Chantier[]>([]);

  load() {
    this.http
      .get<Chantier[]>(this.apiUrl)
      .subscribe(data => this.chantiers.set(data));
  }

  create(chantier: Chantier) {
    return this.http.post(this.apiUrl, chantier);
  }

  update(chantier: Chantier) {
    return this.http.put(`${this.apiUrl}/${chantier.id_Chantier}`, chantier);
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}