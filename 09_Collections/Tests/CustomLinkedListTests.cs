
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

        Assert.IsNotNull(linkedList.Head);
        Assert.AreEqual(1, linkedList.Head.Data);

        linkedList.AddToFront(2);

        Assert.IsNotNull(linkedList.Head);
        Assert.AreEqual(2, linkedList.Head.Data);
    }

    [TestMethod]
    public void AddToEndTest()
    {
        var linkedList = new CustomLinkedList<int>();

        linkedList.AddToEnd(1);

        Assert.IsNotNull(linkedList.Tail);
        Assert.AreEqual(1, linkedList.Tail.Data);

        linkedList.AddToEnd(2);

        Assert.IsNotNull(linkedList.Tail);
        Assert.AreEqual(2, linkedList.Tail.Data);

    }
}
