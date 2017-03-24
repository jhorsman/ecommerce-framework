using Sdl.ECommerce.Api.Service;

namespace Sdl.ECommerce.Api
{
    using Sdl.ECommerce.Api.Service;

    public interface IECommerceClient
    {
        IProductCategoryService CategoryService { get; }
        IProductQueryService QueryService { get; }
        IProductDetailService DetailService { get; }
        ICartService CartService { get; }
        IEditService EditService { get; }
    }
}
