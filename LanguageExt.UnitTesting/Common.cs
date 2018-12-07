﻿using System;

namespace LanguageExt.UnitTesting
{
    internal static class Common
    {
        internal static void ThrowIfSome<T>(T _)
            => throw new Exception("Expected None, got Some instead.");

        internal static void ThrowIfNone()
            => throw new Exception("Expected Some, got None instead.");

        internal static void ThrowIfFail<T>(T _)
            => throw new Exception("Expected Success, got Fail instead.");

        internal static void ThrowIfSuccess<T>(T _)
            => throw new Exception("Expected Fail, got Success instead.");

        internal static void ThrowIfRight<T>(T _)
            => throw new Exception("Expected Left, got Right instead.");

        internal static void ThrowIfLeft<T>(T _)
            => throw new Exception("Expected Right, got Left instead.");

        internal static void ThrowExpectedFailGotSome<T>(T _)
            => throw new Exception("Expected Fail, got Some instead.");

        internal static void ThrowExpectedFailGotNone()
            => throw new Exception("Expected Fail, got None instead.");

        internal static void SuccessfulNone()
        { 
            /* we should end up in here*/
        }

        internal static void Noop<T>(T _) {} 
    }
}