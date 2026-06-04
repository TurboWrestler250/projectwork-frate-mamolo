namespace frontend.Services;

using frontend.Models;

public class ExhibitionsService : IExhibitionsService
{
    private readonly HttpClient _httpClient = new();

    public async Task<IEnumerable<Exhibition>> GetAllAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<Exhibition>>("exhibitions") ?? list;
        // nella descrizione estraiamo le prime 15 parole per un anteprima, e poi quando clicchiamo su "Leggi di più" mostriamo la descrizione completa
    }

    public async Task<Exhibition?> GetItemByIdAsync(int id)
    {
        return await _httpClient.GetFromJsonAsync<Exhibition>($"exhibitions/{id}") ?? list.FirstOrDefault(e => e.Id == id);
    }
}