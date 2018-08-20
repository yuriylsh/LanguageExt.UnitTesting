using System;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class ValidationExtensionsTests
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
        public static void ShouldBeSuccess_GivenSuccess_RunsValidation()
        {
            var validationRan = false;
            GetSuccess().ShouldBeSuccess(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        private static Validation<int, string> GetFail() => 123;
        private static Validation<int, string> GetSuccess() => "success";
    }
}
