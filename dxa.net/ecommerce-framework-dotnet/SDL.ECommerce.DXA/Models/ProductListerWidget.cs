using Sdl.Web.Common.Models;
using Sdl.ECommerce.Api.Model;

using System.Collections.Generic;

namespace Sdl.ECommerce.Dxa.Models
{
    using Sdl.ECommerce.Api;

    using Query = Sdl.ECommerce.Api.Model.Query;

    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "ProductListerWidget", Prefix = "e")]
    public class ProductListerWidget : EntityModel, IQueryContributor
    {
        [SemanticProperty("e:category")]
        public ECommerceCategoryReference CategoryReference { get; set; }

        [SemanticProperty("e:viewSize")]
        public int? ViewSize { get; set; }

        [SemanticProperty("e:viewType")]
        public string ViewType { get; set; }

        [SemanticProperty("e:filterAttributes")]
        public List<ECommerceFilterAttribute> FilterAttributes { get; set; }

        [SemanticProperty(IgnoreMapping = true)]
        public IList<IProduct> Items { get; set; }
    
        [SemanticProperty(IgnoreMapping = true)]
        public ListerNavigationData NavigationData { get; set; }

        public void ContributeToQuery(Query query)
        {
            if ( ViewSize != null )
            {
                query.ViewSize = ViewSize;
            }
            if ( FilterAttributes != null )
            {
                foreach ( var filterAttribute in FilterAttributes )
                {
                    query.Facets.Add(new FacetParameter(filterAttribute.Name + "_hidden", filterAttribute.Value));
                }
            } 
          
        }
    }
}
