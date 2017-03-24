﻿using Sdl.Web.Common;
using Sdl.Web.Common.Logging;
using Sdl.Web.Common.Models;
using Sdl.Web.Mvc.Configuration;
using Sdl.Web.Mvc.Controllers;
using Sdl.Web.Mvc.Formats;

using Sdl.ECommerce.Api;
using Sdl.ECommerce.Api.Model;

using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

using Sdl.ECommerce.Dxa.Factories;
using Sdl.ECommerce.Dxa.Servants;

namespace Sdl.ECommerce.Dxa.Controllers
{
    using Sdl.ECommerce.Dxa.Factories;
    using Sdl.ECommerce.Dxa.Servants;

    using Query = Sdl.ECommerce.Api.Model.Query;

    /// <summary>
    /// Abstract base class for all E-Commerce page controllers
    /// </summary>
    public abstract class AbstractECommercePageController : BaseController
    {
        protected IPageModelServant PageModelServant;

        protected AbstractECommercePageController()
        {
            PageModelServant = DependencyFactory.Current.Resolve<IPageModelServant>();
        }

        /// <summary>
        /// Resolve Template Page
        /// </summary>
        /// <param name="searchPath"></param>
        /// <returns></returns>
        protected PageModel ResolveTemplatePage(IList<string> searchPath)
        {
            PageModel templatePage = null;
            foreach (var templatePagePath in searchPath)
            {
                try
                {
                    Log.Info("Trying to find page template: " + templatePagePath);
                    templatePage = ContentProvider.GetPageModel(templatePagePath, WebRequestContext.Localization);
                }
                catch (DxaItemNotFoundException) {}
                if (templatePage != null)
                {
                    break;
                }
            }
            if (templatePage != null)
            {
                WebRequestContext.PageModel = templatePage;
            }
            return templatePage;
        }

        /// <summary>
        /// Extract all facet parameters from the request
        /// </summary>
        /// <returns></returns>
        protected IList<FacetParameter> GetFacetParametersFromRequest()
        {
            var facetParameters = new List<FacetParameter>();

            var queryParams = HttpContext.Request.QueryString;
            foreach ( var key in queryParams.Keys ) // TODO: Use AllKeys here
            {
                string paramName = key.ToString(); 
                if ( !paramName.Equals("q") && !paramName.Equals("startIndex") )
                {
                    // TODO:  Use a global facet map here instead to validate against
                    var paramValue = queryParams[paramName];
                    facetParameters.Add(new FacetParameter(paramName, paramValue));
                }
            }
               
            return facetParameters;
        }

        /// <summary>
        /// Go through all entities on the page (excluding header & footer) and check for contributions to the E-Commerce query (such as view size, filter attributes etc).
        /// </summary>
        /// <param name="templatePage"></param>
        /// <param name="query"></param>
        protected void GetQueryContributions(PageModel templatePage, Query query)
        {
            foreach  (var region in templatePage.Regions)
            {
                if (!region.Name.Equals("Header") && !region.Name.Equals("Footer"))
                {
                    foreach (EntityModel entity in region.Entities)
                    {
                        if (entity is IQueryContributor)
                        {
                            ((IQueryContributor) entity).ContributeToQuery(query);
                        }
                    }
                }
            }
        }

        protected ActionResult View(PageModel templatePage)
        {
            SetupViewData(templatePage);
            ControllerContext.RouteData.Values["controller"] = "Page";
            return View(templatePage.MvcData.ViewName, templatePage);
        }

        protected int GetStartIndex()
        {
            int startIndex = 0;
            var startIndexStr = HttpContext.Request.QueryString["startIndex"];
            if ( startIndexStr != null )
            {
                startIndex = Int32.Parse(startIndexStr);
            }
            return startIndex;
        }

        /// <summary>
        /// Render a file not found page
        /// </summary>
        /// <returns>404 page or HttpException if there is none</returns>
        [FormatData]
        protected virtual ActionResult NotFound()
        {
            using (new Tracer())
            {
                PageModel pageModel = PageModelServant.GetNotFoundPageModel(ContentProvider);

                SetupViewData(pageModel);
                ViewModel model = EnrichModel(pageModel) ?? pageModel;
                Response.StatusCode = 404;
                return View(pageModel);
            }
        }

    }
}