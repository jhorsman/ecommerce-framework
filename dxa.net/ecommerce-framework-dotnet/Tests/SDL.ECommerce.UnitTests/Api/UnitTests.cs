using System;

using Xunit;

using Sdl.ECommerce.Api;

namespace Sdl.ECommerce.UnitTests.Api
{
    public class UnitTests
    {
        [Fact]
        public void TestFacetParameter()
        {
            var facet = new FacetParameter("brand", "adidas|dkny");
            Console.WriteLine("Facet: " + facet.Name + ", type: " + facet.Type);
            Console.WriteLine("Contains 'adidas': " + facet.ContainsValue("adidas"));
        }
    }
}