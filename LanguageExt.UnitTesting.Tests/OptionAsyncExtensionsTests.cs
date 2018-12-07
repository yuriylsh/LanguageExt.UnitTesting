using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class OptionAsyncExtensionsTests
    {
        [Fact]
        public static void ShouldBeSome_GivenNone_Throws()
        {
            Func<Task> act = () => GetNone().ShouldBeSome(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public static void ShouldBeNone_GivenSome_Throws()
        {
            Func<Task> act = () => GetSome().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public static async Task ShouldBeSome_GivenSome_RunsValidation()
        {
            var validationRan = false;
            await GetSome().ShouldBeSome(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static async Task ShouldBeSome_GivenSome_DoesNotThrow()
        {
            await GetSome().ShouldBeSome();
        }

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
