using System;
using LanguageExt.Common;

namespace LanguageExt.UnitTesting
{
    public static class FinExtensions
    {
        public static void ShouldBeSuccess<TSuccess>(this Fin<TSuccess> @this,
            Action<TSuccess> successFin = null)
            => @this.Match(successFin ?? Common.Noop, Common.ThrowIfFail);

        public static void ShouldBeFail<TSuccess>(this Fin<TSuccess> @this,
            Action<Error> errFin = null)
            => @this.Match(Common.ThrowIfSuccess, errFin ?? Common.Noop);
    }
}