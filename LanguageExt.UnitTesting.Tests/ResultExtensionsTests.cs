using FluentAssertions;
using LanguageExt.Common;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public static class ResultExtensionsTests
    {
        [Fact]
        public static void ShouldBeSuccess_GivenFail_Throws()
        {
            Action act = () => GetFail().ShouldBeSuccess();
            act.Should().Throw<Exception>().WithMessage("Expected Success, got Fail instead.");
        }

        [Fact]
        public static void ShouldBeFail_GivenSuccess_Throws()
        {
            Action act = () => GetSuccess().ShouldBeFail();
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got Success instead.");
        }

        [Fact]
        public static void ShouldBeSuccess_GivenSuccessWithValidation_RunsValidation()
        {
            var validationRan = false;
            GetSuccess().ShouldBeSuccess(_ => validationRan = true);
            validationRan.Should().BeTrue();
        }
        
        [Fact]
        public static void ShouldBeFail_GivenFailWithValidation_RunsValidation()
        {
            var validationRan = false;
            GetFail().ShouldBeFail(_ => validationRan = true);
            validationRan.Should().BeTrue();
        }
        
        [Fact]
        public static void ShouldBeFail_GivenFailWithValidation_RunsValidation_CheckMessage()
        {
            var validationRan = false;
            var validationMessage = "";
            GetFail().ShouldBeFail(x =>
            {
                validationRan = true;
                validationMessage = x.Message;
            });
            validationRan.Should().BeTrue();
            validationMessage.Should().Be("fail");
        }

        [Fact]
        public static void ShouldBeSuccess_GivenSuccessNoValidation_DoesNotThrow()
            => GetSuccess().ShouldBeSuccess();

        [Fact]
        public static void ShouldBeFail_GivenFail_DoesNotThrow() => GetFail().ShouldBeFail();

        private static Result<string> GetFail() => new(new Exception("fail"));
        private static Result<string> GetSuccess() => "success";
    }
}