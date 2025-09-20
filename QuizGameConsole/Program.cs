
using QuizGameConsole.model;
using QuizGameConsole.model.menu;
using QuizGameConsole.model.menu.io;
using QuizGameConsole.model.user;

class Program
{
    static void Main(string[] args)
    {
        QuizzHistory guessHistory = new QuizzHistory();
        QuizzEngine guessEngine = new QuizzEngine();
        QuizzController guessController = new QuizzController(guessHistory, guessEngine, new FileQuizzLoader("quizzes.csv", new CsvQuizzDeserializer()));
        IUserInterface consoleInterface = new ConsoleUserInterface();
        MenuManager menuManager = new MenuManager(guessController, guessHistory, consoleInterface);
        
        menuManager.Run();
    }
}