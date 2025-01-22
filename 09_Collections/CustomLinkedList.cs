﻿using System.Collections;

namespace _09_Collections
{
    public class CustomLinkedList<T> : ILinkedList<T>
    {
        public Node<T>? Head { get; private set; }
        public Node<T>? Tail { get; private set; }

        public CustomLinkedList()
        {
        }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            AddToEnd(item);
        }

        public void AddToEnd(T item)
        {
            if (Tail is null)
            {
                Head = Tail = new Node<T>(item, null);
            }

            else
            {
                var newTail = new Node<T>(item, null);
                Tail.Next = newTail;
                Tail = newTail;
            }
            Count++;
        }

        public void AddToFront(T item)
        {
            if (Head == null)
            {
                Head = Tail = new Node<T>(item, null);
            }
            else
            {
                var newHead = new Node<T>(item, Head);
                Head = newHead;
            }
            Count++;
        }

        public void Clear()
        {
            Node<T> current = Head;
            while (current != null)
            {
                Node<T> temp = current;
                current = current.Next;
                temp.Next= null;

            }
            Head = Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            var temp = Head;
            while (temp != null && temp.Value != null)
            {
                if (temp.Value.Equals(item))
                {
                    return true;
                }
                temp = temp.Next;
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            ArgumentNullException.ThrowIfNull(array);
            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("array index is invalid");
            }
            if (array.Length < Count)
            {
                throw new ArgumentException("array size is smaller than the linked list");
            }

            var temp = Head;
            for (int i = arrayIndex; (i - arrayIndex) < Count; i++)
            {
                array[i] = temp.Value;
                temp = temp.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in GetNodes())
            {
                yield return node.Value;
            }
        }

        public bool Remove(T item)
        {
            var temp = Head;
            if (temp != null && temp.Value != null && temp.Value.Equals(item))
            {

                Head = temp.Next;
                temp.Next = null;
                temp = null;
                Count--;
                return true;
            }
            while (temp != null && temp.Next != null)
            {
                if (temp.Next.Value != null && temp.Next.Value.Equals(item))
                {
                    //Tail
                    if (temp.Next.Next == null)
                    {
                        temp.Next = null;
                        Tail = temp;
                    }
                    else
                    {
                        temp.Next = temp.Next.Next;
                        temp.Next.Next = null;
                    }
                    Count--;
                    return true;
                }

                temp = temp.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private IEnumerable<Node<T>> GetNodes()
        {
            var current = Head;
            while (current != null)
            {
                yield return current;
                current = current.Next;
            }
        }
    }
}
