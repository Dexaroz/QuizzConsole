using QuizGameConsole.model.user;

namespace QuizGameConsole.model.menu;

public class MenuManager
{
    private readonly QuizzController _quizzController;
    private readonly QuizzHistory _quizzHistory;
    private readonly IUserInterface _userInterface;
    private readonly Dictionary<MenuOption, Action> _menuActions;
    
    public MenuManager(QuizzController quizzController, QuizzHistory quizzHistory, IUserInterface userInterface)
    {
        _quizzController = quizzController;
        _quizzHistory = quizzHistory;
        _userInterface = userInterface;
        
        _menuActions = GetMenuActions();
    }
    
     public void Run()
        {
            while (true)
            {
                DisplayMainMenu();
                var choice = GetMenuChoice();
                ExecuteMenuAction(choice);
                _userInterface.WaitForKeyPress();
                _userInterface.Clear();
            }
        }

        private void DisplayMainMenu()
        {
            _userInterface.DisplayMessage("╔══════════════════════════════════════════════════╗");
            _userInterface.DisplayMessage("║              QUIZ GAME                           ║");
            _userInterface.DisplayMessage("╠══════════════════════════════════════════════════╣");
            _userInterface.DisplayMessage("║  1. Play Quiz                                    ║");
            _userInterface.DisplayMessage("║  2. Show Quiz History                            ║");
            _userInterface.DisplayMessage("║  3. Show Statistics                              ║");
            _userInterface.DisplayMessage("║  4. Exit                                         ║");
            _userInterface.DisplayMessage("╚══════════════════════════════════════════════════╝");
        }

        private MenuOption GetMenuChoice()
        {
            var choice = _userInterface.GetMenuUserInput("Please select an option: ", 4, 1);
            return (MenuOption)choice;
        }

        private void ExecuteMenuAction(MenuOption choice)
        {
            if (_menuActions.TryGetValue(choice, out var action))
            {
                action();
            }
            else
            {
                _userInterface.DisplayError("Invalid menu option selected.");
            }
        }

        private Dictionary<MenuOption, Action> GetMenuActions()
        {
            return new Dictionary<MenuOption, Action>
            {
                { MenuOption.PlayQuiz, PlayQuiz },
                { MenuOption.ShowHistory, ShowHistory },
                { MenuOption.ShowStatistics, ShowStatistics },
                { MenuOption.Exit, Exit }
            };
        }

        private void PlayQuiz()
        {
            try
            {
                var result = _quizzController.StartQuizzSession();
                if (result != null)
                {
                    _userInterface.DisplayMessage($"\n=== QUIZ COMPLETED ===");
                    _userInterface.DisplayMessage($"Final Score: {result.CorrectAnswers}/{result.Quizz.Questions.Count}");
                    double percentage = ((double)result.CorrectAnswers / result.Quizz.Questions.Count) * 100;
                    _userInterface.DisplayMessage($"Percentage: {percentage:F2}%");
                }
            }
            catch (Exception ex)
            {
                _userInterface.DisplayError($"Error starting quiz: {ex.Message}");
            }
        }
        
        private void ShowHistory()
        {
            _userInterface.DisplayMessage("\n=== QUIZ HISTORY ===");
            
            if (!_quizzHistory.HasQuizzes)
            {
                _userInterface.DisplayMessage("No quizzes played yet.");
                return;
            }

            var quizzes = _quizzHistory.GetQuizzes();
            for (int i = 0; i < quizzes.Count; i++)
            {
                _userInterface.DisplayMessage($"{i + 1}. {quizzes[i]}");
            }
        }
        
        private void ShowStatistics()
        {
            _userInterface.DisplayMessage("\n=== QUIZ STATISTICS ===");
            
            var stats = _quizzHistory.GetStatistics();
            
            if (stats.TotalQuizzes == 0)
            {
                _userInterface.DisplayMessage("No quizzes played yet.");
                return;
            }

            _userInterface.DisplayMessage($"Total Quizzes: {stats.TotalQuizzes}");
            _userInterface.DisplayMessage($"Average Score: {stats.AverageScore:F2}%");
        }
        
        private void Exit()
        {
            Environment.Exit(0);
        }
}