import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { ClientService } from '../../core/services/client.service';
import { TypeClientService } from '../../core/services/type-client.service';
import { Client } from '../../models/client.model';

@Component({
  selector: 'app-clients',
  imports: [FormsModule],
  templateUrl: './clients.html',
  styleUrl: './clients.css'
})
export class Clients implements OnInit {
  clientService = inject(ClientService);
  typeClientService = inject(TypeClientService);

  editingId = signal<number | null>(null);

  form: Client = {
    id_Client: 0,
    nom_Client: '',
    adresse_Client: '',
    tel_Client: '',
    id_Type_Client: 1
  };

  ngOnInit() {
    this.clientService.load();
    this.typeClientService.load();
  }

  save() {
    if (this.editingId()) {
      this.clientService.update(this.form).subscribe(() => {
        this.clientService.load();
        this.reset();
      });
    } else {
      this.clientService.create(this.form).subscribe(() => {
        this.clientService.load();
        this.reset();
      });
    }
  }

  edit(client: Client) {
    this.editingId.set(client.id_Client);
    this.form = { ...client };
  }

  delete(id: number) {
    if (!confirm('Supprimer ce client ?')) return;

    this.clientService.delete(id).subscribe(() => {
      this.clientService.load();
    });
  }

  reset() {
    this.editingId.set(null);

    this.form = {
      id_Client: 0,
      nom_Client: '',
      adresse_Client: '',
      tel_Client: '',
      id_Type_Client: 1
    };
  }
}