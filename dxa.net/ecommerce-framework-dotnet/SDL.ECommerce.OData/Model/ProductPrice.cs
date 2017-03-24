using Sdl.ECommerce.Api.Model;

namespace Sdl.ECommerce.OData
{
    public partial class ProductPrice : IProductPrice
    {
        string IProductPrice.Currency
        {
            get
            {
                return this.Currency;
            }          
        }

        string IProductPrice.FormattedPrice
        {
            get
            {
                return this.FormattedPrice;
            }
           
        }

        float? IProductPrice.Price
        {
            get
            {
                return this.Price;
            }           
        }
    }
}
