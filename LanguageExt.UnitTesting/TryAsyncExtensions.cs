using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class TryAsyncExtensions
    {
        public static async Task ShouldBeSuccess<T>(this TryAsync<T> @this, Action<T> successValidation)
            => await @this.Match(
                Succ: successValidation,
                Fail: _ => throw new Exception("Expected Success, got Fail instead.")
            );

        public static async Task ShouldBeFail<T>(this TryAsync<T> @this, Action<Exception> failValidation)
            => await @this.Match<T>(_ => throw new Exception("Expected Fail, got Success instead."), failValidation);
    }
}