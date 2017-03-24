using System.Collections.Generic;

namespace Sdl.ECommerce.Api.Model
{
    public interface IImageMapPromotion : IContentPromotion
    {
        IList<IContentArea> ContentAreas { get; }
    }
}
