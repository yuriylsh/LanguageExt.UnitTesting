using System;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class EitherExtensionsTests
    {
        [Fact]
        public static void ShouldBeRight_GivenLeft_Throws()
        {
            Action act = () => GetLeft().ShouldBeRight(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Right, got Left instead.");
        }

        [Fact]
        public static void ShouldBeLeft_GivenRight_Throws()
        {
            Action act = () => GetRight().ShouldBeLeft(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Left, got Right instead.");
        }

        [Fact]
        public static void ShouldBeLeft_GivenLeft_RunsValidation()
        {
            var validationRan = false;
            GetLeft().ShouldBeLeft(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeLeft_GivenLeft_DoesNotThrow()
        {
            GetLeft().ShouldBeLeft();
        }

        [Fact]
        public static void ShouldBeRight_GivenRight_RunsValidation()
        {
            var validationRan = false;
            GetRight().ShouldBeRight(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeRight_GivenRight_DoesNotThrow()
        {
            GetRight().ShouldBeRight();
        }

        private static Either<int, string> GetLeft() => 123;
        private static Either<int, string> GetRight() => "right";
    }
}
