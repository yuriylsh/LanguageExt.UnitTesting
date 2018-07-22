using System;

namespace LanguageExt.UnitTesting
{
    public static class EitherExtensions
    {
        public static void ShouldBeRight<TLeft, TRight>(this Either<TLeft, TRight> @this, Action<TRight> rightValidation)
            => @this.Match(rightValidation, _ => throw new Exception("Expected Right, got Left instead."));

        public static void ShouldBeLeft<TLeft, TRight>(this Either<TLeft, TRight> @this, Action<TLeft> leftValidation)
            => @this.Match(_ => throw new Exception("Expected Left, got Right instead."), leftValidation);
    }
}
