using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace DeltaX.FilmIndustry.DependencyResolver
{
    public class UnityResolver : IDependencyResolver, IDisposable
    {
        #region Private Fields
        private readonly IUnityContainer _container;
        #endregion

        #region Constructors
        public UnityResolver(IUnityContainer container)
        {
            this._container = container ?? throw new ArgumentNullException("container");
        }
        #endregion

        #region Public methods
        #region IDependencyResolver Implementation
        public IDependencyScope BeginScope()
        {
            try
            {
                IUnityContainer childContainer = this._container.CreateChildContainer();
                return new UnityResolver(childContainer);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return this._container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
        #endregion

        #region IDisposable Implementation
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            this._container.Dispose();
        }
        #endregion
        #endregion
    }
}
