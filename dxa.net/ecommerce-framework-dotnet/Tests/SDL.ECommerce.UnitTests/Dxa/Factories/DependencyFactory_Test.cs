namespace Sdl.ECommerce.UnitTests.Dxa.Factories
{
    using System;

    using NSubstitute;

    using Sdl.ECommerce.Api;
    using Sdl.ECommerce.Dxa;
    using Sdl.ECommerce.Dxa.Factories;
    using Sdl.ECommerce.Dxa.Providers;

    using Xunit;

    public class DependencyFactory_Test : Test
    {
        public class WhenSettingADependency : MultipleAssertTest<DependencyFactory_Test>, IDisposable
        {
            private readonly IECommerceLinkResolver _result;

            private readonly IECommerceLinkResolver _dependency;

            public WhenSettingADependency()
            {
                _dependency = Substitute.For<IECommerceLinkResolver>();

                DependencyResolverProvider.Set(type => type == typeof(IECommerceLinkResolver) ? _dependency : null);

                _result = DependencyFactory.Current.Resolve<IECommerceLinkResolver>();
            }

            [Fact]
            public void ThenThatDepedencyShouldBeResolved()
            {
                Assert.Equal(_dependency, _result);
            }

            public void Dispose()
            {
                DependencyResolverProvider.Reset();
            }
        }

        public class WhenNotSettingADependency : MultipleAssertTest<DependencyFactory_Test>, IDisposable
        {
            private readonly IECommerceLinkResolver _result;

            public WhenNotSettingADependency()
            {
                DependencyResolverProvider.Set(type => null);
                
                _result = DependencyFactory.Current.Resolve<IECommerceLinkResolver>();
            }

            [Fact]
            public void ThenADefaultDepedencyShouldBeResolved()
            {
                Assert.IsType<DxaLinkResolver>(_result);
            }

            public void Dispose()
            {
                DependencyResolverProvider.Reset();
            }
        }
    }
}