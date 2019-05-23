using System;
using System.Composition.Hosting;

namespace Mef2DiExtensions.MefExtensions
{
    public class MefServiceProvider : IServiceProvider
    {
        private CompositionHost _container;

        public MefServiceProvider(CompositionHost container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            try
            {
                object impl = _container.GetExport(serviceType);
                return impl;
            }
            catch { }

            return null;
        }
    }
}
