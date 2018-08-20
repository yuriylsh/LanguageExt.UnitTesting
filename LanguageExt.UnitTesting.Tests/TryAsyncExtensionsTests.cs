using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class TryAsyncExtensionsTests
    {
        [Fact]
        public static void ShouldBeFail_GivenSuccess_Throws()
        {
            Func<Task> act = () => GetSuccess().ShouldBeFail(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got Success instead.");
        }

        [Fact]
        public static void ShouldBeSuccess_GivenFail_Throws()
        {
            Func<Task> act = () => GetFail().ShouldBeSuccess(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Success, got Fail instead.");
        }

        [Fact]
        public static async Task ShouldBeFail_GivenFail_RunsValidation()
        {
            var validationRan = false;
            await GetFail().ShouldBeFail(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static async Task ShouldBeSuccess_GivenSuccess_RunsValidation()
        {
            var validationRan = false;
            await GetSuccess().ShouldBeSuccess(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        private static TryAsync<string> GetFail() => () => throw new Exception();
        private static TryAsync<string> GetSuccess() => async () => await Task.FromResult("success");
    }
}
