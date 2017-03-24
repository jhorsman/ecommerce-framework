namespace Sdl.ECommerce.Dxa.Servants
{
    using System.Collections.Generic;
    using System.Web;

    using Sdl.ECommerce.Api;

    public interface IHttpContextServant
    {
        IList<FacetParameter> GetFacetParametersFromRequest(HttpContextBase httpContext);

        int GetStartIndex(HttpContextBase httpContext);
    }
}