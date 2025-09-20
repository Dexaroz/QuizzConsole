namespace QuizGameConsole.model;

public class Quizz
{
    public string Title { get; private set; }
    public IReadOnlyList<Question> Questions { get; }

    public Quizz(string title, IEnumerable<Question> questions)
    {
        Title = string.IsNullOrWhiteSpace(title) ? throw new ArgumentException("Title cannot be null or empty.") : title;
        Questions = questions?.ToList() ?? throw new ArgumentNullException(nameof(questions));
        if (Questions.Count == 0) throw new ArgumentException("Quiz must have questions.");
    }
}