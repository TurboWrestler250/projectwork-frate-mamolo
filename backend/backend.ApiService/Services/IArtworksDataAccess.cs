namespace backend.ApiService.Services;

using backend.ApiService.Models;

public interface IArtworksDataAccess
{
    IEnumerable<Artwork> GetArtworks();
    Artwork? GetArtworkById(int id);
    void AddArtwork(Artwork artwork);
}