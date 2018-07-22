using System;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class TryExtensionsTests
    {
        [Theory]
        [ClassData(typeof(TryGenerator))]
        public void ShouldBeX_GivenOppositeSide_Throws(Try<string> @try)
        {
            Action act = null;
            @try.Match(
                success => act = () => @try.ShouldBeFail(ValidationNoop),
                fail => act = () => @try.ShouldBeSuccess(ValidationNoop));

            Assert.Throws<Exception>(act);
        }

        [Theory]
        [ClassData(typeof(TryGenerator))]
        public void ShouldBeX_GivenCorrectSide_RunsValidation(Try<string> @try)
        {
            var validationSideEffect = false;

            @try.Match(
                success => @try.ShouldBeSuccess(x => validationSideEffect = true),
                fail => @try.ShouldBeFail(x => validationSideEffect = true));

            Assert.True(validationSideEffect);
        }
    }
}
