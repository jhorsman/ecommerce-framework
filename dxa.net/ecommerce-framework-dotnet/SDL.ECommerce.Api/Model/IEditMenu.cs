using System.Collections.Generic;

namespace Sdl.ECommerce.Api.Model
{
    public interface IEditMenu
    {
        string Title { get; }
        IList<IMenuItem> MenuItems { get; }
    }
}