using System.Collections;

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

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T item)
        {
            AddToFront(item);
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
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            var temp = Head;
            while (temp != null && temp.Data != null)
            {
                if (temp.Data.Equals(item))
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
                array[i] = temp.Data;
                temp = temp.Next;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }



    public interface ILinkedList<T> : ICollection<T>
    {
        void AddToFront(T item);
        void AddToEnd(T item);
    }
}
