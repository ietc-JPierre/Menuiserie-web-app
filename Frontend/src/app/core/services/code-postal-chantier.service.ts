import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';

import { CodePostalChantier } from '../../models/code-postal-chantier.model';

@Injectable({
  providedIn: 'root'
})
export class CodePostalChantierService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/codes-postaux-chantiers`;

  codesPostaux = signal<CodePostalChantier[]>([]);

  load() {
    this.http
      .get<CodePostalChantier[]>(this.apiUrl)
      .subscribe(data => this.codesPostaux.set(data));
  }

  create(item: CodePostalChantier) {
    return this.http.post(this.apiUrl, item);
  }

  update(item: CodePostalChantier) {
    return this.http.put(
      `${this.apiUrl}/${item.code_Postal}`,
      item
    );
  }

  delete(codePostal: string) {
    return this.http.delete(
      `${this.apiUrl}/${codePostal}`
    );
  }
}