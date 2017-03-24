using Sdl.Web.Common.Models;
using Sdl.Web.Mvc.Configuration;
using Sdl.Dxa.Modules.Navigation.Models;

namespace Sdl.Dxa.Modules.Navigation
{
    using Sdl.Dxa.Modules.Navigation.Models;

    public class NavigationAreaRegistration : BaseAreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Navigation";
            }
        }

        protected override void RegisterAllViewModels()
        {
            // Entity views
            //
            RegisterViewModel("NavigationSection", typeof(NavigationSection));

            // Region views
            //
            RegisterViewModel("MegaNavigation", typeof(RegionModel));
        }
    }
}