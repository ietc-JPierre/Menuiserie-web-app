import { Component, OnInit, inject, signal } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { PersonnelService } from '../../core/services/personnel.service';
import { Personnel } from '../../models/personnel.model';

@Component({
  selector: 'app-personnels',
  imports: [FormsModule],
  templateUrl: './personnels.html',
  styleUrl: './personnels.css'
})
export class Personnels implements OnInit {
  personnelService = inject(PersonnelService);

  editingId = signal<string | null>(null);

  form: Personnel = {
    id_Personnel: '',
    nom: '',
    role: ''
  };

  ngOnInit() {
    this.personnelService.load();
  }

  save() {
    if (this.editingId()) {
      this.personnelService.update(this.form).subscribe(() => {
        this.personnelService.load();
        this.reset();
      });
    } else {
      this.personnelService.create(this.form).subscribe(() => {
        this.personnelService.load();
        this.reset();
      });
    }
  }

  edit(personnel: Personnel) {
    this.editingId.set(personnel.id_Personnel);
    this.form = { ...personnel };
  }

  delete(id: string) {
    if (!confirm('Supprimer ce membre du personnel ?')) return;

    this.personnelService.delete(id).subscribe(() => {
      this.personnelService.load();
    });
  }

  reset() {
    this.editingId.set(null);

    this.form = {
      id_Personnel: '',
      nom: '',
      role: ''
    };
  }
}