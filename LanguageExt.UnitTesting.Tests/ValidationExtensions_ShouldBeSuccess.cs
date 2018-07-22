using System;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public class ValidationExtensions_ShouldBeSuccess
    {
        [Fact]
        public void ShouldBeSuccess_Should_Throw_If_Fail()
        {
            Validation<Exception, string> validation = new Exception();

            Assert.Throws<Exception>(() => validation.ShouldBeSuccess(x => { }));
        }

        [Fact]
        public void ShouldBeSuccess_Should_Execute_SuccessAction()
        {
            Validation<Exception, string> validation = "test";

            var result = false;
            validation.ShouldBeSuccess(x => result = true);
            Assert.True(result);
        }
    }
}
