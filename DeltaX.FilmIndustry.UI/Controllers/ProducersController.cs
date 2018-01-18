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
    public class ProducersController : BaseController
    {
        private readonly IProducerBAL _producerBAL;

        public ProducersController(IProducerBAL producerBAL)
        {
            this._producerBAL = producerBAL;
        }

        // GET: Producers
        public IEnumerable<Producer> Get()
        {
            return null;
        }

        // GET: api/Producers/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Producers
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Producers/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Producers/5
        public void Delete(int id)
        {
        }
    }
}
