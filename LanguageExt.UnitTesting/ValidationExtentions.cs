using System;
using System.Collections.Generic;

namespace LanguageExt.UnitTesting
{
    public static class ValidationExtentions
    {
        public static void ShouldBeSuccess<TFail, TSuccess>(this Validation<TFail, TSuccess> @this, Action<TSuccess> successValidation)
            => @this.Match(successValidation, _ => throw new Exception("Expected Success, got Fail instead."));

        public static void ShouldBeFail<TFail, TSuccess>(this Validation<TFail, TSuccess> @this, Action<IEnumerable<TFail>> failValidation)
            => @this.Match(_ => throw new Exception("Expected Fail, got Success instead."), failValidation);
    }
}