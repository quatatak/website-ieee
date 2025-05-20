using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebIEEE.Contracts.Responses;
using WebIEEE.Infrastructure;

namespace WebIEEE.Application.Quieries.News.GetNewsById;

public class GetNewsQueryHandler : IRequestHandler<GetNewsQuery, GetNewsResponse>
{
    private readonly WebIeeeDbContext _dbContext;
    
    public GetNewsQueryHandler(WebIeeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<GetNewsResponse> Handle(GetNewsQuery request, CancellationToken cancellationToken)
    {
        var news = await _dbContext.News.ToListAsync(cancellationToken);

        return news.Adapt<GetNewsResponse>();
    }
}