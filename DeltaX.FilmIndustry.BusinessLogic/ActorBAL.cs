using DeltaX.FilmIndustry.BusinessLogic.Interface;
using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using DeltaX.FilmIndustry.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.BusinessLogic
{
    public class ActorBAL : IActorBAL
    {
        public readonly IActorsDAL _actorDAL;

        public ActorBAL(IActorsDAL actorDAL)
        {
            this._actorDAL = actorDAL;
        }

        public IEnumerable<Actor> GetByMovie(int movieId)
        {
            try
            {
                return this._actorDAL.GetByMovie(movieId);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateActors(int movieId, IEnumerable<Actor> actors)
        {
            try
            {
                IEnumerable<MoviesCrewCast> actorsCasted = this.GetMoviesEnactedActors(movieId, actors);
                this._actorDAL.UpdateActors(movieId, actorsCasted);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private IEnumerable<MoviesCrewCast> GetMoviesEnactedActors(int movieId, IEnumerable<Actor> actors)
        {
            List<MoviesCrewCast> actorsList = new List<MoviesCrewCast>();
            foreach (Actor actor  in actors)
            {
                actorsList.Add(new MoviesCrewCast() { CrewCastRoleId = (int)Constants.CrewCastRole.Actor, MovieId = movieId, PersonId = actor.PersonID });
            }
            return actorsList;
        }
    }
}
