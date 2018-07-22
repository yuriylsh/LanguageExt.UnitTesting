using System;
using Xunit;
using static LanguageExt.UnitTesting.Tests.TestsHelper;

namespace LanguageExt.UnitTesting.Tests
{
    public class OptionExtensionsTests
    {
        [Theory]
        [ClassData(typeof(OptionGenerator))]
        public void ShouldBeX_GiveOtherSide_Throws(Option<string> option)
        {
            Action act = null;
            option.Match(
                some => act = () => option.ShouldBeNone(),
                () => act = () => option.ShouldBeSome(ValidationNoop));

            Assert.Throws<Exception>(act);
        }

        [Theory]
        [ClassData(typeof(OptionGenerator))]
        public void ShouldBeX_GivenCorrectOption_ExecutesValidaion(Option<string> option)
        {
            Action validation = null;
            option.Match(
                some => validation = SomeValidation,
                () => validation = NoneValidation);

            validation();

            void SomeValidation()
            {
                var validationSideEffect = false;
                option.ShouldBeSome(x => validationSideEffect = true);
                Assert.True(validationSideEffect);
            }

            void NoneValidation()
            {
                option.ShouldBeNone();
            }
        }
    }
}
