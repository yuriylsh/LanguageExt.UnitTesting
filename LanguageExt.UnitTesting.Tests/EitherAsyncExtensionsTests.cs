using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class EitherAsyncExtensionsTests
    {
        [Fact]
        public void ShouldBeRight_GivenLeft_Throws()
        {
            Func<Task> act = () => GetLeft().ShouldBeRight(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Right, got Left instead.");
        }

        [Fact]
        public void ShouldBeLeft_GivenRight_Throws()
        {
            Func<Task> act = () => GetRight().ShouldBeLeft(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Left, got Right instead.");
        }

        [Fact]
        public async Task ShouldBeLeft_GivenLeft_RunsValidation()
        {
            var validationRan = false;
            await GetLeft().ShouldBeLeft(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public async Task ShouldBeRight_GivenRight_RunsValidation()
        {
            var validationRan = false;
            await GetRight().ShouldBeRight(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        private static EitherAsync<int, string> GetLeft() => 123;
        private static EitherAsync<int, string> GetRight() => "right";
    }
}