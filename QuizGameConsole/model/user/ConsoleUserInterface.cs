namespace QuizGameConsole.model.user;

public class ConsoleUserInterface : IUserInterface
{
    public void DisplayMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void DisplayError(string message)
    {
        Console.WriteLine(message);
    }

    public char GetUserInput(string prompt, char[] acceptedValues)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            var input = Console.ReadLine();
            if (char.TryParse(input, out char charSelected) && IsValid(charSelected, acceptedValues))
            {
                return charSelected;
            }
            
            DisplayError($"Please enter a valid character.");
        }
    }

    public int GetMenuUserInput(string prompt, int max, int min)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine();
            if (int.TryParse(input, out int choice) && IsValidRange(choice, min, max))
            {
                return choice;
            }
            
            DisplayError($"Please enter a number between {min} and {max}.");
        }
    }

    private bool IsValidRange(int choice, int min, int max)
    {
        return (choice >= min) && (choice <= max);
    }
    
    private bool IsValid(char key, char[] acceptedValues)
    {
        return acceptedValues.Contains(key);
    }

    public void WaitForKeyPress()
    {
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    public void Clear()
    {
        Console.Clear();
    }
}