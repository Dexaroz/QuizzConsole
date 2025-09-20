using System.Text;

namespace QuizGameConsole.model;

public class Question
{
    private readonly string _statement;
    public List<Answer> Choices { get; private set; }
    public int CorrectOptionIndex = -1;

    public Question(string statement, List<Answer> choices)
    {
        if (choices is null || choices.Count == 0)
            throw new ArgumentException("Question must have at least one answer.", nameof(choices));
        
        _statement = (statement ?? string.Empty).Trim();
        Choices = new List<Answer>(choices);
        
        foreach (Answer choice in Choices)
        {
            if (choice.IsCorrect)
            {
                if (CorrectOptionIndex != -1)
                    throw new ArgumentException("Question can have only one correct answer.", nameof(choices));
                
                CorrectOptionIndex = Choices.IndexOf(choice);
            }
        }
    }
    
    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine(_statement);

        for (int i = 0; i < Choices.Count; i++)
        {
            var label = Label(i);
            sb.Append("  ").Append(label).Append(") ").AppendLine(Choices[i].Text);
        }

        return sb.ToString();
    }
    
    public char[] AcceptedKeys()
    {
        return Enumerable.Range(0, Choices.Count)
            .Select(i => Label(i)[0])
            .ToArray();
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