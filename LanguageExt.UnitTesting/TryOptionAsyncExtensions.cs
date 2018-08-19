using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class TryOptionAsyncExtensions
    {
        public static async Task ShouldBeSome<T>(this TryOptionAsync<T> @this, Action<T> someValidation)
            => await @this.Match(
                Some: someValidation,
                None: Common.ThrowIfNone,
                Fail: ex => throw ex
            );

        public static async Task ShouldBeNone<T>(this TryOptionAsync<T> @this)
            => await @this.Match(
                Some: _ => throw new Exception("Expected None, got Some instead."),
                None: Common.SuccessfulNone,
                Fail: ex => throw ex
            );
        
        public static async Task ShouldBeFail<T>(this TryOptionAsync<T> @this, Action<Exception> failValidation)
            => await @this.Match(
                Some: _ => throw new Exception("Expected Fail, got Some instead"),
                None: () => throw new Exception("Expected Fail, got None instead"),
                Fail: ex => failValidation(ex)
            );
    }
}