using System;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public class TryExtensions_ShouldBeFail
    {
        [Fact]
        public void ShouldBeFail_Should_Throw_If_Success()
        {
            Try<string> @try = () => "test";

            Assert.Throws<Exception>(() => @try.ShouldBeFail(x => { }));
        }

        [Fact]
        public void ShouldBeFail_Should_Execute_FailAction()
        {
            Try<string> @try = () => throw new Exception();

            var result = false;
            @try.ShouldBeFail(x => result = true);
            Assert.True(result);
        }
    }
}
