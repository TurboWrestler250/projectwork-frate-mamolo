using frontend.Models;

namespace frontend.Services
{
    public class TicketService
    {
        private readonly HttpClient _httpClient;
        public TicketService(IConfiguration configuration)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(configuration["ApiBaseUrl"] ?? throw new InvalidOperationException("API base URL is not configured."))
            };
        }

        public async Task<Ticket> GetTicketFromIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Ticket>($"api/tickets/{id}");
        }

        public async Task AddTicketAsync(Ticket ticket)
        {
            await _httpClient.PostAsJsonAsync("api/tickets", ticket);
            return;
        }

        public async Task AddTicketsAsync(List<Ticket> tickets)
        {
            await _httpClient.PostAsJsonAsync("api/tickets/batch", tickets);
            return;
        }
    }
}
