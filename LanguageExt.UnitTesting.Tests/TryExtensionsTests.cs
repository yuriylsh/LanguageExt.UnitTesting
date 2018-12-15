using System;
using FluentAssertions;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public static class TryExtensionsTests
    {
        [Fact]
        public static void ShouldBeFail_GivenSuccess_Throws()
        {
            Action act = () => GetSuccess().ShouldBeFail();
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got Success instead.");
        }

        [Fact]
        public static void ShouldBeSuccess_GivenFail_Throws()
        {
            Action act = () => GetFail().ShouldBeSuccess();
            act.Should().Throw<Exception>().WithMessage("Expected Success, got Fail instead.");
        }

        [Fact]
        public static void ShouldBeFail_GivenFailWithValidation_RunsValidation()
        {
            var validationRan = false;
            GetFail().ShouldBeFail(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeFail_GivenFailNoValidation_DoesNotThrow()
            => GetFail().ShouldBeFail();

        [Fact]
        public static void ShouldBeSuccess_GivenSuccessWithValidation_RunsValidation()
        {
            var validationRan = false;
            GetSuccess().ShouldBeSuccess(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        [Fact]
        public static void ShouldBeSuccess_GivenSuccessNoValidation_DoesNotThrow()
            => GetSuccess().ShouldBeSuccess();

        private static Try<string> GetFail() => () => throw new Exception();
        private static Try<string> GetSuccess() => () => "success";
    }
}
