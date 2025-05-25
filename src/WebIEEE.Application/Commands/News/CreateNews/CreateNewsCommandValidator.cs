using FluentValidation;

namespace WebIEEE.Application.Commands.News.CreateNews;

public class CreateNewsCommandValidator : AbstractValidator<CreateNewsCommand>
{
    public CreateNewsCommandValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.News.Title)} is required")
            .MaximumLength(100)
            .WithMessage($"{nameof(Domain.Entities.News.Title)} must not exceed 100 characters");
        
        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.News.Description)} is required")
            .MaximumLength(1000)
            .WithMessage($"{nameof(Domain.Entities.News.Description)} must not exceed 1000 characters");
        
        RuleFor(x => x.Author)
            .NotEmpty()
            .WithMessage($"{nameof(Domain.Entities.News.Author)} is required")
            .MaximumLength(100)
            .WithMessage($"{nameof(Domain.Entities.News.Author)} must not exceed 100 characters");
    }
}