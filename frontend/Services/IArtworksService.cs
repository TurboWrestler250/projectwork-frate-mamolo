using frontend.Models;

namespace frontend.Services;

public interface IArtworksService
{
    Task<IEnumerable<Artwork>> GetAllAsync();
    Task<Artwork?> GetItemByIdAsync(int id);
}