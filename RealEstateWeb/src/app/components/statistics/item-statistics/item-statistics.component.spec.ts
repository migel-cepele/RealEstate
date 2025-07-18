import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemStatisticsComponent } from './item-statistics.component';

describe('ItemStatisticsComponent', () => {
  let component: ItemStatisticsComponent;
  let fixture: ComponentFixture<ItemStatisticsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemStatisticsComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemStatisticsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
