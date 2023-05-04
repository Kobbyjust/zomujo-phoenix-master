using Phoenix.Shared.Business.Exceptionss;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteCategory;

[Processor]
public class QuoteCategoryProcessor
{
    private readonly MhToolsDbContext _dbContext;
    private readonly ILogger<QuoteCategoryProcessor> _logger;

    public QuoteCategoryProcessor(MhToolsDbContext dbContext, ILogger<QuoteCategoryProcessor> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<string?> UpsertAsync(QuoteCategoryCommand command)
    {
        var isNew = string.IsNullOrEmpty(command.Id);
        Data.QuoteCategory.QuoteCategory? quoteCategory;

        if (isNew)
        {
            quoteCategory = Data.QuoteCategory.QuoteCategory.Create(command.Name);
            try
            {
                await _dbContext.Categories.AddAsync(quoteCategory);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("{Error message}", e.Message);
                throw;
            }
            return quoteCategory.Id;
        }

        if (command.Id is null) return null;
        quoteCategory = await _dbContext.Categories.FindAsync(command.Id);

        if (quoteCategory is null) return null;
        await Task.Run(() => _dbContext.Categories.Update(quoteCategory));
        await _dbContext.SaveChangesAsync();
        return quoteCategory.Id;
    }
    
    public async Task<OneOf<QuoteCategoryDto?, InvalidIdException>> GetAsync(string id)
    {
        var category = await _dbContext.Categories.FindAsync(id);
        if (category is null) return new InvalidIdException();
        return (QuoteCategoryDto) category;
    }
    
    public async Task<PaginatedList<QuoteCategoryPageDto>> GetPageAsync(PaginatedCommand command)
    {
        var paginatedList = await Task.Run(() => PaginatedList<Data.QuoteCategory.QuoteCategory>
            .Create(_dbContext.Categories.AsQueryable(), command.PageNumber,
                command.PageSize));
        return QuoteCategoryPageDto.ToPageDto(paginatedList);
    }
    
    public async Task DeleteAsync(string id)
    {
        var quoteCategory = await _dbContext.Categories.FindAsync(id);
        if (quoteCategory is not null)
        {
            await Task.Run(()=> quoteCategory.Audit?.Delete());
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task HardDeleteAsync(string id)
    {
        var quoteCategory = await _dbContext.Categories.FindAsync(id);
        if (quoteCategory is not null)
        {
            await Task.Run(() => _dbContext.Categories.Remove(quoteCategory));
            await _dbContext.SaveChangesAsync();
        }
    }
}