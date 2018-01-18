using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess
{
    public class PersonDAL : IPersonDAL<Person>
    {
        public void Add(Person person)
        {
            try
            {
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    dbContext.Persons.Add(person);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Person Get(int id)
        {
            try
            {
                Person person = null;
                using (FilmIndustryDB filmIndustryContext = new FilmIndustryDB())
                {
                    person = filmIndustryContext.Persons.FirstOrDefault(p => p.PersonID == id);
                }
                return person;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll(string name)
        {
            try
            {
                IEnumerable<Person> persons = null;
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    persons = dbContext.Persons.Where(p => p.Name.ToLower().Contains(name.ToLower())).OrderBy(p => p.Name).Take(5).ToList();
                }
                return persons;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Gender> GetAllGenders()
        {
            try
            {
                IEnumerable<Gender> genders;
                using (FilmIndustryDB dbContext = new FilmIndustryDB())
                {
                    genders = dbContext.Genders.ToList();
                }
                return genders;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Person> GetByMovie(int movieId)
        {
            throw new NotImplementedException();
        }
    }
}
