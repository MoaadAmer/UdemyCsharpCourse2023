namespace _09_Collections;

public class Node<T>
{
    private T? _data;
    private Node<T>? _next;

    public Node(T? item, Node<T>? next)
    {
        _data = item;
        _next = next;
    }

    public T? Data { get => _data; set => _data = value; }
    public Node<T>? Next { get => _next; set => _next = value; }


}