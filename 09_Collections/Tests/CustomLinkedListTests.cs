
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
    [TestMethod]
    public void CountTest()
    {
        var linkedList = new CustomLinkedList<int>();

        Assert.IsNotNull(linkedList.Count);
        Assert.AreEqual(0, linkedList.Count);

        linkedList.AddToFront(10);

        Assert.IsNotNull(linkedList.Count);
        Assert.AreEqual(1, linkedList.Count);

        linkedList.AddToEnd(7);

        Assert.IsNotNull(linkedList.Count);
        Assert.AreEqual(2, linkedList.Count);

        linkedList.Add(-50);

        Assert.IsNotNull(linkedList.Count);
        Assert.AreEqual(3, linkedList.Count);

    }

    [TestMethod]
    public void AddTest()
    {
        var linkedList = new CustomLinkedList<string>();

        linkedList.Add("10");

        Assert.IsNotNull(linkedList.Head);
        Assert.AreEqual("10", linkedList.Head.Data);

        linkedList.Add("hello world");

        Assert.IsNotNull(linkedList.Head);
        Assert.AreEqual("hello world", linkedList.Head.Data);

        Assert.IsNotNull(linkedList.Tail);
        Assert.AreEqual("10", linkedList.Tail.Data);
    }

    [TestMethod]
    public void ContainsTest()
    {
        var linkedList = new CustomLinkedList<string>();


        Assert.IsFalse(linkedList.Contains("hello world"));

        linkedList.Add("10");
        linkedList.Add("hello world");
        linkedList.AddToFront("aa");
        linkedList.AddToEnd("bb");

        Assert.IsTrue(linkedList.Contains("10"));

        Assert.IsTrue(linkedList.Contains("hello world"));

        Assert.IsFalse(linkedList.Contains("hello world__"));
    }
}
