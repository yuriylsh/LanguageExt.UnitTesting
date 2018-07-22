using System;
using System.Threading.Tasks;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class TryAsyncExtensionsTests
    {
        [Theory]
        [ClassData(typeof(TryAsyncGenerator))]
        public async Task ShouldBeX_GivenOppositeSide_Throws(TryAsync<string> @tryAsync)
        {
            Func<Task> act = null;
            await tryAsync.Match(
                success => act = async () => await tryAsync.ShouldBeFail(ValidationNoop),
                fail => act = async () => await tryAsync.ShouldBeSuccess(ValidationNoop));

            await Assert.ThrowsAsync<Exception>(act);
        }

        [Theory]
        [ClassData(typeof(TryAsyncGenerator))]
        public async Task ShouldBeX_GivenCorrectSide_RunsValidation(TryAsync<string> @tryAsync)
        {
            var validationSideEffect = false;

            await @tryAsync.Match(
                success => @tryAsync.ShouldBeSuccess(x => validationSideEffect = true),
                fail =>  @tryAsync.ShouldBeFail(x => validationSideEffect = true));

            Assert.True(validationSideEffect);
        }
    }
}
