import { Component, OnInit, Input } from '@angular/core';
import 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';

import { ActivatedRoute } from '@angular/router';
import { Person } from '../../../Models/person';
import { Dropdown } from '../../../Models/dropdown';
import { PersonService } from '../../Services/person.service';
import { Gender } from '../../../Models/gender';
import { Alert, AlertType } from '../../../Models/alert';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { CrewCastRole } from '../../../Models/crew-cast-role';

@Component({
  selector: 'app-add-edit-person',
  templateUrl: './add-edit-person.component.html',
  styleUrls: ['./add-edit-person.component.css']
})
export class AddEditPersonComponent implements OnInit {

  public isSubmitted: boolean = false;
  public title: string;
  @Input() public crewCastRole: CrewCastRole;
  @Input("value") public id: string = '0';
  alertInfo: Alert = new Alert();


  public person: Person = new Person();
  public genderDropdownList: Dropdown[];

  constructor(private _personService: PersonService, private _activatedRoute: ActivatedRoute, private _ngbActiveModel:NgbActiveModal ) { }

  ngOnInit() {
    this.updateHeader();
    this.fetchPersonsDetails();
    this.subscribeToAllGenders();
  }

  fetchPersonsDetails(): void {
    
    let id: string = this._activatedRoute.snapshot.paramMap.get("id");
    if (id == null) {
      id = this.id;
    }
    if (id != '0') {
      this._personService.getPersonById(id)
        .subscribe((data: Person) => this.person = data);
    }
    
  }

  subscribeToAllGenders(): void {
    this._personService.getAllGenders()
      .subscribe((data: Gender[]) => this.genderDropdownList = data.map((g: Gender) => new Dropdown(g.GenderID, g.Name)));
  }

  UpdateGenderSelection(selectedValue: Dropdown) {

    this.person.Gender = new Gender();
    this.person.Gender.GenderID = selectedValue.id;
    this.person.Gender.Name = selectedValue.value;
  }

  SubmitForm(): void {
    this._personService.postPerson(this.person)
      .subscribe((personId: number) => {
        this.isSubmitted = true;
        if (personId > 0) {
          this.alertInfo.msgToDisplay = "The Entered details are stored successfully";
          this.alertInfo.alertType = AlertType.Success;
        } else {
          this.alertInfo.msgToDisplay = "Encountered error while storing..!! Please try later.";
          this.alertInfo.alertType = AlertType.Error;
        }
        this.person.PersonID = personId;
        this.alertInfo.showMsg = true;
        setTimeout(() => this._ngbActiveModel.close([this.person, this.crewCastRole]), 4000)
      }, (error: Response) => {
        this.alertInfo.showMsg = true;
        this.alertInfo.msgToDisplay = error.statusText;
        this.alertInfo.alertType = AlertType.Error;

        this.isSubmitted = false;
      });
  }

  isFormInvalid(): boolean {
    return ((this.person.DOB == null || this.person.DOB.toString() == "") || (this.person.Name == null || this.person.Name.trim() == ''));
  }

  cancelAction() {
    this._ngbActiveModel.dismiss();
  }

  updateHeader() {
    if (this.crewCastRole == CrewCastRole.Actor) {
      this.title = "Add Actor";
    } else {
      this.title = "Add Producer";
    }
  }
}
