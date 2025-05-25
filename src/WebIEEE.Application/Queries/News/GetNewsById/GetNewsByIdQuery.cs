using MediatR;
using WebIEEE.Contracts.Responses;

namespace WebIEEE.Application.Quieries.News.GetNewsById;

public record GetNewsByIdQuery(int Id) : IRequest<GetNewsByIdResponse>;