using MediatR;

namespace WebIEEE.Application.Commands.News.UpdateNews;

public record UpdateNewsCommand(int Id, string Title, string Description, Uri ImageLink, string Author) : IRequest<Unit>;