using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using static LanguageExt.Prelude;

namespace LanguageExt.UnitTesting.Tests
{
    public static class TestsHelper
    {
        public static void ValidationNoop<T>(T _) {}

        public class EitherGenerator: IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                Either<int, string> left = 123;
                Either<int, string> right = "right";
                yield return new object[] {left};
                yield return new object[] {right};
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class OptionGenerator: IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                Option<string> none = None;
                Option<string> some = "some";
                yield return new object[] {none};
                yield return new object[] {some};
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class ValidationGenerator: IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                Validation<int, string> fail = 123;
                Validation<int, string> success = "success";
                yield return new object[] {fail};
                yield return new object[] {success};
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class TryGenerator: IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                Try<string> fail = () => throw new Exception();
                Try<string> success = () => "success";
                yield return new object[] {fail };
                yield return new object[] {success};
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class TryAsyncGenerator: IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                var fail = TryAsync<string>(() => throw new Exception());
                var success = TryAsync(() => Task.FromResult("success"));
                yield return new object[] {fail };
                yield return new object[] {success};
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}