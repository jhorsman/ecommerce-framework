using Sdl.Web.Common.Models;

namespace Sdl.ECommerce.Dxa.Models
{
    [SemanticEntity(Vocab = CoreVocabulary, EntityName = "ECommerceProduct", Prefix = "e")]
    public class ECommerceProductReference : EntityModel
    {
        [SemanticProperty("e:productId")]
        public string ProductId { get; set; }

        [SemanticProperty("e:productRef")]
        public ECommerceEclItem ProductRef { get; set; }
    }
}
