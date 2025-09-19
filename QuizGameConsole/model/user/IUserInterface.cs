namespace QuizGameConsole.model.user;

public interface IUserInterface
{
    void DisplayMessage(string message);
    void DisplayError(string message);
    char GetUserInput(string prompt, char[] acceptedValues);
    void WaitForKeyPress();
    void Clear();
}