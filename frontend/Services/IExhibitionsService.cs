namespace frontend.Services;
using frontend.Models;

public interface IExhibitionsService
{
    Task<IEnumerable<Exhibition>> GetAllAsync();
    Task<Exhibition?> GetItemByIdAsync(int id);
}