import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';
import { Client } from '../../models/client.model';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/clients`;

  clients = signal<Client[]>([]);

  load() {
    this.http
      .get<Client[]>(this.apiUrl)
      .subscribe(data => this.clients.set(data));
  }

  getById(id: number) {
    return this.http.get<Client>(
      `${this.apiUrl}/${id}`
    );
  }

  create(client: Client) {
    return this.http.post(
      this.apiUrl,
      client
    );
  }

  update(client: Client) {
    return this.http.put(
      `${this.apiUrl}/${client.id_Client}`,
      client
    );
  }

  delete(id: number) {
    return this.http.delete(
      `${this.apiUrl}/${id}`
    );
  }
}