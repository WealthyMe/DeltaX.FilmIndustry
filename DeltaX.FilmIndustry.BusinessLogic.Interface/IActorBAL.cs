using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.BusinessLogic.Interface
{
    public interface IActorBAL
    {
        void UpdateActors(int movieId, IEnumerable<Actor> actors);
        IEnumerable<Actor> GetByMovie(int movieId);
    }
}
