import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CompleterService, CompleterData, CompleterItem } from 'ng2-completer';
import { Actor } from '../../../Models/actor';
import { Person } from '../../../Models/person';

@Component({
  selector: 'app-person-smart-search',
  templateUrl: './person-smart-search.component.html',
  styleUrls: ['./person-smart-search.component.css']
})
export class PersonSmartSearchComponent implements OnInit {

  protected searchStr: string;
  public selectedPerson: Person = new Person();
  @Input() public placeHolder: string ="Search";
  @Output() public notifySelectedPerson: EventEmitter<Person> = new EventEmitter<Person>();
  protected dataService: CompleterData;

  constructor(private completerService: CompleterService) {
    this.dataService = completerService.remote(location.origin + '/api/Persons/GetWildCardSearchResult?name=','Name','Name');
  }

  ngOnInit() {
  }

  AddToSelectedList(selected: CompleterItem): void {
    if (selected != null && selected.originalObject != null) {
      this.selectedPerson = new Person();
      this.selectedPerson.Name = selected.originalObject["Name"];
      this.selectedPerson.PersonID = selected.originalObject["PersonID"];
      this.selectedPerson.DOB = selected.originalObject["DOB"];
      this.selectedPerson.Bio = selected.originalObject["Bio"];
      this.notifySelectedPerson.emit(this.selectedPerson);
    }
  }
}
