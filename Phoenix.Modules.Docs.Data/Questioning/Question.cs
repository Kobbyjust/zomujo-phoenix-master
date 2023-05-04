namespace Phoenix.Modules.Docs.Data.Questioning;

public class Question : Entity
{
    private Question(string prompt, string type)
    {
        Prompt = prompt;
        Type = type;
    }
    
    public string Prompt { get; private set; }
    public string Type { get; private set; } // TODO: make enum

    private List<Option> _options = new();
    public IEnumerable<Option> Options => _options.AsQueryable();

    private List<Answer> _answers = new();
    public IEnumerable<Answer> Answers => _answers.AsQueryable();

    public string Hint { get; private set; }

    public static Question Create(string prompt, string type) => new(prompt, type);

    public Question WithOptions(IEnumerable<Option> options)
    {
        _options.AddRange(options);
        return this;
    }

    public Question WithHint(string hint)
    {
        Hint = hint;
        return this;
    }
    
    public Question WithPrompt(string prompt)
    {
        Prompt = prompt;
        return this;
    }
    
    public Question OfType(string type)
    {
        Type = type;
        return this;
    }
}

public class QuestionConfiguration : DatabaseConfiguration<Question, string>{}