namespace backend.ApiService.Endpoints;

using backend.ApiService.Models;
using backend.ApiService.Services;
using Microsoft.AspNetCore.Http.HttpResults;

public static class ArtworksEndpoints
{
    public static IEndpointRouteBuilder MapArtworksEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("api/artworks");

        // GET /api/artworks
        group.MapGet("", GetArtworks);
        // GET /api/artworks/123
        group.MapGet("{id:int}", GetArtworksById);
        // POST /api/artworks
        group.MapPost("", AddArtwork);

        return app;
    }

    private static Ok<IEnumerable<Artwork>> GetArtworks(IArtworksDataAccess data)
    {
        var list = data.GetArtworks();
        return TypedResults.Ok(list); // 200 OK
    }

    private static Results<NotFound, Ok<Artwork>> GetArtworksById(Guid id, IArtworksDataAccess data)
    {
        var artwork = data.GetArtworkById(id);
        if (artwork is null)
            return TypedResults.NotFound(); // 404 Not Found

        return TypedResults.Ok(artwork); // 200 OK
    }

    private static Created<Artwork> AddArtwork(Artwork artwork,
                                               IArtworksDataAccess data)
    {
        data.AddArtwork(artwork);

        return TypedResults.Created($"/api/artworks/{artwork.Id}", artwork); // 201 Created
    }
}
