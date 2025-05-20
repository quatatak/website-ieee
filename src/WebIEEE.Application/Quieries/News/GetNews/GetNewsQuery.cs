using MediatR;
using WebIEEE.Contracts.Responses;

namespace WebIEEE.Application.Quieries.News.GetNewsById;

public record GetNewsQuery() : IRequest<GetNewsResponse>;