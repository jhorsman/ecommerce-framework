namespace Sdl.ECommerce.Dxa.Servants
{
    using System.Collections.Generic;

    using Sdl.Web.Common.Interfaces;
    using Sdl.Web.Common.Models;

    using Query = Sdl.ECommerce.Api.Model.Query;

    public interface IPageModelServant
    {
        PageModel ResolveTemplatePage(IEnumerable<string> urlSegments, IContentProvider contentProvider);

        void SetTemplatePage(PageModel model);

        void GetQueryContributions(PageModel templatePage, Query query);

        PageModel GetNotFoundPageModel(IContentProvider contentProvider);
    }
}