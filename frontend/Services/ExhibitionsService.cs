namespace frontend.Services;

using frontend.Models;

public class ExhibitionsService : IExhibitionsService
{
    public Task<IEnumerable<Exhibition>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Exhibition>>(new List<Exhibition>
        {
            new Exhibition
            {
                Id = 1,
                Title = "Palazzo Attems Petzenstein",
                Description = "Ultimato nella sua veste rococò nel 1750, oggi ospita mostre temporanee e la Pinacoteca dei Musei Provinciali-ERPAC FVG di Gorizia.",
                StartDate = new DateOnly(2023, 1, 13),
                FinishDate = new DateOnly(2026, 5, 21),
                ImageUrl = "https://backoffice2-comuni.regione.fvg.it/media/files/erpac_musei_gorizia/previews/72840120_1169518193238578_1749242460564881408_o.jpg.640x480_q85_crop.jpg.webp",
                Status = "Active"
            },
            new Exhibition
            {
                Id = 2,
                Title = "Fototeca",
                Description = "Migliaia di stampe d’epoca, diapositive, cartoline e negativi, collegati alle vicende locali, a cui si aggiungono le vedute di Gorizia prima e dopo la...",
                StartDate = new DateOnly(2023, 1, 9),
                FinishDate = new DateOnly(2026, 5, 21),
                ImageUrl = "https://backoffice2-comuni.regione.fvg.it/media/files/erpac_musei_gorizia/previews/Gorizia_incrocio_Corso_Verdi_via_Diaz_prima_della_cos_x7lMJcW.jpg.640x480_q85_crop.jpg.webp",
                Status = "Upcoming"
            }
        });
        // nella descrizione estraiamo le prime 15 parole per un anteprima, e poi quando clicchiamo su "Leggi di più" mostriamo la descrizione completa
    }

    public Task<Exhibition?> GetItemByIdAsync(int id)
    {
        return Task.FromResult<Exhibition?>(new Exhibition
        {
            Id = id,
            Title = $"Exhibition {id}",
            Description = $"Description of exhibition {id}",
            StartDate = new DateOnly(2024, 1, 1),
            FinishDate = new DateOnly(2024, 1, 31),
            ImageUrl = $"https://example.com/exhibition{id}.jpg",
            Status = "Active"
        });
    }
}