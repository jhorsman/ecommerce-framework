﻿namespace Sdl.ECommerce.UnitTests
{
    using System;

    using Ploeh.AutoFixture;
    using Ploeh.AutoFixture.AutoNSubstitute;

    using Sdl.ECommerce.UnitTests.Customizations;
    using Sdl.ECommerce.UnitTests.Customizations.Sdl;

    public abstract class Test
    {
        public IFixture Fixture { get; }

        protected Test()
        {
            Fixture = new Fixture().Customize(new AutoNSubstituteCustomization())
                                   .Customize(new MvcCustomization())
                                   .Customize(new SdlCustomizations());
        }
    }

    public abstract class Test<T> : Test
    {
        private T _systemUnderTest;

        public T SystemUnderTest
        {
            get
            {
                if (_systemUnderTest == null)
                {
                    _systemUnderTest = Fixture.Freeze<T>();
                }

                return _systemUnderTest;
            }
        }
    }
}