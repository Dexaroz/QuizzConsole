namespace QuizGameConsole.model;

public class Answer
{
    public string Text {  get; private set; }
    public bool IsCorrect {  get; private set; }

    public Answer(string text, bool isCorrect)
    {
        Text = text;
        IsCorrect = isCorrect;
    }

    public override string ToString()
    {
        return Text;
    }
}