import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItemWriteComponent } from './item-write.component';

describe('ItemWriteComponent', () => {
  let component: ItemWriteComponent;
  let fixture: ComponentFixture<ItemWriteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ItemWriteComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ItemWriteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
