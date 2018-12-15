using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class OptionAsyncExtensions
    {
        public static async Task ShouldBeSome<T>(this OptionAsync<T> @this, Action<T> someValidation = null) =>
            await @this.Match(Some: someValidation ?? Common.Noop, None: Common.ThrowIfNone);

        public static async Task ShouldBeNone<T>(this OptionAsync<T> @this) =>
            await @this.Match(Some: Common.ThrowIfSome, None: Common.SuccessfulNone);
    }
}