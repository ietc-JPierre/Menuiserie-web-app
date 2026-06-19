import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';
import { ClientChantier } from '../../models/client-chantier.model';

@Injectable({
  providedIn: 'root'
})
export class ClientChantierService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/clients-chantiers`;

  items = signal<ClientChantier[]>([]);

  load() {
    this.http
      .get<ClientChantier[]>(this.apiUrl)
      .subscribe(data => this.items.set(data));
  }
}