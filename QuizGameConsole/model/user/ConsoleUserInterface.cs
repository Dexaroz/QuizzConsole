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