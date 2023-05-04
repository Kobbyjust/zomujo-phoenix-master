namespace Phoenix.Modules.MentalHealthTools.Data.QuoteSubCategory;

public class QuoteSubCategory : Entity
{
    private QuoteSubCategory(string name, string quoteCategoryId)
    {
        QuoteCategoryId = quoteCategoryId;
        Name = name;
    }

    public string QuoteCategoryId { get; private set; }
    public string Name { get; private set; }
    public QuoteCategory.QuoteCategory? QuoteCategory { get; private set; }
    
    private readonly List<Quotes.Quotes> _quotes = new();
    public IReadOnlyList<Quotes.Quotes> Quotes => _quotes.AsReadOnly();

    public static QuoteSubCategory Create(string name, string quoteCategoryId) => new(name, quoteCategoryId);
    
    public QuoteSubCategory HasName(string name)
    {
        Name = name;
        return this;
    }

    public QuoteSubCategory BelongsToCategoryWithId(string id)
    {
        QuoteCategoryId = id;
        return this;
    }

    public QuoteSubCategory AddQuotes(IEnumerable<Quotes.Quotes> quotes)
    {
        _quotes.AddRange(quotes);
        return this;
    }
}