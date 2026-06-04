using frontend.Models;

namespace frontend.Services;

public interface IArtworksService
{
    Task<IEnumerable<Artwork>> GetAllAsync();
    Task<Artwork?> GetItemByIdAsync(Guid id);
    Task AddAsync(Artwork artwork);
    Task UpdateAsync(Artwork artwork);
    Task DeleteAsync(Guid id);
}