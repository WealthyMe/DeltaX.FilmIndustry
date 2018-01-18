using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess
{
    public class MoviesDAL : IMoviesDAL
    {

        public void AddMovie(Movie movieToAdd)
        {
            try
            {
                using (FilmIndustryDB filmIndustryDBContext = new FilmIndustryDB())
                {
                    filmIndustryDBContext.Movies.Add(movieToAdd);
                    filmIndustryDBContext.SaveChanges();
                }
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
                IEnumerable<Movie> movies = null;
                using (FilmIndustryDB filmIndustryDBContext = new FilmIndustryDB())
                {
                    movies = filmIndustryDBContext.Movies.ToList();
                }
                return movies;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Movie GetMovieById(int id)
        {
            try
            {
                Movie movie = null;
                using (FilmIndustryDB filmIndustryDBContext = new FilmIndustryDB())
                {
                    movie = filmIndustryDBContext.Movies.FirstOrDefault(m => m.MovieId == id);
                }
                return movie;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateMovie(Movie movieToUpdate)
        {
            try
            {
                using (FilmIndustryDB filmIndustryDBContext = new FilmIndustryDB())
                {
                    filmIndustryDBContext.Entry(movieToUpdate).State = EntityState.Modified;
                    filmIndustryDBContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
