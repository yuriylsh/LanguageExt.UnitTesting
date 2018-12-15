using System;

namespace LanguageExt.UnitTesting
{
    public static class TryOptionExtensions
    {
        public static void ShouldBeSome<T>(this TryOption<T> @this, Action<T> someValidation = null)
            => @this.Match(
                Some: someValidation ?? Common.Noop,
                None: Common.ThrowIfNone,
                Fail: ex => throw ex
            );

        public static void ShouldBeNone<T>(this TryOption<T> @this)
            => @this.Match(
                Some: Common.ThrowIfSome,
                None: Common.SuccessfulNone,
                Fail: ex => throw ex
            );

        public static void ShouldBeFail<T>(this TryOption<T> @this, Action<Exception> failValidation = null)
            => @this.Match(
                Some: Common.ThrowExpectedFailGotSome,
                None: Common.ThrowExpectedFailGotNone,
                Fail: ex => (failValidation ?? Common.Noop)(ex)
        );
    }
}
