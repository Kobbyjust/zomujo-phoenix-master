using Phoenix.Shared.Business.Exceptionss;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteSubCategory;

[Processor]
public class QuoteSubCategoryProcessor
{
    private readonly MhToolsDbContext _dbContext;
    private readonly ILogger<QuoteSubCategoryProcessor> _logger;

    public QuoteSubCategoryProcessor(MhToolsDbContext dbContext, ILogger<QuoteSubCategoryProcessor> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }
    
    public async Task<string?> UpsertAsync(QuoteSubCategoryCommand command)
    {
        var isNew = string.IsNullOrEmpty(command.Id);
        Data.QuoteSubCategory.QuoteSubCategory? subCategory;

        if (isNew)
        {
            subCategory = Data.QuoteSubCategory.QuoteSubCategory.Create(command.Name, command.QuoteCategoryId);
            try
            {
                await _dbContext.SubCategories.AddAsync(subCategory);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError("{Error message}", e.Message);
                throw;
            }
            return subCategory.Id;
        }

        if (command.Id is null) return null;
        subCategory = await _dbContext.SubCategories.FindAsync(command.Id);
        if (subCategory is null) return null;
        
        subCategory.BelongsToCategoryWithId(command.QuoteCategoryId);
        await Task.Run(() => _dbContext.SubCategories.Update(subCategory));
        await _dbContext.SaveChangesAsync();
        return subCategory.Id;
    }
    
    public async Task<OneOf<QuoteSubCategoryDto?, InvalidIdException>> GetAsync(string id)
    {
        var sub = await _dbContext.SubCategories.FindAsync(id);
        if (sub is null) return new InvalidIdException();
        return (QuoteSubCategoryDto) sub;
    }
    
    public async Task<PaginatedList<QuoteSubCategoryPageDto>> GetPageAsync(PaginatedCommand command)
    {
        var paginatedList = await Task.Run(() => PaginatedList<Data.QuoteSubCategory.QuoteSubCategory>
            .Create(_dbContext.SubCategories.AsQueryable(), command.PageNumber,
                command.PageSize));
        return QuoteSubCategoryPageDto.ToPageDto(paginatedList);
    }
    
    public async Task DeleteAsync(string id)
    {
        var quoteSubCategory = await _dbContext.SubCategories.FindAsync(id);
        if (quoteSubCategory is not null)
        {
            await Task.Run(()=> quoteSubCategory.Audit?.Delete());
            await _dbContext.SaveChangesAsync();
        }
    }
    
    public async Task HardDeleteAsync(string id)
    {
        var quoteSubCategory = await _dbContext.SubCategories.FindAsync(id);
        if (quoteSubCategory is not null)
        {
            await Task.Run(() => _dbContext.SubCategories.Remove(quoteSubCategory));
            await _dbContext.SaveChangesAsync();
        }
    }
}