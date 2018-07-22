using System;
using Xunit;
using static LanguageExt.Prelude;

namespace LanguageExt.UnitTesting.Tests
{
    public class TryAsyncExtensions_ShouldBeSuccess
    {
        [Fact]
        public void ShouldBeSuccess_Should_Throw_If_Fail()
        {
            var @try = TryAsync<string>(() => throw new Exception());

            Assert.ThrowsAsync<Exception>(() => @try.ShouldBeSuccess(x => { }));
        }

        [Fact]
        public void ShouldBeSuccess_Should_Execute_SuccessAction()
        {
            var option = TryAsync(() => "test");

            var result = false;
            option.ShouldBeSuccess(x => result = true).Wait();
            Assert.True(result);
        }
    }
}
