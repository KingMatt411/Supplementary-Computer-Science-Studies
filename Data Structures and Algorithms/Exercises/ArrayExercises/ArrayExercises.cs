using System;

namespace ArrayExercises;

class Exercises {

    public static void RunExercises() {

        Console.WriteLine();
        TestInsertAtIndex(new int[] { 1, 3, 7, 9 }, 5, 2);
        Console.WriteLine();

        TestInsertAtIndex(new int[] { 0, 1 }, 1, 0);
        Console.WriteLine();

        TestDeleteAtIndex(new int[] { 10, 20, 30, 40, 50 }, 2);
        Console.WriteLine();

        TestDeleteAtIndex(new int[] { 1, 2, 3 }, 2);
        Console.WriteLine();
    }

    public static void TestInsertAtIndex(int[] arr, int value, int index) {

        Console.Write($"Insert value {value} to array ");
        foreach (int i in arr) { Console.Write(i + " "); }
        Console.WriteLine();
        
        int[] updatedArray = InsertAtIndex(arr, value, index);

        Console.Write("Result: ");
        
        for(int i = 0; i < updatedArray.Length; i++) {
            Console.Write(updatedArray[i] + " ");
        }
        Console.WriteLine();
    }

    public static int[] InsertAtIndex(int[] arr, int value, int index) {

        int[] newArr = new int[arr.Length + 1];

        Array.Copy(arr, 0, newArr, 0, index);
        newArr[index] = value;
        Array.Copy(arr, index, newArr, index + 1, arr.Length - index);

        Console.WriteLine($"Added value \"{value}\" at index {index}.");

        return newArr;
    }

    public static void TestDeleteAtIndex(int[] arr, int index) {
        Console.Write($"Delete index \"{index}\" from array: ");
        foreach(int i in arr) { Console.Write(i + " "); }
        Console.WriteLine();
        int[] updatedArray = DeleteAtIndex(arr, index);        
        Console.Write("Result: ");
        foreach(int i in updatedArray) {
            Console.Write(i + " ");
        }
        Console.WriteLine();
    }

    public static int[] DeleteAtIndex(int[] arr, int index) {

        int[] newArr = new int[arr.Length - 1];

        Array.Copy(arr, 0, newArr, 0, index);
        Array.Copy(arr, index + 1, newArr, index, arr.Length - index - 1);

        Console.WriteLine($"Removed value {arr[index]} from array.");
        return newArr;
    }
}















