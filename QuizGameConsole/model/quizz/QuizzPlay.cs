namespace QuizGameConsole.model;

public class QuizzPlay
{
    private readonly Quizz _quizz;
    private readonly int _correctAnswer;

    public QuizzPlay(Quizz quizz, int correctAnswer)
    {
        _quizz = quizz;
        _correctAnswer = correctAnswer;
    }
}