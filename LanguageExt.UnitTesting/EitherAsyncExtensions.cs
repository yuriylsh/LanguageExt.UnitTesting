using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class EitherAsyncExtensions
    {
        public static async Task ShouldBeRight<TLeft, TRight>(this EitherAsync<TLeft, TRight> @this, Action<TRight> rightValidation)
            => await @this.Match(rightValidation, Common.ThrowIfLeft);

        public static async Task ShouldBeLeft<TLeft, TRight>(this EitherAsync<TLeft, TRight> @this, Action<TLeft> leftValidation)
            => await @this.Match(Common.ThrowIfRight, leftValidation);
    }
}
