using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class EitherAsyncExtensions
    {
        public static async Task ShouldBeRight<TLeft, TRight>(this EitherAsync<TLeft, TRight> @this,
                                                              Action<TRight> rightValidation = null)
            => await @this.Match(rightValidation ?? Common.Noop,
                                 Common.ThrowIfLeft);

        public static async Task ShouldBeLeft<TLeft, TRight>(this EitherAsync<TLeft, TRight> @this,
                                                             Action<TLeft> leftValidation = null)
            => await @this.Match(Common.ThrowIfRight,
                                 leftValidation ?? Common.Noop);
    }
}
