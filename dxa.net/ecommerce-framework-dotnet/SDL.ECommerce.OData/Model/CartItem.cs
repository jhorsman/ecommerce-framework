using Sdl.ECommerce.Api.Model;

namespace Sdl.ECommerce.OData
{
    public partial class CartItem : ICartItem
    {
        IProductPrice ICartItem.Price
        {
            get
            {
                return this.Price;
            }
        }

        IProduct ICartItem.Product
        {
            get
            {
                return this.Product;
            }
        }

        int ICartItem.Quantity
        {
            get
            {
                return (int)this.Quantity;
            }
        }
    }
}
