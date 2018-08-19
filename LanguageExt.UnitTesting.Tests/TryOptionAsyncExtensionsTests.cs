using System;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class TryOptionAsyncExtensionsTests
    {
        [Fact]
        public static void ShouldBeFail_GivenSuccessSome_Throws()
        {
            Func<Task> act = () => GetSuccessSome().ShouldBeFail(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got Some instead.");
        }

        [Fact]
        public static void ShouldBeFail_GivenSuccessNone_Throws()
        {
            Func<Task> act = () => GetSuccessNone().ShouldBeFail(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got None instead.");
        }

        [Fact]
        public static async Task ShouldBeFail_GivenFail_RunsValidation()
        {
            var validationRan = false;
            await GetFail().ShouldBeFail(x => validationRan = true);
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeSome_GivenNone_Throws()
        {
            Func<Task> act = () => GetSuccessNone().ShouldBeSome(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public static void ShouldBeSome_GivenFail_Throws()
        {
            Func<Task> act = () => GetFail().ShouldBeSome(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("something went wrong");
        }

        [Fact]
        public static async Task ShouldBeSome_GivenSome_RunsValidation()
        {
            var validationRan = false;
            await GetSuccessSome().ShouldBeSome(x => {
                    x.Should().Be(123);
                    validationRan = true;
                });
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeNone_GivenSome_Throws()
        {
            Func<Task> act = () => GetSuccessSome().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public static void ShouldBeNone_GivenFail_Throws()
        {
            Func<Task> act = () => GetFail().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("something went wrong");
        }

        [Fact]
        public static async Task ShouldBeNone_GivenNone_DoesNotThrow()
        {
            await GetSuccessNone().ShouldBeNone();
        }

        private static TryOptionAsync<int> GetFail() => () => throw new Exception("something went wrong");
        private static TryOptionAsync<int> GetSuccessSome() => async () => await Task.FromResult(123);
        private static TryOptionAsync<int> GetSuccessNone() => async () => await Task.FromResult(Prelude.None);
    }
}
