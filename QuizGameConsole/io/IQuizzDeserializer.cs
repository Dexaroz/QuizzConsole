namespace QuizGameConsole.model.menu.io;

public interface IQuizzDeserializer
{
    Quizz Deserialize(string line);
}