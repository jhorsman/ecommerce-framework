﻿using Sdl.Web.Delivery.DiscoveryService;
using Sdl.Web.Delivery.Service;
using Sdl.ECommerce.Api;
using Sdl.ECommerce.Api.Service;
using System;

namespace Sdl.ECommerce.OData
{
    // Temporary solution for the client config
    // TODO: Use the standard approach
    //
    class SimpleServiceConfiguration : IServiceConfiguration
    {

        public string ClientId
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string ClientSecret
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public bool IsOAuthEnabled
        {
            get
            {
                return false;
            }
        }

        public Uri ServiceEndpoint
        {
            get; set;
            
        }

        public int Timeout
        {
            get; set;
        }

        public Uri TokenServiceEndpoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }

    /// <summary>
    /// ECommerce Client. Is the single entry point for all kind interactions with the E-Commerce OData micro service.
    /// </summary>
    public class ECommerceClient : IECommerceClient
    {
        private readonly Func<Type, object> dependencies;
        private readonly IServiceConfiguration serviceConfiguration;
        private IECommerceODataV4Service odataService;
        private IProductCategoryService categoryService;
        private IProductQueryService queryService;
        private IProductDetailService detailService;
        private ICartService cartService;
        private IEditService editService;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="endpointAddress">Endpoing address for the ECommerce OData service.</param>
        /// <param name="locale">Current locale.</param>
        /// <param name="dependencies">Optional list of dependencies.</param>
        public ECommerceClient(
            string endpointAddress, 
            string locale, 
            Func<Type, object> dependencies = null)
        {
            this.serviceConfiguration = new SimpleServiceConfiguration
                                            {
                                                ServiceEndpoint = new Uri(endpointAddress + "/" + locale),
                                                Timeout = 1000
                                            };

            this.dependencies = dependencies;
        }
        
        /// <summary>
        /// Get category service
        /// </summary>
        public IProductCategoryService CategoryService
        {
            get
            {
                if (categoryService == null)
                {
                    categoryService = this.Resolve<IProductCategoryService>() ?? new ProductCategoryService(ODataV4Service);
                }

                return categoryService;
            }
        }

        /// <summary>
        /// Get query service
        /// </summary>
        public IProductQueryService QueryService
        {
            get
            {
                if (queryService == null)
                {
                    queryService = this.Resolve<IProductQueryService>() ?? new ProductQueryService(ODataV4Service);
                }

                return queryService;
            }
        }

        /// <summary>
        /// Get product detail service
        /// </summary>
        public IProductDetailService DetailService
        {
            get
            {
                if ( detailService == null )
                {
                    detailService = this.Resolve<IProductDetailService>() ?? new ProductDetailService(ODataV4Service);
                }

                return detailService;
            }
        }

        /// <summary>
        /// Get cart service
        /// </summary>
        public ICartService CartService
        {
            get
            {
                if ( cartService == null )
                {
                    cartService = this.Resolve<ICartService>() ?? new CartService(ODataV4Service);
                }

                return cartService;
            }
        }

        /// <summary>
        /// Get edit service
        /// </summary>
        public IEditService EditService
        {
            get
            {
                if (editService == null)
                {
                    editService = this.Resolve<IEditService>() ?? new EditService(ODataV4Service);
                }

                return editService;
            }
        }

        private IOAuthTokenProvider TokenProvider
        {
            get
            {
                return this.Resolve<IOAuthTokenProvider>() ?? DiscoveryServiceProvider.DefaultTokenProvider;
            }
        }
        
        private IECommerceODataV4Service ODataV4Service
        {
            get
            {
                if (odataService == null)
                {
                    odataService = this.Resolve<IECommerceODataV4Service>() ?? new ECommerceODataV4Service(new SDLECommerce(serviceConfiguration.ServiceEndpoint), serviceConfiguration, TokenProvider);
                }

                return odataService;
            }
        }

        private T Resolve<T>()
        {
            var dependency = dependencies?.Invoke(typeof(T));

            if (dependency == null)
            {
                return default(T);
            }

            return (T)dependency;
        }
    }
}