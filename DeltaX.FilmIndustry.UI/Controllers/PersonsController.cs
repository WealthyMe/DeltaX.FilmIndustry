using DeltaX.FilmIndustry.BusinessLogic.Interface;
using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeltaX.FilmIndustry.UI.Controllers
{
    public class PersonsController : BaseController
    {
        private readonly IPersonBAL _personBAL;

        public PersonsController(IPersonBAL personBAL)
        {
            this._personBAL = personBAL;
        }

        public Person Get(int id)
        {
            try
            {
               return this._personBAL.Get(id);
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
                return this._personBAL.GetAllGenders();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Post(Person person)
        {
            try
            {
                this._personBAL.Post(person);
                return person.PersonID ;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Person> GetWildCardSearchResult(string name)
        {
            try
            {
                return this._personBAL.GetWildCardSearchList(name);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
