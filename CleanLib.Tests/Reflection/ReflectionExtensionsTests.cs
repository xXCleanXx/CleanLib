using CleanLib.Reflection.Extensions;
using NUnit.Framework;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace CleanLib.Tests.Reflection;

[TestFixture]
public class ReflectionExtensionsTests {
    private enum Test {
        [Description("Test1")]
        Test1,
        [Description("Test2")]
        wer
    }

    [Test]
    public void GetEnumDescription() {
        Assert.AreEqual("Test1", Test.Test1.GetEnumDescription());
        Assert.AreEqual("Test2", Test.wer.GetEnumDescription());
    }
}