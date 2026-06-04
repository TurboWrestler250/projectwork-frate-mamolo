namespace frontend.Services;

using frontend.Models;

public class ArtworksService : IArtworksService
{
    private readonly HttpClient _httpClient;
    public ArtworksService(IConfiguration configuration)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("API base URL is not configured."))
        };
    }

    // GET: api/artworks
    public async Task<IEnumerable<Artwork>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<IEnumerable<Artwork>>("artworks") ?? new List<Artwork>();
    }

    // GET: api/artworks/{id}
    public async Task<Artwork?> GetItemByIdAsync(int id)
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
    public async Task DeleteAsync(int id)
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
