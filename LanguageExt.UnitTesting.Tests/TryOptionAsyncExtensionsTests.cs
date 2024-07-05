﻿using FluentAssertions;
using Xunit;

namespace LanguageExt.UnitTesting.Tests
{
    public static class TryOptionAsyncExtensionsTests
    {
        [Fact]
        public static async Task ShouldBeFail_GivenSuccessSome_Throws()
        {
            Func<Task> act = () => GetSuccessSome().ShouldBeFail();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Fail, got Some instead.");
        }

        [Fact]
        public static async Task ShouldBeFail_GivenSuccessNone_Throws()
        {
            Func<Task> act = () => GetSuccessNone().ShouldBeFail();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Fail, got None instead.");
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
        public static async Task ShouldBeSome_GivenNone_Throws()
        {
            Func<Task> act = () => GetSuccessNone().ShouldBeSome();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public static async Task ShouldBeSome_GivenFail_Throws()
        {
            Func<Task> act = () => GetFail().ShouldBeSome();
            await act.Should().ThrowAsync<Exception>().WithMessage("something went wrong");
        }

        [Fact]
        public static async Task ShouldBeSome_GivenSomeWithValidation_RunsValidation()
        {
            var validationRan = false;
            await GetSuccessSome().ShouldBeSome(x =>
            {
                x.Should().Be(123);
                validationRan = true;
            });
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static async Task  ShouldBeSome_GivenSomeNoValidation_DoesNotThrow()
            => await GetSuccessSome().ShouldBeSome();

        [Fact]
        public static async Task ShouldBeNone_GivenSome_Throws()
        {
            Func<Task> act = () => GetSuccessSome().ShouldBeNone();
            await act.Should().ThrowAsync<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public static async Task ShouldBeNone_GivenFail_Throws()
        {
            Func<Task> act = () => GetFail().ShouldBeNone();
            await act.Should().ThrowAsync<Exception>().WithMessage("something went wrong");
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
