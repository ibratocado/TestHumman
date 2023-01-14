import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GenCardProductComponent } from './gen-card-product.component';

describe('GenCardProductComponent', () => {
  let component: GenCardProductComponent;
  let fixture: ComponentFixture<GenCardProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GenCardProductComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GenCardProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
