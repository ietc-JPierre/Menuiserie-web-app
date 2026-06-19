import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';

import { Dimension } from '../../models/dimension.model';

@Injectable({
  providedIn: 'root'
})
export class DimensionService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/dimensions`;

  dimensions = signal<Dimension[]>([]);

  load() {
    this.http
      .get<Dimension[]>(this.apiUrl)
      .subscribe(data => this.dimensions.set(data));
  }

  create(dimension: Dimension) {
  return this.http.post(this.apiUrl, dimension);
  }

  update(dimension: Dimension) {
    return this.http.put(
      `${this.apiUrl}/${dimension.id_Dimension}`,
      dimension
    );
  }

  delete(id: number) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}