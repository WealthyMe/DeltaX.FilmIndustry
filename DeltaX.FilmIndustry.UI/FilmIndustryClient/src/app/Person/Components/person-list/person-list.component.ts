import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { Person } from '../../../Models/person';

@Component({
  selector: 'app-person-list',
  templateUrl: './person-list.component.html',
  styleUrls: ['./person-list.component.css']
})
export class PersonListComponent implements OnInit {
  @Input() public persons: Person[] = new Array<Person>();
  @Output() public notifyRemovedPerson: EventEmitter<Person> = new EventEmitter<Person>();
  constructor() { }

  ngOnInit() {
  }

  removePersonNotifier(removedPerson: Person): void {
    this.persons = this.persons.filter(function (person) {
      return person.PersonID !== removedPerson.PersonID;
    });
    this.notifyRemovedPerson.emit(removedPerson);
  }

}
