using DeltaX.FilmIndustry.DependencyResolver;
using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Unity;

namespace DeltaX.FilmIndustry.UI
{
    public static class ContainerConfig
    {
        public static void RegisterContainer(HttpConfiguration config)
        {

            // Your Dependencies Here
            var resolver = Bootstrapper.GetResolver() ;
            config.DependencyResolver = resolver;
        }
    }
}