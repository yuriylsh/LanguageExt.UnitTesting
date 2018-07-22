using System;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class ValidationExtensionsTests
    {
        [Theory]
        [ClassData(typeof(ValidationGenerator))]
        public void ShouldBeX_GivenOppositeSide_Throws(Validation<int, string> validation)
        {
            Action act = null;
            validation.Match(
                success => act = () => validation.ShouldBeFail(ValidationNoop),
                fail => act = () => validation.ShouldBeSuccess(ValidationNoop));

            Assert.Throws<Exception>(act);
        }

        [Theory]
        [ClassData(typeof(ValidationGenerator))]
        public void ShouldBeX_GivenCorrectSide_RunsValidation(Validation<int, string> validation)
        {
            var validationSideEffect = false;

            validation.Match(
                success => validation.ShouldBeSuccess(x => validationSideEffect = true),
                fail => validation.ShouldBeFail(x => validationSideEffect = true));

            Assert.True(validationSideEffect);
        }
    }
}
