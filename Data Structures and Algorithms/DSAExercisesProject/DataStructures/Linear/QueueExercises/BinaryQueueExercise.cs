namespace DSAExercisesProject.DataStructures.Linear.QueueExercises;

class BinaryExercise {

    /// <summary>
    /// Prints the integers from 1 to unsigned 32-bit integer `n` in binary format.
    /// </summary>
    /// <param name="n">The highest (end) number in the sequence, in decimal format.</param>
    public void PrintBinarySequence(uint n)
    {
        if (n < 1) throw new InvalidOperationException("Non-positive integer used.");

        Queue<string> queue = new Queue<string>();

        for (uint i = n; i < n; i++)
        {
            queue.Enqueue(Convert.ToString(n, 2));
        }

        while (queue.Count > 0)
        {
            Console.Write(queue.Dequeue() + " ");
        }
    }
}