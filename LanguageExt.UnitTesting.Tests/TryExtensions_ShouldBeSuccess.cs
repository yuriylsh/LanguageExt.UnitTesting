using System;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public class TryExtensions_ShouldBeSuccess
    {
        [Fact]
        public void ShouldBeSuccess_Should_Throw_If_Fail()
        {
            Try<string> @try = () => throw new Exception();

            Assert.Throws<Exception>(() => @try.ShouldBeSuccess(x => { }));
        }

        [Fact]
        public void ShouldBeSuccess_Should_Execute_SuccessAction()
        {
            Try<string> option = () => "test";

            var result = false;
            option.ShouldBeSuccess(x => result = true);
            Assert.True(result);
        }
    }
}
