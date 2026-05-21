namespace frontend.Services;

using frontend.Models;

public class ExhibitionServices
{
    public IEnumerable<Exhibition> GetAllExhibitions()
    {
        return new List<Exhibition>
        {
            new Exhibition
            {
                Id = 1,
                Title = "Exhibition 1",
                Description = "Description of exhibition 1",
                StartDate = new DateOnly(2024, 1, 1),
                FinishDate = new DateOnly(2024, 1, 31),
                ImageUrl = "https://example.com/exhibition1.jpg",
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