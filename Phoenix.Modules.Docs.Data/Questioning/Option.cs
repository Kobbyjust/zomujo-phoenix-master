namespace Phoenix.Modules.Docs.Data.Questioning;

public class Option : Entity
{
    private Option(string text)
    {
        Text = text;
    }
    
    public string Text { get; private set; }
    private List<Question> _questions = new();
    public IEnumerable<Question> Questions => _questions.AsQueryable();

    public bool Reset { get; private set; }

    public static Option Create(string text) => new(text);
}

public class OptionConfiguration : DatabaseConfiguration<Option, string>{}