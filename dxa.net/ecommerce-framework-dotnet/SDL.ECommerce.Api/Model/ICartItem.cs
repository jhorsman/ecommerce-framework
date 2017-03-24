namespace Sdl.ECommerce.Api.Model
{
    public interface ICartItem
    {
        IProductPrice Price { get; }
        IProduct Product { get; }
        int Quantity { get; }
    }
}
