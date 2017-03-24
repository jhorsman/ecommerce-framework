using Sdl.ECommerce.Api.Model;

namespace Sdl.ECommerce.OData
{
    public partial class ProductVariantAttributeValueType : IProductVariantAttributeValueType
    {
        bool IProductVariantAttributeValueType.IsSelected
        {
            get
            {
                return (bool) this.IsSelected;
            }
        }

        bool IProductVariantAttributeValueType.IsAvailable
        {
            get
            {
                return (bool)this.IsApplicable;
            }
        }

    }
} 
