using System;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class TryExtensionsTests
    {
        [Fact]
        public static void ShouldBeFail_GivenSuccess_Throws()
        {
            Action act = () => GetSuccess().ShouldBeFail(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got Success instead.");
        }

        [Fact]
        public static void ShouldBeSuccess_GivenFail_Throws()
        {
            Action act = () => GetFail().ShouldBeSuccess(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Success, got Fail instead.");
        }

        [Fact]
        public static void ShouldBeFail_GivenFail_RunsValidation()
        {
            var validationRan = false;
            GetFail().ShouldBeFail(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeFail_GivenFail_DoesNotThrow()
        {
            GetFail().ShouldBeFail();
        }

        [Fact]
        public static void ShouldBeSuccess_GivenSuccess_RunsValidation()
        {
            var validationRan = false;
            GetSuccess().ShouldBeSuccess(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        [Fact]
        public static void ShouldBeSuccess_GivenSuccess_DoesNotThrow()
        {
            GetSuccess().ShouldBeSuccess();
        }

        private static Try<string> GetFail() => () => throw new Exception();
        private static Try<string> GetSuccess() => () => "success";
    }
}
