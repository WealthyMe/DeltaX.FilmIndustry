import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PersonSmartSearchComponent } from './person-smart-search.component';

describe('PersonSmartSearchComponent', () => {
  let component: PersonSmartSearchComponent;
  let fixture: ComponentFixture<PersonSmartSearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PersonSmartSearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PersonSmartSearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
