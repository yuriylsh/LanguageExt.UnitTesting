using System;
using System.Collections.Generic;

namespace LanguageExt.UnitTesting
{
    public static class ValidationExtentions
    {
        public static void ShouldBeSuccess<TFail, TSuccess>(this Validation<TFail, TSuccess> @this, Action<TSuccess> successValidation)
            => @this.Match(successValidation, Common.ThrowIfFail);

        public static void ShouldBeFail<TFail, TSuccess>(this Validation<TFail, TSuccess> @this, Action<IEnumerable<TFail>> failValidation)
            => @this.Match(Common.ThrowIfSuccess, failValidation);
    }
}