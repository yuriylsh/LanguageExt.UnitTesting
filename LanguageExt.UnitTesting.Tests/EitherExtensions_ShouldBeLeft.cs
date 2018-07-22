using System;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public class EitherExtensions_ShouldBeLeft
    {
        [Fact]
        public void ShouldBeLeft_Should_Throw_If_Right()
        {
            Either<Exception, string> either = "test";

            Assert.Throws<Exception>(() => either.ShouldBeLeft(x => { }));
        }

        [Fact]
        public void ShouldBeLeft_Should_Execute_LeftAction()
        {
            Either<Exception, string> either = new Exception();

            var result = false;
            either.ShouldBeLeft(x => result = true);
            Assert.True(result);
        }
    }
}
