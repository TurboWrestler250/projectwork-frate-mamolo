using frontend.Models;

namespace frontend.Services
{
    public interface ITicketsService
    {
        Task AddTicketAsync(Ticket ticket);
        Task AddTicketsAsync(List<Ticket> tickets);
        Task<Ticket> GetTicketFromIdAsync(int id);
    }
}