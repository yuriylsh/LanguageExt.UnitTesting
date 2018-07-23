using System;

namespace LanguageExt.UnitTesting
{
    public static class TryExtensions
    {
        public static void ShouldBeSuccess<T>(this Try<T> @this, Action<T> successValidation)
            => @this.Match(successValidation, Common.ThrowIfFail);

        public static void ShouldBeFail<T>(this Try<T> @this, Action<Exception> failValidation)
            => @this.Match(Common.ThrowIfSuccess, failValidation);
    }
}