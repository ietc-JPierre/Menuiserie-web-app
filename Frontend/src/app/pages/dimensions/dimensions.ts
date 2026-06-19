import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { DimensionService } from '../../core/services/dimension.service';
import { Dimension } from '../../models/dimension.model';

@Component({
  selector: 'app-dimensions',
  imports: [FormsModule],
  templateUrl: './dimensions.html',
  styleUrl: './dimensions.css'
})
export class Dimensions implements OnInit {
  dimensionService = inject(DimensionService);

  editingId = signal<number | null>(null);

  form: Dimension = {
    id_Dimension: 0,
    hauteur: 0,
    section: 0,
    largeur: 0
  };

  ngOnInit() {
    this.dimensionService.load();
  }

  save() {
    if (this.editingId()) {
      this.dimensionService.update(this.form).subscribe(() => {
        this.dimensionService.load();
        this.reset();
      });
    } else {
      this.dimensionService.create(this.form).subscribe(() => {
        this.dimensionService.load();
        this.reset();
      });
    }
  }

  edit(dimension: Dimension) {
    this.editingId.set(dimension.id_Dimension);
    this.form = { ...dimension };
  }

  delete(id: number) {
    if (!confirm('Supprimer cette dimension ?')) return;

    this.dimensionService.delete(id).subscribe(() => {
      this.dimensionService.load();
    });
  }

  reset() {
    this.editingId.set(null);

    this.form = {
      id_Dimension: 0,
      hauteur: 0,
      section: 0,
      largeur: 0
    };
  }
}