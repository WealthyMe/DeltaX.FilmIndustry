using DeltaX.FilmIndustry.BusinessLogic.Interface;
using DeltaX.FilmIndustry.Entities;
using DeltaX.FilmIndustry.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeltaX.FilmIndustry.UI.Controllers
{
    public class MoviesController : BaseController
    {
        private readonly IMoviesBAL _moviesBAL;
        private readonly IActorBAL _actorBAL;
        private readonly IProducerBAL _producerBAL;

        public MoviesController(IMoviesBAL movesBAL, IActorBAL actorBAL, IProducerBAL producerBAL)
        {
            this._moviesBAL = movesBAL;
            this._actorBAL = actorBAL;
            this._producerBAL = producerBAL;
        }

        public IEnumerable<MovieModel> Get()
        {
            try
            {
                IEnumerable<Movie> movies = this._moviesBAL.GetAllMovies();
                IEnumerable<MovieModel> moviesModel = movies.Select(m =>
                {
                    MovieModel model = new MovieModel(m);
                    model.Producer = this._producerBAL.Get(model.ProducerId);
                    model.Actors = this._actorBAL.GetByMovie(m.MovieId);
                    return model;
                }).ToList();
                return moviesModel;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Movie Get(int id)
        {
            try
            {
                Movie movie = this._moviesBAL.GetMovieById(id);
                return movie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Post(MovieModel movie)
        {
            try
            {
                movie.ProducerId = movie.Producer != null ? movie.Producer.PersonID : 0;
                Movie movieToStore = movie.ToNewMovie();
                this._moviesBAL.AddMovie(movieToStore);
                this._actorBAL.UpdateActors(movieToStore.MovieId, movie.Actors);
                return movieToStore.MovieId;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool Put(MovieModel movie)
        {
            try
            {
                movie.Person = movie.Producer;
                this._moviesBAL.UpdateMovie(movie);
                this._actorBAL.UpdateActors(movie.MovieId, movie.Actors);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
