using System;
using Xunit;
using static LanguageExt.Prelude;
namespace LanguageExt.UnitTesting.Tests
{
    public class TryAsyncExtensions_ShouldBeFail
    {
        [Fact]
        public void ShouldBeFail_Should_Throw_If_Success()
        {
            var @try = TryAsync(() => "test");

            Assert.ThrowsAsync<Exception>(() => @try.ShouldBeFail(x => { }));
        }

        [Fact]
        public void ShouldBeFail_Should_Execute_FailAction()
        {
            var @try = TryAsync<string>(() => throw new Exception());

            var result = false;
            @try.ShouldBeFail(x => result = true).Wait();
            Assert.True(result);
        }
    }
}
