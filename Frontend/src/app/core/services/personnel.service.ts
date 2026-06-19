import { HttpClient } from '@angular/common/http';
import { Injectable, inject, signal } from '@angular/core';

import { environment } from '../../../environments/environment';

import { Personnel } from '../../models/personnel.model';

@Injectable({
  providedIn: 'root'
})
export class PersonnelService {

  private http = inject(HttpClient);

  private apiUrl = `${environment.apiUrl}/personnels`;

  personnels = signal<Personnel[]>([]);

  load() {
    this.http
      .get<Personnel[]>(this.apiUrl)
      .subscribe(data => this.personnels.set(data));
  }

  create(personnel: Personnel) {
  return this.http.post(this.apiUrl, personnel);
  }

  update(personnel: Personnel) {
    return this.http.put(
      `${this.apiUrl}/${personnel.id_Personnel}`,
      personnel
    );
  }

  delete(id: string) {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}