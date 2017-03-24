﻿using System;
using System.Collections.Generic;

using Sdl.ECommerce.Api.Model;

namespace Sdl.ECommerce.OData
{
    public partial class ProductSummary : IProduct
    {
        IProductPrice IProduct.Price
        {
            get
            {
                return this.Price;
            }
        }

        /***** METHODS NOT AVAILABLE FOR PRODUCT SUMMARY ONLY IN DETAIL PRODUCT INFO ******/

        public IDictionary<string, object> Attributes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Description
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string PrimaryImageUrl
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<ICategory> Categories
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IBreadcrumb> Breadcrumbs
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IPromotion> Promotions
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IProductVariant> Variants
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IProductVariantAttribute> VariantAttributes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public IList<IProductVariantAttributeType> VariantAttributeTypes
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public VariantLinkType VariantLinkType
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
