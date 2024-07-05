using FluentAssertions;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public static class OptionAsyncExtensionsTests
    {
        [Fact]
        public static async Task ShouldBeSome_GivenNone_Throws()
        {
            Func<Task> act = () => GetNone().ShouldBeSome();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public static async Task ShouldBeNone_GivenSome_Throws()
        {
            Func<Task> act = () => GetSome().ShouldBeNone();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public static async Task ShouldBeSome_GivenSomeWithValidation_RunsValidation()
        {
            var validationRan = false;
            await GetSome().ShouldBeSome(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static async Task ShouldBeSome_GivenSomeNoValidation_DoesNotThrow() 
            => await GetSome().ShouldBeSome();

        [Fact]
        public static async Task ShouldBeNone_GivenNone_DoesNotThrow()
        {
            Func<Task> act = () => GetNone().ShouldBeNone();
            await act();
        }

        private static OptionAsync<string> GetNone() => OptionAsync<string>.None;
        private static OptionAsync<string> GetSome() => "some";
    }
}
