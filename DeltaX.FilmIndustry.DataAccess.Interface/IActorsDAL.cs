using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess.Interface
{
    public interface IActorsDAL : IPersonDAL<Actor>
    {
        void UpdateActors(int movieId, IEnumerable<MoviesCrewCast> actors);
    }
}
