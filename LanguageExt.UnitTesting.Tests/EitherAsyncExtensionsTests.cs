using FluentAssertions;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public static class EitherAsyncExtensionsTests
    {
        [Fact]
        public static async Task ShouldBeRight_GivenLeft_Throws()
        {
            Func<Task> act = () => GetLeft().ShouldBeRight();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Right, got Left instead.");
        }

        [Fact]
        public static async Task ShouldBeLeft_GivenRight_Throws()
        {
            Func<Task> act = () => GetRight().ShouldBeLeft();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Left, got Right instead.");
        }

        [Fact]
        public static async Task ShouldBeLeft_GivenLeftWithValidation_RunsValidation()
        {
            var validationRan = false;
            await GetLeft().ShouldBeLeft(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static async Task ShouldBeLeft_GivenLeftNoValidation_DoesNotThrow()
            => await GetLeft().ShouldBeLeft();

        [Fact]
        public static async Task ShouldBeRight_GivenRightWithValidation_RunsValidation()
        {
            var validationRan = false;
            await GetRight().ShouldBeRight(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        
        [Fact]
        public static async Task ShouldBeRight_GivenRightNoValidation_DoesNotThrow()
            => await GetRight().ShouldBeRight();

        private static EitherAsync<int, string> GetLeft() => 123;
        private static EitherAsync<int, string> GetRight() => "right";
    }
}