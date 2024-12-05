namespace Exercises.StackExercises;

public static class Exercises
{
    public static void RunExercises()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
            string options = """
                             1. Reverse input string
                             2. Check if parentheses are balanced
                             """;

            Console.WriteLine(options);
            string chosenOption = Console.ReadLine() ?? "-1";
        
            Console.Write("Enter input: ");
            string input = Console.ReadLine() ?? string.Empty;

            switch (chosenOption)
            {
                case "1":
                    Console.WriteLine(ReverseCharacters(input));
                    break;
                case "2":
                    Console.WriteLine(ParenthesesBalanced(input));
                    break;
                default:
                    keepRunning = false;
                    break;
            }
        }
    }

    private static string ReverseCharacters(string input)
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

    private static bool ParenthesesBalanced(string input)
    {
        Stack<char> parenthesesStack = new Stack<char>();

        Dictionary<char, char> pairs = new Dictionary<char, char>();
        pairs.Add(')', '(');
        pairs.Add(']', '[');
        pairs.Add('}', '{');

        for (int i = 0; i < input.Length; i++)
        {
            if (pairs.Values.Contains(input[i]))
            {
                parenthesesStack.Push(input[i]);
            } else if (pairs.Keys.Contains(input[i]))
            {

                if (parenthesesStack.Count == 0)
                {
                    Console.WriteLine("A closing parenthesis has been used without an opening one.");
                    return false;
                }

                if (parenthesesStack.Pop() == pairs[input[i]]) continue;
                Console.WriteLine("There is a mismatching pair.");
                return false;
            }
        }
        
        Console.WriteLine("Stack count: " + parenthesesStack.Count);
        if (parenthesesStack.Count > 0)
        {
            Console.WriteLine("Not all parentheses have been closed.");
            return false;
        }

        return true;
    }
}