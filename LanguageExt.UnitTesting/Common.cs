using System;

namespace LanguageExt.UnitTesting
{
    internal static class Common
    {
        internal static void ThrowIfSome<T>(T _)
            => throw new Exception("Some: not expected.");

        internal static void ThrowIfNone()
            => throw new Exception("None: not expected.");

        internal static void SuccessfulNone()
        { 
            /* we should end up in here*/
        }
    }
}