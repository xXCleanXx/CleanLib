using CleanLib.Reflection.Extensions;
using NUnit.Framework;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace CleanLib.Tests.Annotations;

public class ReflectionExtensionsTests {
    private enum Test {
        [Description("Test1")]
        Test1,
        [Description("Test2")]
        Test2
    }

    [Test]
    public void GetEnumDescription() {
        Assert.AreEqual("Test1", Test.Test1.GetEnumDescription());
        Assert.AreEqual("Test2", Test.Test2.GetEnumDescription());
    }
}