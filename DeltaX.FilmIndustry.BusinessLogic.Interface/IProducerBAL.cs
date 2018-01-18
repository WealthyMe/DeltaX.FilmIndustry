using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeltaX.FilmIndustry.Entities;

namespace DeltaX.FilmIndustry.BusinessLogic.Interface
{
    public interface IProducerBAL
    {
        Producer Get(int producerId);
    }
}
