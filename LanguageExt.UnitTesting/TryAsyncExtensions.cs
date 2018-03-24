using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class TryAsyncExtensions
    {
        public static async Task ShouldBeSuccess<T>(this TryAsync<T> @this, Action<T> successValidation)
            => await @this.Match(
                Succ: successValidation,
                Fail: ex => throw ex
            );

        public static async Task ShouldBeFail<T>(this TryAsync<T> @this, Action<Exception> failValidation)
            => await @this.Match(
                Succ: Common.ThrowIfSome,
                Fail: ex => failValidation(ex)
            );
    }
}