using DeltaX.FilmIndustry.BusinessLogic.Interface;
using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.BusinessLogic
{
    public class MoviesBAL : IMoviesBAL
    {
        private readonly IMoviesDAL _moviesDAL;

        public MoviesBAL(IMoviesDAL moviesDAL)
        {
            this._moviesDAL = moviesDAL;
        }

        public void AddMovie(Movie movieToAdd)
        {
            try
            {
                this._moviesDAL.AddMovie(movieToAdd);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Movie> GetAllMovies()
        {
            try
            {
                return this._moviesDAL.GetAllMovies();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Movie GetMovieById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            try
            {
                Movie originalMovie = this._moviesDAL.GetMovieById(movieToUpdate.MovieId);
                this.UpdateTheMovieMapping(movieToUpdate, originalMovie);
                this._moviesDAL.UpdateMovie(originalMovie);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void UpdateTheMovieMapping(Movie movieToUpdate, Movie originalMovie)
        {
            originalMovie.Name = movieToUpdate.Name;
            originalMovie.Plot = movieToUpdate.Plot;
            originalMovie.YearOfRelease = movieToUpdate.YearOfRelease;

            originalMovie.ProducerId= movieToUpdate.ProducerId == 0 ? movieToUpdate.Person.PersonID: movieToUpdate.ProducerId;
        }
    }
}
