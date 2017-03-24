using Sdl.ECommerce.Api.Model;

namespace Sdl.ECommerce.Api.Service
{
    using Sdl.ECommerce.Api.Model;

    /// <summary>
    /// E-Commerce Edit Service
    /// </summary>
    public interface IEditService
    {
        /// <summary>
        /// Get In-Context edit menu items for current query
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        IEditMenu GetInContextMenuItems(Query query);
    }
}
