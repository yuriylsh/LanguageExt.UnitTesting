using System;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class OptionExtensionsTests
    {
        [Fact]
        public static void ShouldBeSome_GivenNone_Throws()
        {
            Action act = () => GetNone().ShouldBeSome(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public static void ShouldBeNone_GivenSome_Throws()
        {
            Action act = () => GetSome().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public static void ShouldBeSome_GivenSome_RunsValidation()
        {
            var validationRan = false;
            GetSome().ShouldBeSome(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        
        [Fact]
        public static void ShouldBeSome_GivenSome_NoValidation_DoesNotThrow() => GetSome().ShouldBeSome();

        [Fact]
        public static void ShouldBeNone_GivenNone_DoesNotThrow() => GetNone().ShouldBeNone();

        private static Option<string> GetNone() => Option<string>.None;
        private static Option<string> GetSome() => "some";
    }
}
