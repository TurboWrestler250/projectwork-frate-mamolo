namespace backend.ApiService.Services;

using backend.ApiService.Models;

public interface IExhibitionsDataAccess
{
    IEnumerable<Exhibition> GetExhibitions();
    Exhibition? GetExhibitionById(int id);
    void AddExhibition(Exhibition exhibition);
}