using FluentValidation;
using Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteCategory;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes.QuoteSubCategory;

public class QuoteSubCategoryCommand
{
    public string? Id { get; set; }
    public string QuoteCategoryId { get; set; }
    public string Name { get; set; }
}

public class QuoteSubCategoryPageDto
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public string QuoteCategoryId { get; set; }
    public IEnumerable<QuotePageDto> Quotes { get; set; }
    
    public static explicit operator QuoteSubCategoryPageDto(Data.QuoteSubCategory.QuoteSubCategory subCategory)
    {
        return new QuoteSubCategoryPageDto()
        {
            Id = subCategory.Id,
            Name = subCategory.Name,
            QuoteCategoryId = subCategory.QuoteCategoryId
        };
    }
    
    public static PaginatedList<QuoteSubCategoryPageDto> ToPageDto(PaginatedList<Data.QuoteSubCategory.QuoteSubCategory> paginated)
    {
        var pageDto = new List<QuoteSubCategoryPageDto>();
        foreach (var subCategory in paginated.Data)
        {
            pageDto.Add((QuoteSubCategoryPageDto) subCategory);
        }
        
        return new PaginatedList<QuoteSubCategoryPageDto>(pageDto, paginated.TotalCount, paginated.CurrentPage, paginated.PageSize);
    }
}

public class QuoteSubCategoryDto
{
    public string? Id { get; set; }
    public string Name { get; set; }
    public string QuoteCategoryId { get; set; }
    public QuoteCategoryDto QuoteCategory { get; set; }

    public IEnumerable<QuoteDto> Quotes { get; set; }
    
    public static explicit operator QuoteSubCategoryDto(Data.QuoteSubCategory.QuoteSubCategory quoteCategory)
    {
        return new QuoteSubCategoryDto()
        {
            Id = quoteCategory.Id,
            Name = quoteCategory.Name,
            Quotes = quoteCategory.Quotes.Select(x => new QuoteDto()
            {
                Id = x.Id,
                Author = x.Author,
                Quote = x.Quote,
            }),
            QuoteCategory = (QuoteCategoryDto) quoteCategory.QuoteCategory
        };
    }
}

public class QuoteSubCategoryCommandValidator : AbstractValidator<QuoteSubCategoryCommand>
{
    public QuoteSubCategoryCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty();
        RuleFor(x => x.QuoteCategoryId)
            .NotNull()
            .NotEqual("string");
    }
}