namespace DSAExercisesProject.DataStructures.Linear.QueueExercises;

/// <summary>
/// A circular queue where the 
/// </summary>
/// <typeparam name="T"></typeparam>
class CircularQueue<T> {

    private int _head = -1;
    private int _tail = -1;
    private int _count = 0;
    public int Count => _count;
    private readonly int _capacity;
    private readonly T[] _queue;

    public CircularQueue(int capacity)
    {
        if (capacity < 1) throw new InvalidOperationException("Capacity must be a positive integer.");
        _capacity = capacity;

        _queue = new T[_capacity];
    }
    

    public void Enqueue(T item)
    {
        if ((_tail + 1) % _capacity == _head)
        {
            Console.WriteLine("Queue is full.");
            return;
        }

        if (_head == -1)
        {
            _head = 0;
        }

        _tail = (_tail + 1) % _capacity;
        _queue[_tail] = item;
        _count++;
    }
    
    public T Dequeue()
    {
        if (_count < 1) throw new InvalidOperationException("Queue is empty.");

        T item = _queue[_head];
        _head = (_head + 1) % _capacity;
        _count--;

        if (_count == 0)
        {
            _head = -1;
            _tail = -1;
        }
        
        return item;
    }

}
