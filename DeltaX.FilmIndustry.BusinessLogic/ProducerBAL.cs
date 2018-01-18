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
    public class ProducerBAL : IProducerBAL
    {
        public readonly IProducersDAL _producerDAL;

        public ProducerBAL(IProducersDAL producerDAL)
        {
            this._producerDAL = producerDAL;
        }

        public Producer Get(int producerId)
        {
            try
            {
                return this._producerDAL.Get(producerId);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
