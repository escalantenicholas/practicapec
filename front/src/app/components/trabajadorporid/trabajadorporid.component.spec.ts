import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TrabajadorporidComponent } from './trabajadorporid.component';

describe('TrabajadorporidComponent', () => {
  let component: TrabajadorporidComponent;
  let fixture: ComponentFixture<TrabajadorporidComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TrabajadorporidComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TrabajadorporidComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
