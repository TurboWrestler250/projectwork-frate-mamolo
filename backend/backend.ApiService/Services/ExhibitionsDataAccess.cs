namespace backend.ApiService.Services;

using backend.ApiService.Models;
using MySqlConnector;
using Dapper;

public class ExhibitionsDataAccess : IExhibitionsDataAccess
{
    private readonly string _connectionString;

    public ExhibitionsDataAccess(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("projectwork")
            ?? throw new Exception("ConnectionString 'projectwork' not found.");
    }

    public IEnumerable<Exhibition> GetExhibitions()
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
            SELECT 
                id,
                title,
                description,
                start_date as StartDate,
                end_date as EndDate,
                image_url as ImageUrl,
                status
            FROM exhibitions
            """;
            return connection.Query<Exhibition>(query);
        }
        catch (Exception ex)
        {
            throw new Exception("Errore durante GetExhibitions()", ex);
        }
    }

    public Exhibition? GetExhibitionById(int id)
    {
        try
        {
            using var connection = new MySqlConnection(_connectionString);
            const string query = """
                SELECT 
                    id,
                    title,
                    description,
                    start_date as StartDate,
                    end_date as EndDate,
                    image_url as ImageUrl,
                    status
                FROM exhibitions
                WHERE id = @Id
                """;
            return connection.QueryFirstOrDefault<Exhibition>(query, new { id });
        }
        catch (Exception ex)
        {
            throw new Exception("Errore durante GetExhibitionById()", ex);
        }
    }

    public void AddExhibition(Exhibition exhibition)
    {
        using var connection = new MySqlConnection(_connectionString);
        const string query = """
            INSERT INTO exhibitions (
                id,
                title,
                description,
                start_date as StartDate,
                end_date as EndDate,
                image_url as ImageUrl,
                status
            )
            VALUES (
                @Id,
                @Title,
                @Description,
                @StartDate,
                @EndDate,
                @ImageUrl,
                @Status
            );
            """;
        //SELECT last_insert_id();
        exhibition.Id = connection.ExecuteScalar<int>(query, exhibition);
    }
}
