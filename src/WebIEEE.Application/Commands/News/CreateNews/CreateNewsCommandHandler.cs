using MediatR;
using WebIEEE.Infrastructure;

namespace WebIEEE.Application.Commands.News.CreateNews;

public class CreateNewsCommandHandler : IRequestHandler<CreateNewsCommand, int>
{
    private readonly WebIeeeDbContext _dbContext;
    
    public CreateNewsCommandHandler(WebIeeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<int> Handle(CreateNewsCommand request, CancellationToken cancellationToken)
    {
        var news = new Domain.Entities.News
        {
            Title = request.Title,
            Description = request.Description,
            ImageLink = request.ImageLink,
            Author = request.Author,
            CreatedAt = DateTime.UtcNow
        };
        
        await _dbContext.News.AddAsync(news, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return news.Id;
    }
}
