import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClientStatisticsComponent } from './client-statistics.component';

describe('ClientStatisticsComponent', () => {
  let component: ClientStatisticsComponent;
  let fixture: ComponentFixture<ClientStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClientStatisticsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClientStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
