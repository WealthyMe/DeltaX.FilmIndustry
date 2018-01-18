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
    public class PersonBAL : IPersonBAL
    {
        private readonly IPersonDAL<Person> _personDAL;

        public PersonBAL(IPersonDAL<Person> personDAL)
        {
            this._personDAL = personDAL;
        }

        public Person Get(int pId)
        {
            try
            {
                return this._personDAL.Get(pId);
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
                return this._personDAL.GetAllGenders();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Person> GetWildCardSearchList(string name)
        {
            try
            {
                return this._personDAL.GetAll(name);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Post(Person person)
        {
            try
            {
                person.GenderID = person.Gender.GenderID;
                person.Gender = null;
                this._personDAL.Add(person);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
