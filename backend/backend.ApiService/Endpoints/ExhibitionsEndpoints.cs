namespace backend.ApiService.Endpoints;

using backend.ApiService.Models;
using backend.ApiService.Services;
using Microsoft.AspNetCore.Http.HttpResults;

public static class ExhibitionsEndpoints
{
    public static IEndpointRouteBuilder MapExhibitionsEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/exhibitions");

        // GET /api/exhibitions
        group.MapGet("", GetExhibitions);
        // GET /api/exhibitions/123
        group.MapGet("{id:int}", GetExhibitionById);
        // POST /api/exhibitions
        group.MapPost("", AddExhibition);

        return app;
    }

    private static Ok<IEnumerable<Exhibition>> GetExhibitions(IExhibitionsDataAccess data)
    {
        var list = data.GetExhibitions();
        return TypedResults.Ok(list); // 200 OK
    }

    private static Results<NotFound, Ok<Exhibition>> GetExhibitionById(int id, IExhibitionsDataAccess data)
    {
        var exhibition = data.GetExhibitionById(id);
        if (exhibition is null)
            return TypedResults.NotFound(); // 404 Not Found

        return TypedResults.Ok(exhibition); // 200 OK
    }

    private static Created<Exhibition> AddExhibition(Exhibition exhibition,IExhibitionsDataAccess data)
    {
        data.AddExhibition(exhibition);

        return TypedResults.Created($"/api/exhibitions/{exhibition.Id}", exhibition); // 201 Created
    }
}
