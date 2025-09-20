namespace QuizGameConsole.model.user;

public interface IUserInterface
{
    void DisplayMessage(string message);
    void DisplayError(string message);
    char GetUserInput(string prompt, char[] acceptedValues);
    int GetMenuUserInput(string prompt, int max, int min);
    void WaitForKeyPress();
    void Clear();
}