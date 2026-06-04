using frontend.Models;
using System.Collections;

namespace frontend.Services;

public class GuidedToursService : IGuidedToursService
{
    private static readonly ExhibitionsService _exhibitions = new();
    private readonly HttpClient _httpClient;

    public GuidedToursService(HttpClient httpClient) => _httpClient = httpClient;

    //public Task<IEnumerable<GuidedTour>> GetAllAsync()
    //{
    //    return Task.FromResult<IEnumerable<Exhibition>>(_list);
    //    // nella descrizione estraiamo le prime 15 parole per un anteprima, e poi quando clicchiamo su "Leggi di più" mostriamo la descrizione completa
    //}

    public async Task<GuidedTour?> GetItemByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<GuidedTour>($"api/guidedtours/{id}");
    }

    public async Task<List<GuidedTour>> GetAllAsync()
    {
        try{
            return await _httpClient.GetFromJsonAsync<List<GuidedTour>>("api/guidedtours") ?? new List<GuidedTour>();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching guided tours: {ex.Message}");
            throw;
        }
    }

    public async Task InsertAsync(GuidedTour item)
    {
        await _httpClient.PostAsJsonAsync("api/guidedtours", item);
        return;
    }
}
