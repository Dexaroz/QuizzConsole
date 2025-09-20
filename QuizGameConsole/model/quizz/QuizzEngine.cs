namespace QuizGameConsole.model;

public class QuizzEngine
{
    public bool CheckAnswer(char userChoice, Question question)
    {
        if (question is null) throw new ArgumentNullException(nameof(question));

        char c = char.ToLowerInvariant(userChoice);
        int index = c - 'a';
        if (index < 0 || index >= question.Choices.Count)
            return false;

        return question.Choices[index].IsCorrect;
    }
}