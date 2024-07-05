using FluentAssertions;
using Xunit;
namespace LanguageExt.UnitTesting.Tests
{
    public static class TryAsyncExtensionsTests
    {
        [Fact]
        public static async Task ShouldBeFail_GivenSuccess_Throws()
        {
            Func<Task> act = () => GetSuccess().ShouldBeFail();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Fail, got Success instead.");
        }

        [Fact]
        public static async Task ShouldBeSuccess_GivenFail_Throws()
        {
            Func<Task> act = () => GetFail().ShouldBeSuccess();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Success, got Fail instead.");
        }

        [Fact]
        public static async Task ShouldBeFail_GivenFailWithValidation_RunsValidation()
        {
            var validationRan = false;
            await GetFail().ShouldBeFail(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        [Fact]
        public static async Task ShouldBeFail_GivenFailNoValidation_DoesNotThrow()
            => await GetFail().ShouldBeFail();

        [Fact]
        public static async Task ShouldBeSuccess_GivenSuccessWithValidation_RunsValidation()
        {
            var validationRan = false;
            await GetSuccess().ShouldBeSuccess(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        
        [Fact]
        public static async Task ShouldBeSuccess_GivenSuccessNoValidation_DoesNotThrow()
            => await GetSuccess().ShouldBeSuccess();

        private static TryAsync<string> GetFail() => () => throw new Exception();
        private static TryAsync<string> GetSuccess() => async () => await Task.FromResult("success");
    }
}
