import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Person } from '../../Models/person';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { Gender } from '../../Models/gender';

@Injectable()
export class PersonService {
 
  private baseURL: string = location.origin;
  constructor(private _http: Http) { }

  getPersonById(personId: string): Observable<Person> {
    return this._http.get(this.baseURL + '/api/Persons/' + personId)
      .map((response: Response) => <Person>response.json());
  }

  getAllGenders(): Observable<Gender[]> {
    return this._http.get(this.baseURL + '/api/Persons/GetAllGenders')
      .map((response: Response) => <Gender[]>response.json());
  }

  postPerson(person: Person): Observable<number> {
    return this._http.post(this.baseURL + '/api/Persons/Post', person)
      .map((data: Response) => <number>data.json());
  }

  updatePerson(person: Person): Observable<boolean> {
    return this._http.post(this.baseURL + '/api/Persons/Put', person)
      .map((data: Response) => <boolean>data.json());
  }
}
