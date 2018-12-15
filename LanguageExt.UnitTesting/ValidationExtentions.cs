using System;
using System.Collections.Generic;

namespace LanguageExt.UnitTesting
{
    public static class ValidationExtentions
    {
        public static void ShouldBeSuccess<TFail, TSuccess>(this Validation<TFail, TSuccess> @this,
                                                            Action<TSuccess> successValidation = null)
            => @this.Match(successValidation ?? Common.Noop, Common.ThrowIfFail);

        public static void ShouldBeFail<TFail, TSuccess>(this Validation<TFail, TSuccess> @this,
                                                         Action<IEnumerable<TFail>> failValidation = null)
            => @this.Match(Common.ThrowIfSuccess, failValidation ?? Common.Noop);
    }
}