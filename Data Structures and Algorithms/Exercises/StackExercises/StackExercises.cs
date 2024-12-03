namespace Exercises.StackExercises;

public class Exercises
{
    public static void RunExercises()
    {
        Console.WriteLine("Reversing string \"hello\": ");
        Console.WriteLine(ReverseCharacters("hello"));
    }

    private static string? ReverseCharacters(string input)
    {
        Stack<char> charStack = new Stack<char>();
        
        for (int i = 0; i < input.Length; i++)
        {
            charStack.Push(input[i]);
        }

        string reversedInput = string.Empty;

        while (charStack.Count > 0)
        {
            reversedInput += charStack.Pop();
        }

        return reversedInput;
    }
    
}