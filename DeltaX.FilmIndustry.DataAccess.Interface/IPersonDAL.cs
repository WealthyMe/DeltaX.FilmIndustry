using DeltaX.FilmIndustry.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeltaX.FilmIndustry.DataAccess.Interface
{
    public interface IPersonDAL<T> where T : Person
    {
        IEnumerable<T> GetByMovie(int movieId);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<Gender> GetAllGenders();
        IEnumerable<T> GetAll(string name);
        void Add(Person person);
    }
}
