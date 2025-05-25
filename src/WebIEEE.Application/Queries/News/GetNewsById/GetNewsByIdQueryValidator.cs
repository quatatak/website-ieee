using FluentValidation;

namespace WebIEEE.Application.Quieries.News.GetNewsById;

public class GetNewsByIdQueryValidator : AbstractValidator<GetNewsByIdQuery>
{
    public GetNewsByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(GetNewsByIdQuery.Id)} is required");
    }
}