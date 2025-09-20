using QuizGameConsole.model.menu.io;
using QuizGameConsole.model.user;

namespace QuizGameConsole.model;

public class QuizzController
{
    private readonly QuizzHistory _quizzHistory;
    private readonly QuizzEngine _quizzEngine;
    private readonly IUserInterface _userInterface;
    private readonly IQuizzLoader _quizzLoader;
    
    public QuizzController(QuizzHistory quizzHistory, QuizzEngine quizzEngine, IQuizzLoader quizzLoader)
    {
        _quizzHistory = quizzHistory;
        _quizzEngine = quizzEngine;
        _userInterface = new ConsoleUserInterface();
        _quizzLoader = quizzLoader;
    }

     public QuizzPlay? StartQuizzSession()
    {
        var availableQuizzes = LoadAvailableQuizzes();
        if (!availableQuizzes.Any())
        {
            _userInterface.DisplayError("No quizzes available to play.");
            return null;
        }

        var selectedQuizz = SelectQuizz(availableQuizzes);
        if (selectedQuizz == null) return null;

        return PlaySingleQuizz(selectedQuizz);
    }

    private List<Quizz> LoadAvailableQuizzes()
    {
        try
        {
            return _quizzLoader.Loads();
        }
        catch (Exception ex)
        {
            _userInterface.DisplayError($"Error loading quizzes: {ex.Message}");
            return new List<Quizz>();
        }
    }

    private Quizz? SelectQuizz(List<Quizz> quizzes)
    {
        _userInterface.DisplayMessage("\n=== AVAILABLE QUIZZES ===");
        
        for (int i = 0; i < quizzes.Count; i++)
        {
            _userInterface.DisplayMessage($"{i + 1}. {quizzes[i].Title} ({quizzes[i].Questions.Count} questions)");
        }
        
        _userInterface.DisplayMessage($"{quizzes.Count + 1}. Cancel");

        var choice = _userInterface.GetMenuUserInput("\nSelect a quiz: ", quizzes.Count + 1, 1);
        
        if (choice == quizzes.Count + 1) return null; // Cancel
        
        return quizzes[choice - 1];
    }

    public QuizzPlay PlaySingleQuizz(Quizz quizz)
    {
        int correctAnswers = 0;
        int totalQuestions = quizz.Questions.Count;

        _userInterface.DisplayMessage($"\n=== Starting Quiz: {quizz.Title} ===");

        for (int i = 0; i < totalQuestions; i++)
        {
            _userInterface.DisplayMessage($"\nQuestions remaining: {totalQuestions - i}");
            var question = quizz.Questions[i];

            _userInterface.DisplayMessage($"\n{question}");

            var playerChoice = _userInterface.GetUserInput("Your choice: ", question.AcceptedKeys());

            if (_quizzEngine.CheckAnswer(playerChoice, question))
            {
                correctAnswers++;
                _userInterface.DisplayMessage("Correct!");
            }
            else
            {
                int idx = question.CorrectOptionIndex;
                char correctLabel = (char)('a' + idx);
                _userInterface.DisplayMessage(
                    $"Wrong! The correct answer was: {correctLabel}) {question.Choices[idx]}"
                );
            }
        }
        
        var quizzPlay = new QuizzPlay(quizz, correctAnswers);
        _quizzHistory.AddQuizz(quizzPlay);

        return quizzPlay;
    }
}