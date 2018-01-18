using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess.Interface
{
   public interface IMoviesDAL
    {
        Movie GetMovieById(int id);
        IEnumerable<Movie> GetAllMovies();
        void AddMovie(Movie movieToAdd);
        void UpdateMovie(Movie movieToUpdate);
    }
}
