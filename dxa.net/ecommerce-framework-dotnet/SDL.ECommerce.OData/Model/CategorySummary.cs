using Sdl.ECommerce.Api.Model;
using System;
using System.Collections.Generic;

namespace Sdl.ECommerce.OData
{
    public partial class CategorySummary : ICategory
    {
        public IList<ICategory> Categories
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ICategory Parent
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
