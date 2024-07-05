using FluentAssertions;
using LanguageExt.Common;
using static LanguageExt.Prelude;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{

    public static class FinExtensionsTests
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
        public static void ShouldBeFail_GivenFailWithFin_RunsFin()
        {
            var finRan = false;
            GetFail().ShouldBeFail(x => finRan = true);
            finRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeFail_GivenNoFail_DoesNotThrow()
            => GetFail().ShouldBeFail();

        [Fact]
        public static void ShouldBeSuccess_GivenSuccessWithFin_RunsFin()
        {
            var finRan = false;
            GetSuccess().ShouldBeSuccess(x => finRan = true);
            finRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeSuccess_GivenSuccessNoFail_DoesNotThrow()
            => GetSuccess().ShouldBeSuccess();

        [Fact]
        public static void ShoulBeFail_GivenFailedFin_DoesNotThrow()
            => Fin<Unit>.Fail(Error.New(5, "Test Error")).ShouldBeFail();

        private static Fin<string> GetFail() => FinFail<string>("error");
        private static Fin<string> GetSuccess() => FinSucc("success");
    }
}