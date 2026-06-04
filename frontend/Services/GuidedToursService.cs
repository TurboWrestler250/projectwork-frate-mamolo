using frontend.Models;
using System.Collections;

namespace frontend.Services;

public class GuidedToursService : IGuidedToursService
{
    private static readonly ExhibitionsService _exhibitions = new();
    private static readonly List<GuidedTour> _list = [];

    private static async Task<List<GuidedTour>> BuildListAsync()
    {
        return
        [
            new GuidedTour
            {
                Id = new Guid("ebd94f0e-879c-45e7-a709-342eee16923c"),
                Title = "Palazzo Attems Petzenstein",
                Description = "Ultimato nella sua veste rococò nel 1750...",
                Date = new DateTime(2023, 1, 13, 14, 30, 25),
                Duration = new TimeSpan(2, 30, 0),
                GuideName = "Mario",
                GuideSurname = "Rossi",
                MaxParticipants = 20,
                Exhibition = (await _exhibitions.GetItemByIdAsync(0))?.Title ?? "archived"
            },
            new GuidedTour
            {
                Id = new Guid("95852f08-848a-4614-9857-06b26362ba5a"),
                Title = "Palazzo Attems Petzenstein",
                Description = "Ultimato nella sua veste rococò nel 1750...",
                Date = new DateTime(2023, 1, 13, 14, 30, 25),
                Duration = new TimeSpan(2, 30, 0),
                GuideName = "Mario",
                GuideSurname = "Rossi",
                MaxParticipants = 20,
                Exhibition = (await _exhibitions.GetItemByIdAsync(1))?.Title ?? "archived"
            }
        ];
    }

    //public Task<IEnumerable<GuidedTour>> GetAllAsync()
    //{
    //    return Task.FromResult<IEnumerable<Exhibition>>(_list);
    //    // nella descrizione estraiamo le prime 15 parole per un anteprima, e poi quando clicchiamo su "Leggi di più" mostriamo la descrizione completa
    //}

    public async Task<GuidedTour?> GetItemByIdAsync(Guid id)
    {
        var list = await BuildListAsync();
        return list.FirstOrDefault(x => x.Id == id);
    }

    public async Task<List<GuidedTour>> GetAllAsync()
    {
        return await BuildListAsync();
    }

    public Task InsertAsync(GuidedTour item)
    {
        if (item.Id == Guid.Empty)
            item.Id = Guid.NewGuid();

        _list.Add(item);
        return Task.CompletedTask;
    }
}
