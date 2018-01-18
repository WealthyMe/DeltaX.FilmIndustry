using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeltaX.FilmIndustry.UI.Models
{
    public class MovieModel : Movie
    {
        public IEnumerable<Actor> Actors{ get; set; }
        public Producer Producer { get; set; }

        public MovieModel() { }

        public MovieModel(Movie movie)
        {
            this.MovieId = movie.MovieId;
            this.Name = movie.Name;
            this.ProducerId = movie.ProducerId;
            this.Plot = movie.Plot;
            this.YearOfRelease = movie.YearOfRelease;
            this.ImageId = movie.ImageId;
            this.Image = movie.Image;
        }

        public Movie ToNewMovie()
        {
            Movie movie = new Movie()
            {
                MovieId = this.MovieId,
                Name=this.Name,
                ProducerId = this.ProducerId,
                Plot = this.Plot,
                YearOfRelease = this.YearOfRelease,
                ImageId = this.ImageId,
                Image = this.Image
            };
            return movie;
        }

       
    }
}