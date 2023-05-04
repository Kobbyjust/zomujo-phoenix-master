using Phoenix.Shared.Business.Exceptionss;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes;

[Processor]
public class QuoteProcessor
{
    private readonly MhToolsDbContext _dbContext;
    private readonly ILogger<QuoteProcessor> _logger;

    public QuoteProcessor(MhToolsDbContext dbContext, ILogger<QuoteProcessor> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    // TODO
    public async Task AddFavorite()
    {
        await Task.CompletedTask;
    }
    
    public async Task<string?> UpsertAsync(QuoteCommand command)
    {
        var isNew = string.IsNullOrEmpty(command.Id);
        Data.Quotes.Quotes? quote;

        if (isNew)
        {
            if (string.IsNullOrEmpty(command.Author)) command.Author = "Unknown";
            quote = Data.Quotes.Quotes.Create(command.Quote, command.Author);
            await AddSubCategories(command, quote);
            try
            {
                await _dbContext.Quotes.AddAsync(quote);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("{Error Message}", e.Message);
                throw;
            }
            return quote.Id;
        }

        if (command.Id is null) return null;
        quote = await _dbContext.Quotes.FindAsync(command.Id);
        if (quote is null) return null;

        quote.ByAuthor(command.Author)
            .WithSaying(command.Quote);
        await AddSubCategories(command, quote);
        
        await Task.Run(() => _dbContext.Quotes.Update(quote));
        await _dbContext.SaveChangesAsync();
        return quote.Id;
    }
    
    public async Task<OneOf<QuoteDto?, InvalidIdException>> GetAsync(string id)
    {
        var quote = await _dbContext.Quotes.FindAsync(id);
        if (quote is null) return new InvalidIdException();
        return (QuoteDto) quote;
    }
    
    public async Task<PaginatedList<QuotePageDto>> GetPageAsync(PaginatedCommand command)
    {
        var paginatedList = await Task.Run(() => PaginatedList<Data.Quotes.Quotes>
            .Create(_dbContext.Quotes.AsQueryable(), command.PageNumber,
                command.PageSize));
        return QuotePageDto.ToPageDto(paginatedList);
    }
    
    public async Task DeleteAsync(string id)
    {
        var quote = await _dbContext.Quotes.FindAsync(id);
        if (quote is not null)
        {
            await Task.Run(()=> quote.Audit?.Delete());
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task HardDeleteAsync(string id)
    {
        var quoteCategory = await _dbContext.Quotes.FindAsync(id);
        if (quoteCategory is not null)
        {
            await Task.Run(() => _dbContext.Quotes.Remove(quoteCategory));
            await _dbContext.SaveChangesAsync();
        }
    }

    private async Task AddSubCategories(QuoteCommand command, Data.Quotes.Quotes quote)
    {
        if (command.SubCategoryIds is not null)
        {
            var subs = new List<Data.QuoteSubCategory.QuoteSubCategory>();
            foreach (var commandSubCategoryId in command.SubCategoryIds)
            {
                var sub = await _dbContext.SubCategories.FindAsync(commandSubCategoryId)
                    .ConfigureAwait(false);
                if (sub is not null) subs.Add(sub);
            }

            quote.InSubCategories(subs);
        }
    }
}