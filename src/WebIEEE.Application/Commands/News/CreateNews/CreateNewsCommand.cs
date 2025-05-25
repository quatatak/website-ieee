using MediatR;

namespace WebIEEE.Application.Commands.News.CreateNews;

public record CreateNewsCommand(string Title, string Description, Uri ImageLink, string Author) : IRequest<int>;