using System;
using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.UnitTesting.Tests
{
    public class OptionExtensions_ShouldBeNone
    {
        [Fact]
        public void ShouldBeNone_Should_Throw_If_Some()
        {
            Option<string> option = "test";

            Assert.Throws<Exception>(() => option.ShouldBeNone());
        }

        [Fact]
        public void ShouldBeNone_Should_Execute_NoneAction()
        {
            Option<string> option = None;

            option.ShouldBeNone();
        }
    }
}
