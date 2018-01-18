import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Movie } from '../../Models/movie';
import 'rxjs/add/operator/map';

@Injectable()
export class MovieService {
  private baseURL: string = location.origin;

  constructor(private _http: Http) { }

  getMovies(): Observable<Movie[]> {
    return this._http.get(this.baseURL + '/api/Movies' )
      .map((response: Response) => <Movie[]>response.json());
  }

  getMovie(movieId: string): Observable<Movie> {
    return this._http.get(this.baseURL + '/api/Movies/' + movieId)
      .map((response: Response) => <Movie>response.json());
  }

  postMovie(movieToPost: Movie): Observable<number> {
    return this._http.post(this.baseURL + '/api/Movies', movieToPost)
      .map((response: Response) => <number>response.json());
  }

  updateMovie(movieToUpdate: Movie): Observable<boolean> {
    return this._http.put(this.baseURL + '/api/Movies', movieToUpdate)
      .map((response: Response) => <boolean>response.json());
  }

}
