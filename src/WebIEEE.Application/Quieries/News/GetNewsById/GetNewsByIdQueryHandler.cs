using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebIEEE.Contracts.Responses;
using WebIEEE.Infrastructure;

namespace WebIEEE.Application.Quieries.News.GetNewsById;

public class GetNewsByIdQueryHandler : IRequestHandler<GetNewsByIdQuery, GetNewsByIdResponse>
{
    private readonly WebIeeeDbContext _dbContext;
    
    public GetNewsByIdQueryHandler(WebIeeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<GetNewsByIdResponse> Handle(GetNewsByIdQuery request, CancellationToken cancellationToken)
    {
        var news = await _dbContext.News.FirstOrDefaultAsync(e => e.Id == request.Id, cancellationToken);
        
        return news.Adapt<GetNewsByIdResponse>();
    }
}