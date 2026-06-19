import { Injectable, inject, signal } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '../../../environments/environment';
import { TypeClient } from '../../models/type-client.model';

@Injectable({
  providedIn: 'root'
})
export class TypeClientService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/types-clients`;

  typeClients = signal<TypeClient[]>([]);

  load() {
    this.http.get<TypeClient[]>(this.apiUrl)
      .subscribe(data => this.typeClients.set(data));
  }
}