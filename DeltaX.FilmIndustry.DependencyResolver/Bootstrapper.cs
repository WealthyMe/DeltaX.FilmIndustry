using DeltaX.FilmIndustry.BusinessLogic;
using DeltaX.FilmIndustry.BusinessLogic.Interface;
using DeltaX.FilmIndustry.DataAccess;
using DeltaX.FilmIndustry.DataAccess.Interface;
using DeltaX.FilmIndustry.Entities;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Unity;

namespace DeltaX.FilmIndustry.DependencyResolver
{
    public class Bootstrapper
    {
        public static IDependencyResolver GetResolver()
        {
            try
            {
                IUnityContainer container = new UnityContainer();
                container.LoadConfiguration();
                UpdateUnityContainer(container);
                var resolver = new UnityResolver(container);
                return resolver;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static void UpdateUnityContainer(IUnityContainer container)
        {
            container.RegisterType<IPersonBAL, PersonBAL>();
            container.RegisterType<IActorBAL, ActorBAL>();
            container.RegisterType<IProducerBAL, ProducerBAL>();
            container.RegisterType<IPersonDAL<Person>, PersonDAL>();
            container.RegisterType<IActorsDAL, ActorsDAL>();
            container.RegisterType<IProducersDAL, ProducersDAL>();
        }
    }
}
