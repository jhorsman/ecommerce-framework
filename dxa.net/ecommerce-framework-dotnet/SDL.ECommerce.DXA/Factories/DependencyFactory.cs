﻿namespace Sdl.ECommerce.Dxa.Factories
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Sdl.ECommerce.Dxa.Providers;
    using Sdl.ECommerce.Dxa.Servants;

    using Sdl.ECommerce.Api;

    public class DependencyFactory
    {
        private static ThreadLocal<DependencyFactory> _dependencyFactory;

        public static DependencyFactory Current => _dependencyFactory?.Value ?? (_dependencyFactory = new ThreadLocal<DependencyFactory>(() => new DependencyFactory())).Value;

        public T Resolve<T>()
        {
            var dependencies = new Dictionary<Type, object>
                                   {
                                           { typeof(IECommerceClient), new Lazy<IECommerceClient>(() => TryResolveDependency<IECommerceClient>() ?? ECommerceContext.Client) },
                                           { typeof(IECommerceLinkResolver), new Lazy<IECommerceLinkResolver>(() => TryResolveDependency<IECommerceLinkResolver>() ?? new DXALinkResolver()) },
                                           { typeof(IHttpContextServant), new Lazy<IHttpContextServant>(() => TryResolveDependency<IHttpContextServant>() ?? new HttpContextServant()) },
                                           { typeof(IPageModelServant), new Lazy<IPageModelServant>(() => TryResolveDependency<IPageModelServant>() ?? new PageModelServant()) },
                                           { typeof(IPathServant), new Lazy<IPathServant>(() => TryResolveDependency<IPathServant>() ?? new PathServant()) }
                                   };

            var dependency = dependencies[typeof(T)];

            return dependency != null ? ((Lazy<T>)dependency).Value : default(T);
        }

        private static T TryResolveDependency<T>()
        {
            var dependency = DependencyResolverProvider.Dependencies.Invoke(typeof(T));

            if (dependency == null)
            {
                return default(T);
            }

            return (T)dependency;
        }
    }
}