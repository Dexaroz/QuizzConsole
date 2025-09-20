namespace QuizGameConsole.model.menu.io;

public class FileQuizzLoader : IQuizzLoader
{
    private readonly string _filePath;
    private readonly IQuizzDeserializer _deserializer;
    
    public FileQuizzLoader(string filePath, IQuizzDeserializer deserializer)
    {
        _filePath = string.IsNullOrWhiteSpace(filePath) ? throw new ArgumentException("File path cannot be null or empty.") : filePath;
        _deserializer = deserializer ?? throw new ArgumentNullException(nameof(deserializer));
    }

    public List<Quizz> Loads()
    {
        if (!File.Exists(_filePath))
        {
            throw new FileNotFoundException($"The file '{_filePath}' was not found.");
        }

        try
        {
            return LoadFromFile(_filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading quizzes from file '{_filePath}': {ex.Message}");
            return new List<Quizz>();
        }
    }
    
    private List<Quizz> LoadFromFile(string filePath)
    {
        var quizzes = new List<Quizz>();
        
        using var reader = new StreamReader(filePath);
        reader.ReadLine();
        
        string? line;
        while ((line = reader.ReadLine()) != null)
        {
            var quiz = _deserializer.Deserialize(line);
            if (quiz != null)
            {
                quizzes.Add(quiz);
            }
        }
        
        return quizzes;
    }
}