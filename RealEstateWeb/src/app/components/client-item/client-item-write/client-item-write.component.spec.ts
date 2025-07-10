import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientItemWriteComponent } from './client-item-write.component';

describe('ClientItemWriteComponent', () => {
  let component: ClientItemWriteComponent;
  let fixture: ComponentFixture<ClientItemWriteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientItemWriteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientItemWriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
