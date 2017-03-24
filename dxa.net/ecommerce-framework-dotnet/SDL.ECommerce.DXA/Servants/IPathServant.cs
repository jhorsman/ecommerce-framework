namespace Sdl.ECommerce.Dxa.Servants
{
    using System.Collections.Generic;

    using Sdl.ECommerce.Api.Model;

    public interface IPathServant
    {
        IEnumerable<string> GetSearchPath(string url, ICategory category);

        IEnumerable<string> GetSearchPath(string productSeoId, IProduct product);
    }
}