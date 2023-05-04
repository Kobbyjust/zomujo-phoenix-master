using FluentValidation;
using Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteSubCategory;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteCategory;

public class QuoteCategoryCommand
{
    public string? Id { get; set; }
    public string Name { get; set; }
}

public class QuoteCategoryPageDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<QuoteSubCategoryPageDto>? SubCategories { get; set; }

    public static explicit operator QuoteCategoryPageDto(Data.QuoteCategory.QuoteCategory quoteCategory)
    {
        return new QuoteCategoryPageDto()
        {
            Id = quoteCategory.Id,
            Name = quoteCategory.Name,
            SubCategories = quoteCategory?.SubCategories?.Select(x => new QuoteSubCategoryPageDto()
            {
                Id = x.Id,
                Name = x.Name,
                QuoteCategoryId = quoteCategory.Id,
                Quotes = x.Quotes.Select(a => new QuotePageDto()
                {
                    Id = a.Id,
                    Author = a.Author,
                    Quote = a.Quote
                })
            })
        };
    }
    
    public static PaginatedList<QuoteCategoryPageDto> ToPageDto(PaginatedList<Data.QuoteCategory.QuoteCategory> paginated)
    {
        var pageDto = new List<QuoteCategoryPageDto>();
        foreach (var category in paginated.Data)
        {
            pageDto.Add((QuoteCategoryPageDto) category);
        }
        
        return new PaginatedList<QuoteCategoryPageDto>(pageDto, paginated.TotalCount, paginated.CurrentPage, paginated.PageSize);
    }
}

public class QuoteCategoryDto
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<QuoteSubCategoryDto>? SubCategories { get; set; }

    public static explicit operator QuoteCategoryDto(Data.QuoteCategory.QuoteCategory? quoteCategory)
    {
        return new QuoteCategoryDto()
        {
            Id = quoteCategory?.Id,
            Name = quoteCategory?.Name!,
            SubCategories = quoteCategory?.SubCategories?.Select(x => new QuoteSubCategoryDto()
            {
                Id = x.Id,
                Name = x.Name,
                Quotes = x.Quotes.Select(a => new QuoteDto()
                {
                    Id = a.Id,
                    Author = a.Author,
                    Quote = a.Quote
                })
            })
        };
    }
}

public class QuoteCategoryCommandValidator : AbstractValidator<QuoteCategoryCommand>
{
    public QuoteCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(30);
    }
}