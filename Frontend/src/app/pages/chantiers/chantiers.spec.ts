import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Chantiers } from './chantiers';

describe('Chantiers', () => {
  let component: Chantiers;
  let fixture: ComponentFixture<Chantiers>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Chantiers],
    }).compileComponents();

    fixture = TestBed.createComponent(Chantiers);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
