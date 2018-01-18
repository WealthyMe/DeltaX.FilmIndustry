import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { NgbModal, NgbActiveModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

import { Movie } from '../../../Models/movie';
import { Actor } from '../../../Models/actor';
import { Producer } from '../../../Models/producer';
import { Alert, AlertType } from '../../../Models/alert';
import { MovieService } from '../../Services/movie.service';
import { AddEditPersonComponent } from '../../../Person/Components/add-edit-person/add-edit-person.component';
import { CrewCastRole } from '../../../Models/crew-cast-role';
import { Person } from '../../../Models/person';

@Component({
  selector: 'app-add-edit-movie',
  templateUrl: './add-edit-movie.component.html',
  styleUrls: ['./add-edit-movie.component.css']
})
export class AddEditMovieComponent implements OnInit {
  @Output() public savedNotification: EventEmitter<Movie> = new EventEmitter<Movie>();
  @Input() public movie: Movie = new Movie();
  public alertInfo: Alert = new Alert();
  isSubmitted: boolean;

  constructor(private _movieService: MovieService, private _ngbModel: NgbModal) {
    this.movie.MovieId = 0;
  }

  ngOnInit() {
  }

  addSelectedActor(selectedActor: Actor): void {
    if (this.movie.Actors.findIndex(a => a.PersonID == selectedActor.PersonID) < 0) {
      this.movie.Actors.push(selectedActor);
    } else {
      this.alertInfo.alertType = AlertType.Warning;
      this.alertInfo.msgToDisplay = 'This Actor is already Acting in this film.';
      this.alertInfo.showMsg = true;
    }
  }

  removeSelectedActors(removedActor: Actor): void {
    this.movie.Actors = this.movie.Actors.filter(function (actor) {
      return actor.PersonID !== removedActor.PersonID;
    });
  }

  addSelectedProducer(selectedProducer: Producer): void {
    this.movie.Producer = selectedProducer;
  }

  submitMovie(): void {
    if (this.movie.MovieId == null) {
      this._movieService.postMovie(this.movie)
        .subscribe((movieId) => {
          this.alertInfo.alertType = AlertType.Success;
          this.alertInfo.msgToDisplay = "This Movie is created Successfully..!!";
          this.alertInfo.showMsg = true;
          this.movie.MovieId = movieId;
          this.isSubmitted = true;
          this.savedNotification.emit(this.movie);
        });
    } else {
      this._movieService.updateMovie(this.movie)
        .subscribe((isCompleted) => {
          this.alertInfo.alertType = AlertType.Success;
          this.alertInfo.msgToDisplay = "This Movie is updated Successfully..!!";
          this.alertInfo.showMsg = true;
          this.isSubmitted = true;
          this.savedNotification.emit(this.movie);
        });
    }
  }

  openAddPersonModel(personType: CrewCastRole) {
    let options: NgbModalOptions;
    const modelRef = this._ngbModel.open(AddEditPersonComponent);
    modelRef.componentInstance.crewCastRole = personType;
    modelRef.result.then((addedPerson) => { this.addNewPerson(addedPerson[0], addedPerson[1]) });
    return false;
  }

  isFormInvalid(): boolean {
    return ((this.movie.Name == null || this.movie.Name.trim() == '') || (this.movie.Producer.PersonID == 0) || (this.movie.Actors.length == 0));
  }

  addNewPerson(newPerson: Person, crewCastRole: CrewCastRole) {
    if (crewCastRole == CrewCastRole.Actor) {
      this.addSelectedActor(newPerson);
    } else {
      this.addSelectedProducer(newPerson);
    }
  }

  cancelAction() {
    this.savedNotification.emit(null);
  }
}
