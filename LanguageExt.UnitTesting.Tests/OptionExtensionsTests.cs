using System;
using FluentAssertions;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public static class OptionExtensionsTests
    {
        [Fact]
        public static void ShouldBeSome_GivenNone_Throws()
        {
            Action act = () => GetNone().ShouldBeSome();
            act.Should().Throw<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public static void ShouldBeNone_GivenSome_Throws()
        {
            Action act = () => GetSome().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public static void ShouldBeSome_GivenSomeWithValidation_RunsValidation()
        {
            var validationRan = false;
            GetSome().ShouldBeSome(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        
        [Fact]
        public static void ShouldBeSome_GivenSomeNoValidation_DoesNotThrow()
            => GetSome().ShouldBeSome();

        [Fact]
        public static void ShouldBeNone_GivenNone_DoesNotThrow() => GetNone().ShouldBeNone();

        private static Option<string> GetNone() => Option<string>.None;
        private static Option<string> GetSome() => "some";
    }
}
