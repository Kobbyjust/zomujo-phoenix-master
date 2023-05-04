namespace Phoenix.Modules.MentalHealthTools.Data.QuoteCategory;

public class QuoteCategory : Entity
{

    private QuoteCategory(string name)
    {
        Name = name;
    }

    public string Name { get; private set; }

    private readonly List<QuoteSubCategory.QuoteSubCategory> _subCategories = new();
    public IReadOnlyList<QuoteSubCategory.QuoteSubCategory> SubCategories => _subCategories.AsReadOnly();

    public static QuoteCategory Create(string name) => new(name);

    public QuoteCategory HasName(string name)
    {
        Name = name;
        return this;
    }

    public QuoteCategory AddSubCategories(IEnumerable<QuoteSubCategory.QuoteSubCategory> subCategories)
    {
        _subCategories.AddRange(subCategories);
        return this;
    }
}