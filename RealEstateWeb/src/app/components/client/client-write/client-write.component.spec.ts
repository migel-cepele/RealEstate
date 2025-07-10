import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientWriteComponent } from './client-write.component';

describe('ClientWriteComponent', () => {
  let component: ClientWriteComponent;
  let fixture: ComponentFixture<ClientWriteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientWriteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientWriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
