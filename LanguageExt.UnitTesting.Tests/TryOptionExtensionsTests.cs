using System;
using FluentAssertions;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public static class TryOptionExtensionsTests
    {
        [Fact]
        public static void ShouldBeFail_GivenSuccessSome_Throws()
        {
            Action act = () => GetSuccessSome().ShouldBeFail(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got Some instead.");
        }

        [Fact]
        public static void ShouldBeFail_GivenSuccessNone_Throws()
        {
            Action act = () => GetSuccessNone().ShouldBeFail(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Fail, got None instead.");
        }

        [Fact]
        public static void ShouldBeFail_GivenFail_RunsValidation()
        {
            var validationRan = false;
            GetFail().ShouldBeFail(x => validationRan = true);
            validationRan.Should().BeTrue();
        }
        
        [Fact]
        public static void ShouldBeFail_GivenFail_DoesNotThrow()
        {
            GetFail().ShouldBeFail();
        }

        [Fact]
        public static void ShouldBeSome_GivenNone_Throws()
        {
            Action act = () => GetSuccessNone().ShouldBeSome(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("Expected Some, got None instead.");
        }

        [Fact]
        public static void ShouldBeSome_GivenFail_Throws()
        {
            Action act = () => GetFail().ShouldBeSome(ValidationNoop);
            act.Should().Throw<Exception>().WithMessage("something went wrong");
        }

        [Fact]
        public static void ShouldBeSome_GivenSome_RunsValidation()
        {
            var validationRan = false;
            GetSuccessSome().ShouldBeSome(x =>
            {
                x.Should().Be(123);
                validationRan = true;
            });
            validationRan.Should().BeTrue();
        }

        [Fact]
        public static void ShouldBeSome_GivenSome_DoesNotThrow()
        {
            GetSuccessSome().ShouldBeSome();
        }

        [Fact]
        public static void ShouldBeNone_GivenSome_Throws()
        {
            Action act = () => GetSuccessSome().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("Expected None, got Some instead.");
        }

        [Fact]
        public static void ShouldBeNone_GivenFail_Throws()
        {
            Action act = () => GetFail().ShouldBeNone();
            act.Should().Throw<Exception>().WithMessage("something went wrong");
        }

        [Fact]
        public static void ShouldBeNone_GivenNone_DoesNotThrow()
        {
            GetSuccessNone().ShouldBeNone();
        }

        private static TryOption<int> GetFail() => () => throw new Exception("something went wrong");
        private static TryOption<int> GetSuccessSome() => () => 123;
        private static TryOption<int> GetSuccessNone() => () => Prelude.None;
    }
}
