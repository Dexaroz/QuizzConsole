namespace QuizGameConsole.model;

public class Quizz
{
    private readonly List<Question> _questions;

    public Quizz(List<Question> questions)
    {
        _questions = questions;
    }
}