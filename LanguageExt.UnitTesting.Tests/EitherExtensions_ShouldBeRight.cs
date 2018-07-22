using System;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public class EitherExtensions_ShouldBeRight
    {
        [Fact]
        public void ShouldBeRight_Should_Throw_If_Left()
        {
            Either<Exception, string> either = new Exception();

            Assert.Throws<Exception>(() => either.ShouldBeRight(x => { }));
        }

        [Fact]
        public void ShouldBeRight_Should_Execute_RightAction()
        {
            Either<Exception, string> either = "test";

            var result = false;
            either.ShouldBeRight(x => result = true);
            Assert.True(result);
        }
    }
}
