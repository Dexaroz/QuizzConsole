namespace QuizGameConsole.model;

public class QuizzEngine
{
    public bool CheckAnswer(char userChoice, Answer answer)
    {
        int index = userChoice - 'a';
        if (index < 0)
            return false;

        return answer.IsCorrect;
    }
}