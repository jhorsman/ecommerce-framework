using Sdl.ECommerce.Api.Model;

namespace Sdl.ECommerce.Api.Service
{
    using Sdl.ECommerce.Api.Model;

    /// <summary>
    /// E-Commerce Product Query Service
    /// </summary>
    public interface IProductQueryService
    {
        /// <summary>
        /// Submit the query to the query service
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IProductQueryResult Query(Query query);
    }
}
