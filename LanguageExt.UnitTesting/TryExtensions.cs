using System;

namespace LanguageExt.UnitTesting
{
    public static class TryExtensions
    {
        public static void ShouldBeSuccess<T>(this Try<T> @this,
                                              Action<T> successValidation = null)
            => @this.Match(successValidation ?? Common.Noop, Common.ThrowIfFail);

        public static void ShouldBeFail<T>(this Try<T> @this,
                                           Action<Exception> failValidation = null)
            => @this.Match(Common.ThrowIfSuccess,
                           failValidation ?? Common.Noop);
    }
}