namespace frontend.Services;

using frontend.Models;

public class ExhibitionsService : IExhibitionsService
{
    private readonly HttpClient _httpClient;
    public ExhibitionsService(IConfiguration configuration)
    {
        _httpClient = new HttpClient
        {
            BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("API base URL is not configured."))
        };
    }

    public async Task<IEnumerable<Exhibition>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Exhibition>>("exhibitions") ;
        // nella descrizione estraiamo le prime 15 parole per un anteprima, e poi quando clicchiamo su "Leggi di più" mostriamo la descrizione completa
    }

    public async Task<Exhibition?> GetItemByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Exhibition>($"exhibitions/{id}");
    }
}