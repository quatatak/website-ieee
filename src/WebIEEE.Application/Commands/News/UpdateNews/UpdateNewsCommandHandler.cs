using MediatR;
using Microsoft.EntityFrameworkCore;
using WebIEEE.Infrastructure;

namespace WebIEEE.Application.Commands.News.UpdateNews;

public class UpdateNewsCommandHandler : IRequestHandler<UpdateNewsCommand, Unit>
{
    private readonly WebIeeeDbContext _dbContext;
    
    public UpdateNewsCommandHandler(WebIeeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(UpdateNewsCommand request, CancellationToken cancellationToken)
    {
        var newsToUpdate = await _dbContext.News.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

        if (newsToUpdate is null)
        {
            throw new InvalidOperationException("News to update not found");
        }
        
        newsToUpdate.Title = request.Title;
        newsToUpdate.Description = request.Description;
        newsToUpdate.ImageLink = request.ImageLink;
        newsToUpdate.Author = request.Author;
        
        _dbContext.News.Update(newsToUpdate);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}