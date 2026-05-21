namespace frontend.Services;

using frontend.Models;

public class ExhibitionServices : IExhibitionServices
{
    public Task<IEnumerable<Exhibition>> GetAllExhibitionsAsync()
    {
        List<Exhibition> _list = new List<Exhibition>
        {
            new Exhibition
            {
                Id = 1,
                Title = "Exhibition 1",
                Description = "Description of exhibition 1",
                StartDate = new DateOnly(2024, 1, 1),
                FinishDate = new DateOnly(2024, 1, 31),
                ImageUrl = "https://www.deltaradio.it/resizer/480/-1/true/2025_08_07/ScottiPardi-750x430-1754583136884.jpg--gerry_scotti_compie_69_anni__una_vita_tra_tv__politica_e_successi_senza_tempo.jpg?1754583136913",
                Status = "Active"
            },
            new Exhibition
            {
                Id = 2,
                Title = "Exhibition 2",
                Description = "Description of exhibition 2",
                StartDate = new DateOnly(2024, 2, 1),
                FinishDate = new DateOnly(2024, 2, 28),
                ImageUrl = "https://example.com/exhibition2.jpg",
                Status = "Upcoming"
            }
        };

        return Task.FromResult<IEnumerable<Exhibition>>(_list);
        // nella descrizione estraiamo le prime 15 parole per un anteprima, e poi quando clicchiamo su "Leggi di più" mostriamo la descrizione completa
    }

    public Exhibition GetExhibitionById(int id)
    {
        return new Exhibition
        {
            Id = id,
            Title = $"Exhibition {id}",
            Description = $"Description of exhibition {id}",
            StartDate = new DateOnly(2024, 1, 1),
            FinishDate = new DateOnly(2024, 1, 31),
            ImageUrl = $"https://example.com/exhibition{id}.jpg",
            Status = "Active"
        };
    }
}