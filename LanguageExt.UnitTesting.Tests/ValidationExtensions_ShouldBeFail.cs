using System;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public class ValidationExtensions_ShouldBeFail
    {
        [Fact]
        public void ShouldBeFail_Should_Throw_If_Success()
        {
            Validation<Exception, string> validation = "test";

            Assert.Throws<Exception>(() => validation.ShouldBeFail(x => { }));
        }

        [Fact]
        public void ShouldBeFail_Should_Execute_FailAction()
        {
            Validation<Exception, string> validation = new Exception();

            var result = false;
            validation.ShouldBeFail(x => result = true);
            Assert.True(result);
        }
    }
}
