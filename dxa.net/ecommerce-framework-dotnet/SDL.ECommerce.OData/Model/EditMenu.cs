using Sdl.ECommerce.Api.Model;

using System.Collections.Generic;
using System.Linq;

namespace Sdl.ECommerce.OData
{
    public partial class EditMenu : IEditMenu
    {
        IList<IMenuItem> IEditMenu.MenuItems
        {
            get
            {
                return this.MenuItems.Cast<IMenuItem>().ToList();
            }
        }
    }
}
