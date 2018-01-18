using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using DeltaX.FilmIndustry.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess
{
    public class ActorsDAL : IActorsDAL
    {
        public void Add(Person person)
        {
            throw new NotImplementedException();
        }

        public Actor Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetAll(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> GetAllGenders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Actor> GetByMovie(int movieId)
        {
            try
            {
                IEnumerable<Actor> castedActors;
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    IEnumerable<MoviesCrewCast> castedActorsCrew = dbContext.MoviesCrewCasts.Where(mcc => mcc.MovieId == movieId
                                                                                                        && mcc.CrewCastRoleId == (int)Constants.CrewCastRole.Actor);
                    if (castedActorsCrew.Count() > 0)
                    {
                        castedActors = castedActorsCrew.Join(dbContext.Persons,c=>c.PersonId,k=>k.PersonID,(c,k)=>new Actor(k)).ToList();
                    }
                    else
                    {
                        castedActors = new List<Actor>();
                    }

                }
                return castedActors;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void UpdateActors(int movieId, IEnumerable<MoviesCrewCast> actors)
        {
            try
            {
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    IEnumerable<MoviesCrewCast> moviesActors = dbContext.MoviesCrewCasts.Where(c => c.MovieId == movieId);
                    dbContext.MoviesCrewCasts.RemoveRange(moviesActors);
                    dbContext.MoviesCrewCasts.AddRange(actors);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
