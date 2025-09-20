namespace QuizGameConsole.model;

public class QuizzPlay
{
    public Quizz Quizz { get; private set; }
    public int CorrectAnswers { get; private set; }

    public QuizzPlay(Quizz quizz, int correctAnswer)
    {
        Quizz = quizz;
        CorrectAnswers = correctAnswer;
    }
    
    public override string ToString()
    {
        double score = ((double)CorrectAnswers / Quizz.Questions.Count) * 100;
        return $"Quizz - {score:F2}%";
    }
}