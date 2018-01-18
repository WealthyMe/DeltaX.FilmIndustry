using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.BusinessLogic.Interface
{
    public interface IPersonBAL
    {
        IEnumerable<Gender> GetAllGenders();
        Person Get(int pId);
        void Post(Person person);
        IEnumerable<Person> GetWildCardSearchList(string name);
    }
}
