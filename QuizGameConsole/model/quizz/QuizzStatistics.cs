namespace QuizGameConsole.model;

public class QuizzStatistics
{
    public int TotalQuizzes { get; }
    public double AverageScore { get; }
    
    public QuizzStatistics(int totalQuizzes, int correctAnswers, int totalQuestions)
    {
        TotalQuizzes = totalQuizzes;
        AverageScore = totalQuestions > 0 ? (double)correctAnswers / totalQuestions * 100 : 0;
    }
}