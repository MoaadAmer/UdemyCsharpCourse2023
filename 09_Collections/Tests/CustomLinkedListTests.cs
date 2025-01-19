
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
        Assert.IsNotNull(linkedList.Tail);
        Assert.AreEqual("10", linkedList.Tail.Data);
        Assert.AreEqual(1, linkedList.Count);


        linkedList.Add("hello world");

        Assert.IsNotNull(linkedList.Head);
        Assert.AreEqual("10", linkedList.Head.Data);
        Assert.IsNotNull(linkedList.Tail);
        Assert.AreEqual("hello world", linkedList.Tail.Data);
        Assert.AreEqual(2, linkedList.Count);



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

    [TestMethod]
    public void CopyToTest()
    {
        //copy at index 0
        var linkedList = new CustomLinkedList<int>();
        var array = new int[5];

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        linkedList.CopyTo(array, 0);

        Assert.AreEqual(1, array[0]);
        Assert.AreEqual(2, array[1]);
        Assert.AreEqual(3, array[2]);
        Assert.AreEqual(4, array[3]);
        Assert.AreEqual(0, array[4]);


        //copy at index 1
        linkedList = new CustomLinkedList<int>();
        array = new int[5];

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        linkedList.CopyTo(array, 1);

        Assert.AreEqual(0, array[0]);
        Assert.AreEqual(1, array[1]);
        Assert.AreEqual(2, array[2]);
        Assert.AreEqual(3, array[3]);
        Assert.AreEqual(4, array[4]);

        //Given null array
        Assert.ThrowsException<ArgumentNullException>(() => linkedList.CopyTo(null, 5));

        //Given Invalid index
        Assert.ThrowsException<ArgumentOutOfRangeException>(() => linkedList.CopyTo(array, 10));


        linkedList = new CustomLinkedList<int>();
        array = new int[1];

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        //Given not long enough array
        Assert.ThrowsException<ArgumentException>(() => linkedList.CopyTo(array, 0));



    }


    [TestMethod]
    public void RemoveNotExistingItemTest()
    {
        var linkedList = new CustomLinkedList<int>();

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        Assert.IsFalse(linkedList.Remove(99));
        Assert.AreEqual(4, linkedList.Count);
    }


    [TestMethod]
    public void RemoveHeadTest()
    {
        var linkedList = new CustomLinkedList<int>();

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        Assert.IsTrue(linkedList.Remove(1));
        Assert.AreEqual(2, linkedList.Head.Data);
        Assert.AreEqual(3, linkedList.Head.Next.Data);
        Assert.AreEqual(3, linkedList.Count);
    }

    [TestMethod]
    public void RemoveMiddleTest()
    {
        var linkedList = new CustomLinkedList<int>();

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        Assert.IsTrue(linkedList.Remove(2));
        Assert.AreEqual(1, linkedList.Head.Data);
        Assert.AreEqual(3, linkedList.Head.Next.Data);
        Assert.AreEqual(3, linkedList.Count);
    }

    [TestMethod]
    public void RemoveTailTest()
    {
        var linkedList = new CustomLinkedList<int>();

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        Assert.IsTrue(linkedList.Remove(4));
        Assert.AreEqual(1, linkedList.Head.Data);
        Assert.AreEqual(2, linkedList.Head.Next.Data);
        Assert.AreEqual(3, linkedList.Tail.Data);
        Assert.AreEqual(null, linkedList.Tail.Next);
        Assert.AreEqual(3, linkedList.Count);
    }


    [TestMethod]
    public void ClearTest()
    {
        var linkedList = new CustomLinkedList<int>();

        linkedList.AddToEnd(1);
        linkedList.AddToEnd(2);
        linkedList.AddToEnd(3);
        linkedList.AddToEnd(4);

        linkedList.Clear();

        Assert.AreEqual(null, linkedList.Head);
        Assert.AreEqual(null, linkedList.Head);
        Assert.AreEqual(0, linkedList.Count);


    }
}
