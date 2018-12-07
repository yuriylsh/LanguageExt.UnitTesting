using System;
using System.Threading.Tasks;

namespace LanguageExt.UnitTesting
{
    public static class TryAsyncExtensions
    {
        public static async Task ShouldBeSuccess<T>(this TryAsync<T> @this,
                                                    Action<T> successValidation = null)
            => await @this.Match(
                Succ: successValidation ?? Common.Noop,
                Fail: _ => throw new Exception("Expected Success, got Fail instead.")
            );

        public static async Task ShouldBeFail<T>(this TryAsync<T> @this,
                                                 Action<Exception> failValidation = null)
            => await @this.Match<T>(Succ: _ => throw new Exception("Expected Fail, got Success instead."),
                                    Fail: failValidation ?? Common.Noop);
    }
}