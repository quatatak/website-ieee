using System.ComponentModel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebIEEE.Infrastructure;

namespace WebIEEE.Application.Commands.News.DeleteNews;

public class DeleteNewsCommandHandler : IRequestHandler<DeleteNewsCommand, Unit>
{
    private readonly WebIeeeDbContext _dbContext;
    
    public DeleteNewsCommandHandler(WebIeeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<Unit> Handle(DeleteNewsCommand request, CancellationToken cancellationToken)
    {
        var newsToDelete = await _dbContext.News.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken);

        if (newsToDelete is null)
        {
            throw new InvalidOperationException("News to delete not found");
        }
        
        _dbContext.News.Remove(newsToDelete);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}