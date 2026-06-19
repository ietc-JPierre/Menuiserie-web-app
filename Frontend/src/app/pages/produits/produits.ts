import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { ProduitService } from '../../core/services/produit.service';
import { CategorieService } from '../../core/services/categorie.service';
import { Produit } from '../../models/produit.model';

@Component({
  selector: 'app-produits',
  imports: [FormsModule],
  templateUrl: './produits.html',
  styleUrl: './produits.css'
})
export class Produits implements OnInit {
  produitService = inject(ProduitService);
  categorieService = inject(CategorieService);

  editingId = signal<number | null>(null);

  form: Produit = {
    id_Produit: 0,
    nom_produit: '',
    prix_unitaire_produit: 0,
    id_Categorie: 1
  };

  ngOnInit() {
    this.produitService.load();
    this.categorieService.load();
  }

  save() {
    if (this.editingId()) {
      this.produitService.update(this.form).subscribe(() => {
        this.produitService.load();
        this.reset();
      });
    } else {
      this.produitService.create(this.form).subscribe(() => {
        this.produitService.load();
        this.reset();
      });
    }
  }

  edit(produit: Produit) {
    this.editingId.set(produit.id_Produit);
    this.form = { ...produit };
  }

  delete(id: number) {
    if (!confirm('Supprimer ce produit ?')) return;

    this.produitService.delete(id).subscribe(() => {
      this.produitService.load();
    });
  }

  reset() {
    this.editingId.set(null);

    this.form = {
      id_Produit: 0,
      nom_produit: '',
      prix_unitaire_produit: 0,
      id_Categorie: 1
    };
  }

  getNomCategorie(idCategorie: number) {
    return this.categorieService.categories()
      .find(c => c.id_Categorie === idCategorie)
      ?.nom_categorie ?? 'Inconnue';
  }
}