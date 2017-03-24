using Sdl.Web.Common.Models;
using Sdl.ECommerce.Api.Model;

namespace Sdl.ECommerce.Dxa.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "CartWidget", Prefix = "e")]
    public class CartWidget : EntityModel
    {
        [SemanticProperty("e:_self")]
        public string CartPageLink { get; set; }

        [SemanticProperty("e:checkoutLink")]
        public Link CheckoutLink { get; set; }

        [SemanticProperty(IgnoreMapping = true)]
        public ICart Cart { get; set; }
    }
}