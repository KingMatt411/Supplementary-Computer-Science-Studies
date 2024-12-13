using DSAExercisesProject.Sorting.MergeSort;
using DSAExercisesProject.Sorting.QuickSort;

namespace DSAExercisesProject;
class Program
{
    static void Main(string[] args)
    {
        SinglyLinkedListNode<char> alphabetStart = new SinglyLinkedListNode<char>('a');
        
        SinglyLinkedList<char> alphabet = new SinglyLinkedList<char>(alphabetStart);
        
        alphabet.AddNodeAtEnd('b');
        alphabet.AddNodeAtEnd('c');
        alphabet.AddNodeAtEnd('d');
        alphabet.AddNodeAtEnd('e');
        alphabet.AddNodeAtEnd('f');

        alphabet.PrintLinkedList();
        alphabet.Reverse();
        alphabet.PrintLinkedList();

    }
}

class SinglyLinkedList<T> where T : IEquatable<T>
{
    public SinglyLinkedListNode<T>? Root { get; set; }
    
    public SinglyLinkedList()
    {
        Root = default;
    }
    
    public SinglyLinkedList(SinglyLinkedListNode<T> node)
    {
        Root = node;
    }

    public void AddNodeAtEnd(T value)
    {
        SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);
        GetEndNode().Next = newNode;
    }

    public void AddNodeAtStart(T value)
    {
        SinglyLinkedListNode<T> newNode = new SinglyLinkedListNode<T>(value);
        newNode.Next = Root;
        Root = newNode;
    }

    public SinglyLinkedListNode<T> GetEndNode()
    {
        return GetEndNodeReference(Root);
    }

    private SinglyLinkedListNode<T> GetEndNodeReference(SinglyLinkedListNode<T> node)
    {
        if (node.Next != null)
        {
            return GetEndNodeReference(node.Next);
        }
        
        return node;
    }

    public void DeleteNodeByValue(T value)
    {
        SinglyLinkedListNode<T> beforeDeletable = GetPrecedingNodeByValue(value); // Get the node before the one to be deleted
        beforeDeletable.Next = beforeDeletable.Next!.Next; // Update the pointer in the node before the one to be deleted to point to the one after the one to be deleted
    }
    
    private SinglyLinkedListNode<T> GetPrecedingNodeByValue(T value)
    {
        return GetPrecedingNodeReferenceByValue(Root, value);
    }

    private SinglyLinkedListNode<T> GetPrecedingNodeReferenceByValue(SinglyLinkedListNode<T> node, T value)
    {
        if (node.Next.Data.Equals(value)) return node;

        return GetPrecedingNodeReferenceByValue(node.Next, value);
        
    }

    public void Reverse()
    {
        SinglyLinkedListNode<T>? prev = null;
        SinglyLinkedListNode<T>? current = Root;
        SinglyLinkedListNode<T>? next = null;

        while (current != null)
        {
            next = current.Next;
            current.Next = prev;
            prev = current;
            current = next;
        }
    }


    public void PrintLinkedList()
    {
        SinglyLinkedListNode<T> node = Root;
        while (node.Next != null)
        {
            Console.Write(node.Data + " ");
            node = node.Next;
        }

        Console.WriteLine();
    }
    
}

class SinglyLinkedListNode<T>
{
    public T? Data { get; set; }

    public SinglyLinkedListNode<T>? Next { get; set; }
    
    public SinglyLinkedListNode()
    {
        Data = default;
        Next = null;
    }
    
    public SinglyLinkedListNode(T data)
    {
        Data = data;
    }
}
