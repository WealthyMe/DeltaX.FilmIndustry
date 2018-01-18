using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess
{
    public class ProducersDAL : IProducersDAL
    {
        public void Add(Person person)
        {
            throw new NotImplementedException();
        }

        public Producer Get(int id)
        {
            try
            {
                Producer producer;
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    producer = new Producer(dbContext.Persons.FirstOrDefault(p => p.PersonID == id));
                }
                return producer;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Producer> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producer> GetAll(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Gender> GetAllGenders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Producer> GetByMovie(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
