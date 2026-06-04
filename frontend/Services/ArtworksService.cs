namespace frontend.Services;

using frontend.Models;

public class ArtworksService : IArtworksService
{
    private readonly HttpClient _httpClient = new();

    // GET: api/artworks
    public async Task<IEnumerable<Artwork>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Artwork>>("artworks") ?? list;
    }

    // GET: api/artworks/{id}
    public async Task<Artwork?> GetItemByIdAsync(Guid id)
    {
        return await _httpClient.GetFromJsonAsync<Artwork>($"artworks/{id}");
    }

    // POST: api/artworks
    public Task AddAsync(Artwork artwork)
    {
        try
        {
            _httpClient.PostAsJsonAsync("artworks", artwork);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding artwork: {ex.Message}");
            throw;
        }
    }

    // PUT: api/artworks/{id}
    public Task UpdateAsync(Artwork artwork)
    {
        try
        {
            _httpClient.PutAsJsonAsync($"artworks/{artwork.Id}", artwork);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating artwork: {ex.Message}");
            throw;
        }
    }

    // DELETE: api/artworks/{id}
    public async Task DeleteAsync(Guid id)
    {
        try
        {
            await _httpClient.DeleteAsync($"artworks/{id}");
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting artwork: {ex.Message}");
            throw;
        }
    }
}
