using frontend.Models;

namespace frontend.Services
{
    public interface IGuidedToursService
    {
        Task<List<GuidedTour>> GetAllAsync();
        Task<GuidedTour?> GetItemByIdAsync(Guid id);
        Task InsertAsync(GuidedTour item);
    }
}