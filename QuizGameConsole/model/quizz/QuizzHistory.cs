namespace QuizGameConsole.model;

public class QuizzHistory
{
    private readonly List<QuizzPlay> _quizzes;
    
    public QuizzHistory()
    {
        _quizzes = new List<QuizzPlay>();
    }
    
    public void AddQuizz(QuizzPlay quizz)
    {
        _quizzes.Add(quizz);
    }
    
    public List<QuizzPlay> GetQuizzes()
    {
        return _quizzes.AsReadOnly().ToList();
    }
    
    public bool HasQuizzes => _quizzes.Any();
    
    public QuizzStatistics GetStatistics()
    {
        if (!HasQuizzes)
            return new QuizzStatistics(0, 0, 0);
        
        var totalQuizzes = _quizzes.Count;
        var correctAnswers = _quizzes.Sum(q => q.CorrectAnswers);
        var totalQuestions = _quizzes.Sum(q => q.Quizz.Questions.Count);

        return new QuizzStatistics(totalQuizzes, correctAnswers, totalQuestions);
    }
}