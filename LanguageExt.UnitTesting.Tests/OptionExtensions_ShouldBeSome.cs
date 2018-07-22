using System;
using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.UnitTesting.Tests
{
    public class OptionExtensions_ShouldBeSome
    {
        [Fact]
        public void ShouldBeSome_Should_Throw_If_None()
        {
            Option<string> option = None;

            Assert.Throws<Exception>(() => option.ShouldBeSome(x => { }));
        }

        [Fact]
        public void ShouldBeSome_Should_Execute_SomeAction()
        {
            Option<string> option = "test";

            var result = false;
            option.ShouldBeSome(x => result = true);
            Assert.True(result);
        }
    }
}
