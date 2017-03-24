using System.Collections.Generic;

namespace Sdl.ECommerce.Api.Model
{
    public interface IProductVariantAttributeType
    {
        string Id { get; }

        string Name { get; }

        IList<IProductVariantAttributeValueType> Values { get; }

    }
}
