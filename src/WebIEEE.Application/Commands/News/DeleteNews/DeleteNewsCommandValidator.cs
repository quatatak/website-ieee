using FluentValidation;

namespace WebIEEE.Application.Commands.News.DeleteNews;

public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsCommand>
{
    public DeleteNewsCommandValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage($"{nameof(DeleteNewsCommand.Id)} is required");
    }
}