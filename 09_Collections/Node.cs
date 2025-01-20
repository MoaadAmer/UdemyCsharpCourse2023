namespace _09_Collections;

public class Node<T>
{
    public Node(T? item, Node<T>? next)
    {
        Value = item;
        Next = next;
    }

    public T? Value { get; set; }
    public Node<T>? Next { get; set; }


}