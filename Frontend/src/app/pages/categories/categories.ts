import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { CategorieService } from '../../core/services/categorie.service';
import { Categorie } from '../../models/categorie.model';

@Component({
  selector: 'app-categories',
  imports: [FormsModule],
  templateUrl: './categories.html',
  styleUrl: './categories.css'
})
export class Categories implements OnInit {
  categorieService = inject(CategorieService);

  editingId = signal<number | null>(null);

  form: Categorie = {
    id_Categorie: 0,
    nom_Categorie: ''
  };

  ngOnInit() {
    this.categorieService.load();
  }

  save() {
    if (this.editingId()) {
      this.categorieService.update(this.form).subscribe(() => {
        this.categorieService.load();
        this.reset();
      });
    } else {
      this.categorieService.create(this.form).subscribe(() => {
        this.categorieService.load();
        this.reset();
      });
    }
  }

  edit(categorie: Categorie) {
    this.editingId.set(categorie.id_Categorie);
    this.form = { ...categorie };
  }

  delete(id: number) {
    if (!confirm('Supprimer cette catégorie ?')) return;

    this.categorieService.delete(id).subscribe(() => {
      this.categorieService.load();
    });
  }

  reset() {
    this.editingId.set(null);

    this.form = {
      id_Categorie: 0,
      nom_Categorie: ''
    };
  }
}