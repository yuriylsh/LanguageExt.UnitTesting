using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class TryOptionAsyncExtensions
    {
        public static async Task ShouldBeSome<T>(this TryOptionAsync<T> @this, Action<T> someValidation = null)
            => await @this.Match(
                Some: someValidation ?? Common.Noop,
                None: Common.ThrowIfNone,
                Fail: ex => throw ex
            );

        public static async Task ShouldBeNone<T>(this TryOptionAsync<T> @this)
            => await @this.Match(
                Some: Common.ThrowIfSome,
                None: Common.SuccessfulNone,
                Fail: ex => throw ex
            );

        public static async Task ShouldBeFail<T>(this TryOptionAsync<T> @this, Action<Exception> failValidation = null)
            => await @this.Match(
                Some: Common.ThrowExpectedFailGotSome,
                None: Common.ThrowExpectedFailGotNone,
                Fail: ex => (failValidation ?? Common.Noop)(ex)
        );
    }
}