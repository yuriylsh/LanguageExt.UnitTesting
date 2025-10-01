using System;
using LanguageExt.Common;

namespace LanguageExt.UnitTesting
{
    public static class ResultExtensions
    {
        public static void ShouldBeSuccess<T>(this Result<T> @this, Action<T> successValidation = null)
        {
            _ = @this.Match(
                Succ: s =>
                {
                    successValidation?.Invoke(s);
                    return Prelude.None;
                },
                Fail: e =>
                {
                    Common.ThrowIfFail(e);
                    return Prelude.None;
                });
        }
        
        public static void ShouldBeFail<T>(this Result<T> @this, Action<Error> failValidation = null)
        {
            _ = @this.Match(
                Succ: s =>
                {
                    Common.ThrowIfSuccess(s);
                    return Prelude.None;
                },
                Fail: e =>
                {
                    failValidation?.Invoke(e);
                    return Prelude.None;
                });
        }
    }
}