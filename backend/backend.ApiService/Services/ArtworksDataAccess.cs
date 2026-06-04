namespace backend.ApiService.Services;

using backend.ApiService.Models;
using MySqlConnector;
using Dapper;

public class ArtworksDataAccess : IArtworksDataAccess
{
    private readonly string _connectionString;

    public ArtworksDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("projectwork")
            ?? throw new Exception("ConnectionString 'projectwork' not found.");
    }

    public IEnumerable<Artwork> GetArtworks()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
            SELECT 
                id,
                title,
                author,
                created_year as CreatedYear,
                description,
                technique,
                image_url as ImageUrl,
                exhibition_id as ExhibitionId
            FROM artworks
            """;
            return connection.Query<Artwork>(query);
        }
        catch (Exception ex)
        {
            throw new Exception("Errore durante GetArtworks()", ex);
        }
    }

    public Artwork? GetArtworkById(int id)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT 
                    id,
                    title,
                    author,
                    created_year as CreatedYear,
                    description,
                    technique,
                    image_url as ImageUrl,
                    exhibition_id as ExhibitionId
                FROM artworks
                WHERE id = @Id
                """;
            return connection.QueryFirstOrDefault<Artwork>(query, new { id });
        }
        catch (Exception ex)
        {
            throw new Exception("Errore durante GetArtworkById()", ex);
        }
    }

    public void AddArtwork(Artwork artwork)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            INSERT INTO artworks (
                id,
                title,
                author,
                created_year as CreatedYear,
                description,
                technique,
                image_url as ImageUrl,
                exhibition_id as ExhibitionId
            )
            VALUES (
                @Id,
                @Title,
                @Author,
                @CreatedYear,
                @Description,
                @Technique,
                @ImageUrl,
                @ExhibitionId
            );
            """;
        //SELECT last_insert_id();
        artwork.Id = connection.ExecuteScalar<int>(query, artwork);
    }
}
