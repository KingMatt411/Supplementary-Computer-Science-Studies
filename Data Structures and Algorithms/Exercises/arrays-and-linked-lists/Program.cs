using System;

namespace arrays_and_linked_lists;

class Program
{
    static void Main(string[] args)
    {
        RunArrayExercises();
        int[] test = { 2, 4, 6, 8, 12 };

        int[] output = InsertAtIndex(test, 10, 4);
        foreach (int i in output) {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    private static void RunArrayExercises() {

        // Create array
        int[] intArray = { 10, 20, 30, 40, 50 };

        // Access the 3rd element
        Console.WriteLine($"3rd element: {intArray[2]}");

        // Inserting `25` at index 2
        int[] newIntArray = new int[6];

        for(int i = 0; i < 2; i++) {
            newIntArray[i] = intArray[i];
        }

        newIntArray[2] = 25;

        for(int i = 2; i < intArray.Length; i++) {
            newIntArray[i + 1] = intArray[i];
        }

        // Print updated array
        Console.Write("Updated array: ");
        for(int i = 0; i < newIntArray.Length; i++) {
            Console.Write(newIntArray[i] + " ");
        }
        Console.WriteLine();
        
        // Remove node with value `30`
        int[] reducedArray = new int[4];

        for(int i = 0; i < 2; i++) {
            reducedArray[i] = intArray[i];
        }

        for(int i = 3; i < intArray.Length; i++) {
            reducedArray[i - 1] = intArray[i];
        }

        // Print updated array
        Console.Write($"Updated array: ");
        foreach (int i in reducedArray) {
            Console.Write(i + " ");
        }
        Console.WriteLine();

        // Delete the element at index `4`
        int[] finalArray = new int[4];

        for(int i = 0; i < 4; i++) {
            finalArray[i] = intArray[i];
        }

        // Print updated array
        Console.Write("Updated array: ");
        for(int i = 0; i < finalArray.Length; i++) {
            Console.Write(finalArray[i] + " ");
        }
        Console.WriteLine();

    }

    private static int[] InsertAtIndex(int[] arr, int value, int index) {

        int[] newArray = new int[arr.Length + 1];

        Array.Copy(arr, 0, newArray, 0, index);
        newArray[index] = value;
        Array.Copy(arr, index, newArray, index + 1, arr.Length - index);

        return newArray;
    }

































}
