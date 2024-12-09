using System;
using System.Collections.Generic;
namespace Exercises.LinkedListExercises
{

    class Exercises {

        public static void RunExercises()
        {
            FirstExercise();
        }

        private static void FirstExercise()
        {

            LinkedList<int> intLl = new LinkedList<int>(new int[] {10, 20, 30, 40});

            intLl.AddFirst(5);
            PrintLinkedList(intLl);

            LinkedListNode<int> node = intLl.Find(20);
            if (node != null)
            {
                intLl.AddAfter(node, 25);
            }
            else
            {
                Console.WriteLine("Node with value 20 not found");
            }
            PrintLinkedList(intLl);

            intLl.Remove(30);
            PrintLinkedList(intLl);

        }

        private static void PrintLinkedList(LinkedList<int> ll)
        {
            foreach (int value in ll)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();
        }
        
    }
}
