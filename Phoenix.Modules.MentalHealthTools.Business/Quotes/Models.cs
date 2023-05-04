using FluentValidation;

namespace Phoenix.Modules.MentalHealthTools.Business.Quotes;

public class QuoteCommand
{
    public string? Id { get; set; }
    public string Quote { get; set; }
    public string? Author { get; set; }
    public IEnumerable<string>? SubCategoryIds { get; set; }
}

public class QuoteDto
{
    public string? Id { get; set; }
    public string Quote { get; set; }
    public string? Author { get; set; }

    public static explicit operator QuoteDto(Data.Quotes.Quotes quote)
    {
        return new QuoteDto()
        {
            Id = quote.Id,
            Quote = quote.Quote,
            Author = quote.Author
        };
    }
}

public class QuotePageDto
{
    public string? Id { get; set; }
    public string Quote { get; set; }
    public string? Author { get; set; }
    
    public static explicit operator 
        QuotePageDto(Data.Quotes.Quotes quote)
    {
        return new QuotePageDto()
        {
            Id = quote.Id,
            Quote = quote.Quote,
            Author = quote.Author
        };
    }
    
    public static PaginatedList<QuotePageDto> 
        ToPageDto(PaginatedList<Data.Quotes.Quotes> paginated)
    {
        var pageDto = new List<QuotePageDto>();
        foreach (var quote in paginated.Data)
        {
            pageDto.Add((QuotePageDto) quote);
        }
        
        return new PaginatedList<QuotePageDto>(pageDto, paginated.TotalCount, paginated.CurrentPage, paginated.PageSize);
    }
}

public class QuoteCommandValidator : AbstractValidator<QuoteCommand>
{
    public QuoteCommandValidator()
    {
        RuleFor(x => x.Author)
            .MaximumLength(50);
        RuleFor(x => x.Quote)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200);
    }
}