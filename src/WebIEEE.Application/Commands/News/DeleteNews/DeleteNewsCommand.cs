using MediatR;

namespace WebIEEE.Application.Commands.News.DeleteNews;

public record DeleteNewsCommand(int Id) : IRequest<Unit>;