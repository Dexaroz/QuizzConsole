using System.Text;

namespace QuizGameConsole.model;

public class Question
{
    private readonly string _statement;
    private readonly List<Answer> _choices;

    public Question(string statement, List<Answer> choices)
    {
        if (choices.Count == 0)
            throw new ArgumentException("Question must have at least one answer.", nameof(choices));
        
        _statement = statement.Trim();
        _choices = choices;
    }
    
    public override string ToString()
    {
        var lines = getChoicesFormatted();
        return $"{_statement}{Environment.NewLine}{string.Join(Environment.NewLine, lines)}";
    }

    private IEnumerable<string?> getChoicesFormatted()
    {
        return _choices.Select((a, i) => $"{Label(i)}) {a.Text}");
    }

    private static string Label(int index)
    {
        string label = string.Empty;
        index++;
        while (index > 0)
        {
            index--;
            label = (char)('a' + (index % 26)) + label;
            index /= 26;
        }
        return label;
    }
}