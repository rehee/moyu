using MoYu.Common;
using NUnit.Framework;

namespace MoYu.Tests
{
  public class Tests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
      var list1 = new int[] { 1, 2, 3, 4, 5 };
      var result = list1.GetRandomIn(4);
      Assert.AreEqual(result.Count, 4);

    }
  }
}