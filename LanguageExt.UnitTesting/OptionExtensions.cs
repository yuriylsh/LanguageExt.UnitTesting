using System;

namespace LanguageExt.UnitTesting
{
    public static class OptionExtensions
    {
        public static void ShouldBeSome<T>(this Option<T> @this, Action<T> someValidation)
            => @this.Match(
                Some: someValidation,
                None: Common.ThrowIfNone);

        public static void ShouldBeNone<T>(this Option<T> @this)
            => @this.Match(
                Some: Common.ThrowIfSome,
                None: Common.SuccessfulNone);
    }
}