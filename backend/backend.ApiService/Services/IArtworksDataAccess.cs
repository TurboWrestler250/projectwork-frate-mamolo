namespace backend.ApiService.Services;

using backend.ApiService.Models;

public interface IArtworksDataAccess
{
    IEnumerable<Artwork> GetArtworks();
    Artwork? GetArtworkById(Guid id);
    void AddArtwork(Artwork artwork);
}