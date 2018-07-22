using System;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class EitherExtensionsTests
    {
        [Theory]
        [ClassData(typeof(EitherGenerator))]
        public void ShouldBeSide_GivenOppositeSide_Throws(Either<int, string> either)
        {
            Action act = null;

            either.Match(
                right => act = () => either.ShouldBeLeft(ValidationNoop),
                left => act = () => either.ShouldBeRight(ValidationNoop));

            Assert.Throws<Exception>(act);
        }

        [Theory]
        [ClassData(typeof(EitherGenerator))]
        public void ShouldBeSide_GivenCorrectSide_RunsValidation(Either<int, string> either)
        {
            var validationSideEffect = false;

            either.Match(
                right => either.ShouldBeRight(x => validationSideEffect = true),
                left => either.ShouldBeLeft(x => validationSideEffect = true));

            Assert.True(validationSideEffect);
        }
    }
}
