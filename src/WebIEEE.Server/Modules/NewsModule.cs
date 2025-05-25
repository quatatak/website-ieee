using MediatR;
using WebIEEE.Application.Commands.News.CreateNews;
using WebIEEE.Application.Commands.News.DeleteNews;
using WebIEEE.Application.Commands.News.UpdateNews;
using WebIEEE.Application.Quieries.News.GetNewsById;
using WebIEEE.Contracts.Requests;

namespace WebIEEE.Server.Modules;

public static class NewsModule
{
    public static void AddNewsModule(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/news", async (IMediator mediator, CancellationToken ct) =>
        {
            var news = await mediator.Send(new GetNewsQuery(), ct);
            return Results.Ok(news);
        }).WithTags("News");
        
        app.MapGet("/api/news/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var news = await mediator.Send(new GetNewsByIdQuery(id), ct);
            return Results.Ok(news);
        }).WithTags("News");

        app.MapPost("/api/news/",
            async (IMediator mediator, CreateNewsRequest createNewsRequest, CancellationToken ct) => 
            { 
                var command = new CreateNewsCommand(
                createNewsRequest.Title,
                createNewsRequest.Description,
                createNewsRequest.ImageLink,
                createNewsRequest.Author);
                
                var result = await mediator.Send(command, ct);
                
                return Results.Ok(result); 
            }).WithTags("News");

        app.MapPut("/api/news/{id}",
            async (IMediator mediator, int id, UpdateNewsRequest updateNewsRequest, CancellationToken ct) =>
            {
                var command = new UpdateNewsCommand(
                    id,
                    updateNewsRequest.Title,
                    updateNewsRequest.Description,
                    updateNewsRequest.ImageLink,
                    updateNewsRequest.Author);
                var result = await mediator.Send(command, ct);

                return Results.Ok(result);
            }).WithTags("News");

        app.MapDelete("/api/news/{id}",
            async (IMediator mediator, int id, CancellationToken ct) =>
            {
                var command = new DeleteNewsCommand(id);

                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            }).WithTags("News");
    }
}