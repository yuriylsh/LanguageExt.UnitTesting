using System;

namespace LanguageExt.UnitTesting
{
    public static class EitherExtensions
    {
        public static void ShouldBeRight<TLeft, TRight>(this Either<TLeft, TRight> @this,
                                                        Action<TRight> rightValidation = null)
            => @this.Match(rightValidation ?? Common.Noop, Common.ThrowIfLeft);

        public static void ShouldBeLeft<TLeft, TRight>(this Either<TLeft, TRight> @this,
                                                       Action<TLeft> leftValidation = null)
            => @this.Match(Common.ThrowIfRight, leftValidation ?? Common.Noop);
    }
}
