import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { CommandeService } from '../../core/services/commande.service';
import { ClientService } from '../../core/services/client.service';
import { Commande } from '../../models/commande.model';

@Component({
  selector: 'app-commandes',
  imports: [FormsModule],
  templateUrl: './commandes.html',
  styleUrl: './commandes.css'
})
export class Commandes implements OnInit {
  commandeService = inject(CommandeService);
  clientService = inject(ClientService);

  editingId = signal<number | null>(null);

  form: Commande = {
    id_Commande: 0,
    date_Commande: '',
    montant_Paye: 0,
    reste_A_Payer: 0,
    statut_Commande: 'En cours',
    total_Commande: 0,
    id_Client: 1
  };

  ngOnInit() {
    this.commandeService.load();
    this.clientService.load();
  }

  calculerReste() {
    this.form.reste_A_Payer = this.form.total_Commande - this.form.montant_Paye;
  }

  save() {
    this.calculerReste();

    if (this.editingId()) {
      this.commandeService.update(this.form).subscribe(() => {
        this.commandeService.load();
        this.reset();
      });
    } else {
      this.commandeService.create(this.form).subscribe(() => {
        this.commandeService.load();
        this.reset();
      });
    }
  }

  edit(commande: Commande) {
    this.editingId.set(commande.id_Commande);
    this.form = { ...commande };
  }

  delete(id: number) {
    if (!confirm('Supprimer cette commande ?')) return;

    this.commandeService.delete(id).subscribe(() => {
      this.commandeService.load();
    });
  }

  reset() {
    this.editingId.set(null);

    this.form = {
      id_Commande: 0,
      date_Commande: '',
      montant_Paye: 0,
      reste_A_Payer: 0,
      statut_Commande: 'En cours',
      total_Commande: 0,
      id_Client: 1
    };
  }
}