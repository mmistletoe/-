using System;

public class Node<T>
{
    public T Value { get; set; }
    public Node<T> Next { get; set; }

    public Node(T value)
    {
        Value = value;
        Next = null;
    }
}

public class LinkedList<T>
{
    public Node<T> Head { get; private set; }
    public Node<T> Tail { get; private set; }
    public int Count { get; private set; }

    public LinkedList()
    {
        Head = null;
        Tail = null;
        Count = 0;
    }

    public void Add(T value)
    {
        var newNode = new Node<T>(value);
        if (Count == 0)
        {
            Head = newNode;
            Tail = newNode;
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
        }
        Count++;
    }

    // 添加ForEach方法  
    public void ForEach(Action<T> action)
    {
        Node<T> current = Head;
        while (current != null)
        {
            action(current.Value);
            current = current.Next;
        }
    }
}

class Program
{
    static void Main()
    {
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.Add(1);
        linkedList.Add(5);
        linkedList.Add(3);
        linkedList.Add(7);
        linkedList.Add(2);

        // 打印链表元素  
        linkedList.ForEach(element => Console.WriteLine(element));

        // 求最大值  
        int max = linkedList.ForEachMax(element => element);
        Console.WriteLine("Max value: " + max);

        // 求最小值  
        int min = linkedList.ForEachMin(element => element);
        Console.WriteLine("Min value: " + min);

        // 求和  
        int sum = linkedList.ForEachSum(element => element);
        Console.WriteLine("Sum: " + sum);
    }
}

// 为LinkedList<T>类添加求最大值、最小值和求和的扩展方法  
public static class LinkedListExtensions
{
    public static T ForEachMax<T>(this LinkedList<T> linkedList, Func<T, T> selector) where T : IComparable<T>
    {
        T max = default(T);
        bool hasValue = false;
        linkedList.ForEach(element =>
        {
            T current = selector(element);
            if (!hasValue || current.CompareTo(max) > 0)
            {
                max = current;
                hasValue = true;
            }
        });
        return max;
    }

    public static T ForEachMin<T>(this LinkedList<T> linkedList, Func<T, T> selector) where T : IComparable<T>
    {
        T min = default(T);
        bool hasValue = false;
        linkedList.ForEach(element =>
        {
            T current = selector(element);
            if (!hasValue || current.CompareTo(min) < 0)
            {
                min = current;
                hasValue = true;
            }
        });
        return min;
    }

    public static T ForEachSum<T>(this LinkedList<T> linkedList, Func<T, T> selector) where T : struct
    {
        dynamic sum = 0; // 使用dynamic来处理不同的数值类型  
        linkedList.ForEach(element =>
        {
            sum += selector(element);
        });
        return (T)sum;
    }
}