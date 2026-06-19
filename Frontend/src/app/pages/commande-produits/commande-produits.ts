import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { CommandeProduitService } from '../../core/services/commande-produit.service';
import { CommandeService } from '../../core/services/commande.service';
import { ProduitService } from '../../core/services/produit.service';
import { DimensionService } from '../../core/services/dimension.service';

import { CommandeProduit } from '../../models/commande-produit.model';

@Component({
  selector: 'app-commande-produits',
  imports: [FormsModule],
  templateUrl: './commande-produits.html',
  styleUrl: './commande-produits.css'
})
export class CommandeProduits implements OnInit {
  commandeProduitService = inject(CommandeProduitService);
  commandeService = inject(CommandeService);
  produitService = inject(ProduitService);
  dimensionService = inject(DimensionService);

  form: CommandeProduit = {
    id_Produit: 1,
    id_Dimension: 1,
    id_Commande: 1,
    quantite: 1,
    prix_Unitaire: 0
  };

  ngOnInit() {
    this.commandeProduitService.load();
    this.commandeService.load();
    this.produitService.load();
    this.dimensionService.load();
  }

  save() {
    this.commandeProduitService.create(this.form).subscribe(() => {
      this.commandeProduitService.load();
      this.reset();
    });
  }

  delete(item: CommandeProduit) {
    if (!confirm('Supprimer cette ligne de commande ?')) return;

    this.commandeProduitService
      .delete(item.id_Produit, item.id_Dimension, item.id_Commande)
      .subscribe(() => this.commandeProduitService.load());
  }

  reset() {
    this.form = {
      id_Produit: 1,
      id_Dimension: 1,
      id_Commande: 1,
      quantite: 1,
      prix_Unitaire: 0
    };
  }
}