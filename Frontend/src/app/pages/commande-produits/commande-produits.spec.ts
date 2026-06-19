import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommandeProduits } from './commande-produits';

describe('CommandeProduits', () => {
  let component: CommandeProduits;
  let fixture: ComponentFixture<CommandeProduits>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommandeProduits],
    }).compileComponents();

    fixture = TestBed.createComponent(CommandeProduits);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
