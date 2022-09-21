using NUnit.Framework;
using CleanLib.Strings.Extensions;

namespace CleanLib.Tests.Strings;

public class StringsTests {
    [Test]
    public void IsNumeric() {
        Assert.IsTrue("1234".IsNumeric());
        Assert.IsFalse("abcd".IsNumeric());
    }
    
    [Test]
    public void FirstToUpper() => Assert.AreEqual("Test", "test".FirstToUpper());
}