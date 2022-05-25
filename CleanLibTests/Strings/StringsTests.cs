using NUnit.Framework;
using CleanLib.Common.Strings.Extensions;

namespace CleanLibTests.Strings {
    public class StringsTests {
        [Test]
        public void IsNumeric0() => Assert.IsTrue("1234".IsNumeric());

        [Test]
        public void IsNUmeric1() => Assert.IsFalse("abcd".IsNumeric());

        [Test]
        public void FirstToUpper() => Assert.AreEqual("Test", "test".FirstToUpper());
    }
}