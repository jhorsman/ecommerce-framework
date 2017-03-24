﻿using Sdl.Web.Mvc.Configuration;
using Sdl.ECommerce.Dxa.Models;
using System.Web.Mvc;

namespace Sdl.ECommerce.Dxa.Example.Views
{
    using Sdl.ECommerce.Dxa.Models;

    public class ECommerceAreaRegistration : BaseAreaRegistration
    {
        // TODO: Use Razor generator here??
        // http://stackoverflow.com/questions/12911006/asp-net-mvc-4-areas-in-separate-projects-not-working-view-not-found/12912161#12912161

        public override string AreaName
        {
            get { return "ECommerce"; }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            base.RegisterArea(context);

            // Register the different E-Commerce controllers
            //
            ECommerceControllerRegistration.RegisterControllers(context.Routes);
        }

        protected override void RegisterAllViewModels()
        {
            // Entity Views
            //
            RegisterViewModel("ProductDetail", typeof(ProductDetailWidget), "EComWidget");
            RegisterViewModel("ProductDetailEclItem", typeof(ECommerceEclItem), "EComWidget");
            RegisterViewModel("ProductLister", typeof(ProductListerWidget), "EComWidget");
            RegisterViewModel("Facets", typeof(FacetsWidget), "EComWidget");
            RegisterViewModel("Promotions", typeof(PromotionsWidget), "EComWidget");
            RegisterViewModel("Breadcrumb", typeof(BreadcrumbWidget), "EComWidget");
            RegisterViewModel("DetailBreadcrumb", typeof(BreadcrumbWidget), "EComWidget");
            RegisterViewModel("SearchFeedback", typeof(SearchFeedbackWidget), "EComWidget");
            RegisterViewModel("SearchBox", typeof(SearchBox));
            RegisterViewModel("FacetsMegaNavigation", typeof(FacetsWidget), "EComWidget");
            RegisterViewModel("CartMinimized", typeof(CartWidget), "EComWidget");
            RegisterViewModel("CartDetail", typeof(CartWidget), "EComWidget");
        }
    }
}