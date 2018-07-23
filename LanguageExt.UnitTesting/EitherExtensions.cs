using System;

namespace LanguageExt.UnitTesting
{
    public static class EitherExtensions
    {
        public static void ShouldBeRight<TLeft, TRight>(this Either<TLeft, TRight> @this, Action<TRight> rightValidation)
            => @this.Match(rightValidation, Common.ThrowIfLeft);

        public static void ShouldBeLeft<TLeft, TRight>(this Either<TLeft, TRight> @this, Action<TLeft> leftValidation)
            => @this.Match(Common.ThrowIfRight, leftValidation);
    }
}
