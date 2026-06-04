using frontend.Models;
using System.Collections;

namespace frontend.Services;

public class GuidedToursService : IGuidedToursService
{
    private static readonly ExhibitionsService _exhibitions;
    private readonly HttpClient _httpClient;
    public GuidedToursService(IConfiguration configuration)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("API base URL is not configured."))
        };
    }

    //public Task<IEnumerable<GuidedTour>> GetAllAsync()
    //{
    //    return Task.FromResult<IEnumerable<Exhibition>>(_list);
    //    // nella descrizione estraiamo le prime 15 parole per un anteprima, e poi quando clicchiamo su "Leggi di più" mostriamo la descrizione completa
    //}

    public async Task<GuidedTour?> GetItemByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<GuidedTour>($"guidedtours{id}");
    }

    public async Task<List<GuidedTour>> GetAllAsync()
    {
        try{
            return await _httpClient.GetFromJsonAsync<List<GuidedTour>>("guidedtours") ?? new List<GuidedTour>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching guided tours: {ex.Message}");
            throw;
        }
    }

    public async Task InsertAsync(GuidedTour item)
    {
        await _httpClient.PostAsJsonAsync("guidedtours", item);
        return;
    }
}
