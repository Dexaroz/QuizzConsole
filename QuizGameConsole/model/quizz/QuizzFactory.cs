namespace QuizGameConsole.model;

public class QuizzFactory
{
    public static Quizz CreateGeneralKnowledge()
    {
        var questions = new List<Question>
        {
            new Question(
                "Choose one color:",
                new List<Answer>
                {
                    new Answer("Red", false),
                    new Answer("Green", true),
                    new Answer("Blue", false),
                    new Answer("Yellow", false)
                }
            ),
            new Question(
                "Which planet is known as the Red Planet?",
                new List<Answer>
                {
                    new Answer("Earth", false),
                    new Answer("Mars", true),
                    new Answer("Jupiter", false),
                    new Answer("Venus", false)
                }
            ),
            new Question(
                "C# keyword to define a constant value:",
                new List<Answer>
                {
                    new Answer("fixed", false),
                    new Answer("const", true),
                    new Answer("readonly", false),
                    new Answer("static", false)
                }
            )
        };

        return new Quizz("General Knowledge (Hardcoded)", questions);
    }

    public static Quizz CreateDotNetBasics()
    {
        var questions = new List<Question>
        {
            new Question(
                "What does CLR stand for?",
                new List<Answer>
                {
                    new Answer("Common Language Runtime", true),
                    new Answer("C# Language Runtime", false),
                    new Answer("Common Linker Runtime", false),
                    new Answer("Core Language Runtime", false)
                }
            ),
            new Question(
                "Which collection does NOT allow duplicates?",
                new List<Answer>
                {
                    new Answer("List<T>", false),
                    new Answer("HashSet<T>", true),
                    new Answer("Queue<T>", false),
                    new Answer("Stack<T>", false)
                }
            ),
            new Question(
                "What is the default access modifier for class members when none is specified?",
                new List<Answer>
                {
                    new Answer("private", true),
                    new Answer("protected", false),
                    new Answer("internal", false),
                    new Answer("public", false)
                }
            )
        };

        return new Quizz(".NET Basics (Hardcoded)", questions);
    }
}