using frontend.Models;

namespace frontend.Services
{
    public interface IGuidedToursService
    {
    Task<List<GuidedTour>> GetAllAsync();
    Task<GuidedTour?> GetItemByIdAsync(int id);
    Task InsertAsync(GuidedTour item);
    }
}