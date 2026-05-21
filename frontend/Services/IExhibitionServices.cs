using frontend.Models;

namespace frontend.Services
{
    public interface IExhibitionServices
    {
        Task<IEnumerable<Exhibition>> GetAllExhibitionsAsync();
        Exhibition GetExhibitionById(int id);
    }
}
