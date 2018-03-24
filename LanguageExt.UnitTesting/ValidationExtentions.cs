using System;
using System.Collections.Generic;

namespace LanguageExt.UnitTesting
{
    public static class ValidationExtentions
    {
        public static void ShouldSucceed<TFail, TSuccess>(this Validation<TFail, TSuccess> @this, Action<TSuccess> assert)
            => @this.Match(assert, _ => throw new Exception("Expected Success, got Fail instead."));

        public static void ShouldFail<TFail, TSuccess>(this Validation<TFail, TSuccess> @this, Action<IEnumerable<TFail>> assert)
            => @this.Match(_ => throw new Exception("Expected Fail, got Success instead."), assert);
    }
}