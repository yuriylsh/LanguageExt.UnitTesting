using System;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class EitherExtensionsTests
    {
        [Fact]
        public void ShouldBeRight_GivenLeft_Throws()
        {
            Action act = () => GetLeft().ShouldBeRight(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Right, got Left instead.");
        }

        [Fact]
        public void ShouldBeLeft_GivenRight_Throws()
        {
            Action act = () => GetRight().ShouldBeLeft(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Left, got Right instead.");
        }

        [Fact]
        public void ShouldBeLeft_GivenLeft_RunsValidation()
        {
            var validationRan = false;
            GetLeft().ShouldBeLeft(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public void ShouldBeRight_GivenRight_RunsValidation()
        {
            var validationRan = false;
            GetRight().ShouldBeRight(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        private static Either<int, string> GetLeft() => 123;
        private static Either<int, string> GetRight() => "right";
    }
}
