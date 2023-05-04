namespace Phoenix.Modules.MentalHealthTools.Data.Quotes;

public class Quotes : Entity
{
    private Quotes(string quote, string? author)
    {
        Quote = quote;
        Author = author;
    }

    public string Quote { get; private set; }
    public string? Author { get; private set; }
    
    private readonly List<QuoteSubCategory.QuoteSubCategory> _quoteSubCategories = new();
    public IReadOnlyList<QuoteSubCategory.QuoteSubCategory> QuoteSubCategories => _quoteSubCategories.AsReadOnly();


    public static Quotes Create(string quote, string? author) => new(quote, author);

    public Quotes WithSaying(string quote)
    {
        Quote = quote;
        return this;
    }

    public Quotes ByAuthor(string? author)
    {
        Author = author;
        return this;
    }

    public Quotes InSubCategories(IEnumerable<QuoteSubCategory.QuoteSubCategory> quoteSubCategories)
    {
        _quoteSubCategories.AddRange(quoteSubCategories);
        return this;
    }
}