namespace Phoenix.Modules.MentalHealthTools.Data.UserQuoteFavorites;

public class UserQuoteFavorites : Entity
{
    private UserQuoteFavorites(string userId, string quoteId)
    {
        UserId = userId;
        QuoteId = quoteId;
    }

    public string UserId { get; private set; }
    public string QuoteId { get; private set; }
    public Quotes.Quotes? Quote { get; private set; }

    public static UserQuoteFavorites Create(string userId, string quoteId)
        => new(userId, quoteId);

    public UserQuoteFavorites ForUser(string userId)
    {
        UserId = userId;
        return this;
    }

    public UserQuoteFavorites On(string quoteId)
    {
        QuoteId = quoteId;
        return this;
    }
}