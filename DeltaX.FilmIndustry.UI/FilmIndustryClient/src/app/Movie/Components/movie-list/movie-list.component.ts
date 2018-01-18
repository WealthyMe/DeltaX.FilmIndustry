import { Component, OnInit } from '@angular/core';
import { ScrollTo } from 'ng2-scroll-to';

import { Movie } from '../../../Models/movie';
import { MovieService } from '../../Services/movie.service';
import { Actor } from '../../../Models/actor';

@Component({
  selector: 'app-movie-list',
  templateUrl: './movie-list.component.html',
  styleUrls: ['./movie-list.component.css']
})
export class MovieListComponent implements OnInit {
  public movieToEdit: Movie;
  public isVisible: boolean;
  public movies: Array<Movie>;

  constructor(private _movieService: MovieService) { }

  ngOnInit() {
    this.fetchAndListMovies();
  }

  fetchAndListMovies() {
    this._movieService.getMovies()
      .subscribe(moviesFromDB => this.movies = moviesFromDB);
  }

  addEditMovieNotifier(editableMovie: Movie) {
    if (editableMovie == null) {
      editableMovie = new Movie();
    }
    this.movieToEdit = editableMovie;
    this.isVisible = true;
    
  }

  displayActorsName(actors: Actor[]): string {
    if (actors != null && actors.length > 0) {
      return actors.map(function (a) { return a.Name; }).join(", ");
    } else {
      return "No Actors";
    }
  }

  updateMoviesList(movie: Movie) {
    if (movie == null) {
      this.isVisible = false;
      this.fetchAndListMovies();
      return;
    }
    if (this.movies.find(m => m.MovieId == movie.MovieId) == null) {
      this.movies.push(movie);
    }
    setTimeout(() => this.isVisible = false, 4000);
  }
}
