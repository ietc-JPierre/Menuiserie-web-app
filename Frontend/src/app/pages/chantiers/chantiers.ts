import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { ChantierService } from '../../core/services/chantier.service';
import { CodePostalChantierService } from '../../core/services/code-postal-chantier.service';
import { Chantier } from '../../models/chantier.model';

@Component({
  selector: 'app-chantiers',
  imports: [FormsModule],
  templateUrl: './chantiers.html',
  styleUrl: './chantiers.css'
})
export class Chantiers implements OnInit {
  chantierService = inject(ChantierService);
  codePostalService = inject(CodePostalChantierService);

  editingId = signal<number | null>(null);

  form: Chantier = {
    id_Chantier: 0,
    nom_Chantier: '',
    rue: '',
    date_Debut_Chantier: '',
    date_Fin_Chantier: '',
    code_Postal: ''
  };

  ngOnInit() {
    this.chantierService.load();
    this.codePostalService.load();
  }

  save() {
    if (this.editingId()) {
      this.chantierService.update(this.form).subscribe(() => {
        this.chantierService.load();
        this.reset();
      });
    } else {
      this.chantierService.create(this.form).subscribe(() => {
        this.chantierService.load();
        this.reset();
      });
    }
  }

  edit(chantier: Chantier) {
    this.editingId.set(chantier.id_Chantier);
    this.form = { ...chantier };
  }

  delete(id: number) {
    if (!confirm('Supprimer ce chantier ?')) return;

    this.chantierService.delete(id).subscribe(() => {
      this.chantierService.load();
    });
  }

  reset() {
    this.editingId.set(null);

    this.form = {
      id_Chantier: 0,
      nom_Chantier: '',
      rue: '',
      date_Debut_Chantier: '',
      date_Fin_Chantier: '',
      code_Postal: ''
    };
  }
}