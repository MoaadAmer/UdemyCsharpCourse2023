
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _09_Collections.Tests;

[TestClass]
public class CustomLinkedListTests
{
    [TestMethod]
    public void AddToFrontTest()
    {
        var linkedList = new CustomLinkedList<int>();
        linkedList.AddToFront(1);
        linkedList.AddToFront(2);

        Assert.IsNotNull(linkedList.Head);
        Assert.AreEqual(2, linkedList.Head.Data);
    }
}
