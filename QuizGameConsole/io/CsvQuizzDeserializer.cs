using System.Text.Json;

namespace QuizGameConsole.model.menu.io;

public class CsvQuizzDeserializer : IQuizzDeserializer
{
    public Quizz? Deserialize(string line)
    {
        if (string.IsNullOrWhiteSpace(line))
            return null;

        return Deserialize(line.Split(';'));
    }

    private Quizz? Deserialize(string[] fields)
    {
        if (fields.Length < 2)
            return null;

        try
        {
            string title = fields[0].Trim();
            int questionCount = ToInt(fields[1]);
            
            if (questionCount <= 0 || fields.Length < 2 + questionCount * 6)
                return null;

            var questions = new List<Question>();
            
            for (int i = 0; i < questionCount; i++)
            {
                int baseIndex = 2 + (i * 6);
                var question = DeserializeQuestion(fields, baseIndex);
                if (question != null)
                    questions.Add(question);
            }

            return questions.Any() ? new Quizz(title, questions) : null;
        }
        catch
        {
            return null;
        }
    }

    private Question? DeserializeQuestion(string[] fields, int startIndex)
    {
        if (startIndex + 5 >= fields.Length)
            return null;

        string statement = fields[startIndex].Trim();
        int correctIndex = ToInt(fields[startIndex + 5]);
        
        if (correctIndex < 0 || correctIndex > 3)
            return null;

        var answers = new List<Answer>();
        for (int i = 0; i < 4; i++)
        {
            string answerText = fields[startIndex + 1 + i].Trim();
            bool isCorrect = (i == correctIndex);
            answers.Add(new Answer(answerText, isCorrect));
        }

        return new Question(statement, answers);
    }

    private int ToInt(string field)
    {
        if (string.IsNullOrEmpty(field)) return 0;
        return int.TryParse(field.Trim(), out int result) ? result : 0;
    }
}