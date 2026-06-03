namespace frontend.Services;

using frontend.Models;

public class ArtworksService : IArtworksService
{
    private readonly HttpClient _http;
    //public ArtworksService(HttpClient http) => _http = http;

    private static readonly List<Artwork> list =
    [
        new Artwork
        {
            Id = 1,
            Title = "Persistenza della memoria",
            Author = "Gerry Scotty",
            Year = 67,
            Description = """
            We're no strangers to love
            You know the rules and so do I
            A full commitment's what I'm thinking of
            You wouldn't get this from any other guy
            I just wanna tell you how I'm feeling
            Gotta make you understand
            Never gonna give you up
            Never gonna let you down
            Never gonna run around and desert you
            Never gonna make you cry
            Never gonna say goodbye
            Never gonna tell a lie and hurt you
            We've known each other for so long Your heart's been aching, but you're too shy to say it Inside, we both know what's been going on We know the game, and we're gonna play it And if you ask me how I'm feeling Don't tell me you're too blind to see Never gonna give you up Never gonna let you down Never gonna run around and desert you Never gonna make you cry Never gonna say goodbye Never gonna tell a lie and hurt you
            """,
            Technique = "Olio su tela",
            ImageUrl = "https://img.bgstatic.com/multiLang/web/44528784f7bc9c0f6cb1ad0e4cc23f5d.jpg"
        },
        new Artwork
        {
            Id= 2,
            Title ="Skibidi toilet",
            Author = "Thomas Turbato",
            Description = "Skibidi toilet è un fenomeno virale che ha conquistato internet con la sua combinazione di musica orecchiabile e coreografie stravaganti. Il video originale, pubblicato su YouTube, mostra persone che ballano in modo bizzarro mentre indossano costumi da bagno e si muovono in modo sincronizzato. La canzone, con il suo ritmo contagioso, ha ispirato milioni di persone a creare i propri video di danza Skibidi, rendendo il fenomeno un successo globale. La popolarità del Skibidi toilet ha dimostrato come la creatività e l'umorismo possano unire le persone attraverso i social media, creando una comunità globale di fan che condividono la loro passione per questa stravagante tendenza.",
            Year = 1690,
            Technique = "Aglio su pasta",
            ImageUrl = "https://m.media-amazon.com/images/M/MV5BMzgzMzY2MmMtMWNkNy00ZjVkLWIxOWUtZDJjODNmY2IyOWFiXkEyXkFqcGc@._V1_QL75_UX190_CR0,28,190,281_.jpg"
        }
    ];

    // GET: api/artworks
    public Task<IEnumerable<Artwork>> GetAllAsync()
    {
        return Task.FromResult<IEnumerable<Artwork>>(list);
    }

    // GET: api/artworks/{id}
    public Task<Artwork?> GetItemByIdAsync(int id)
    {
        Artwork? artwork = list.FirstOrDefault(e => e.Id == id);

        return Task.FromResult(artwork);
    }

    // POST: api/artworks
    public Task AddAsync(Artwork artwork)
    {
        try
        {
            list.Add(artwork);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding artwork: {ex.Message}");
            throw;
        }
    }

    // PUT: api/artworks/{id}
    public Task UpdateAsync(Artwork artwork)
    {
        try
        {
            Artwork? existingArtwork = list.FirstOrDefault(e => e.Id == artwork.Id);
            if (existingArtwork != null)
            {
                existingArtwork.Title = artwork.Title;
                existingArtwork.Author = artwork.Author;
                existingArtwork.Year = artwork.Year;
                existingArtwork.Description = artwork.Description;
                existingArtwork.Technique = artwork.Technique;
                existingArtwork.ImageUrl = artwork.ImageUrl;
            }
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating artwork: {ex.Message}");
            throw;
        }
    }

    // DELETE: api/artworks/{id}
    public async Task DeleteAsync(int id)
    {
        try
        {
            list.RemoveAll(e => e.Id == id);
            return;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting artwork: {ex.Message}");
            throw;
        }
    }
}
