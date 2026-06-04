using backend.Models;
//using backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Web;

public class ApiClient(HttpClient httpClient)
{
    [HttpGet(Name ="GetAllArtworks")]
    public Task<IEnumerable<Artwork>> GetArtworksAsync()
    {
        return httpClient.GetFromJsonAsync<IEnumerable<Artwork>>("api/artworks");
    }

    [HttpGet("{id}", Name ="GetArtworkFromId")]
    public Task<Artwork> GetArtworkFromId(int id)
    {
        return httpClient.GetFromJsonAsync<Artwork>($"api/artworks/{id}");
    }

    [HttpPost(Name = "AddArtwork")]
    public Task<HttpResponseMessage> AddArtworkAsync(Artwork artwork)
    {
        return httpClient.PostAsJsonAsync("api/artworks", artwork);
    }

    [HttpPut(Name = "UpdateArtwork")]
    public Task<HttpResponseMessage> UpdateArtworkAsync(Artwork artwork)
    {
        return httpClient.PutAsJsonAsync("api/artworks", artwork);
    }

    [HttpDelete("{id}", Name = "DeleteArtwork")]
    public Task<HttpResponseMessage> DeleteArtworkAsync(int id)
    {
        return httpClient.DeleteAsync($"api/artworks/{id}");
    }

    [HttpGet(Name = "GetAllExhibitions")]
    public Task<IEnumerable<Exhibition>> GetExhibitionsAsync()
    {
        return httpClient.GetFromJsonAsync<IEnumerable<Exhibition>>("api/exhibitions");
    }

    [HttpGet("{id}", Name = "GetExhibitionFromId")]
    public Task<Exhibition> GetExhibitionFromId(int id)
    {
        return httpClient.GetFromJsonAsync<Exhibition>($"api/exhibitions/{id}");
    }

    [HttpGet(Name = "GetAllGuidedTours")]
    public Task<IEnumerable<GuidedTour>> GetGuidedToursAsync()
    {
        return httpClient.GetFromJsonAsync<IEnumerable<GuidedTour>>("api/guidedtours");
    }

    [HttpGet("{id}", Name = "GetGuidedTourFromId")]
    public Task<GuidedTour> GetGuidedTourFromId(int id)
    {
        return httpClient.GetFromJsonAsync<GuidedTour>($"api/guidedtours/{id}");
    }

    [HttpPost(Name = "AddGuidedTour")]
    public Task<HttpResponseMessage> AddGuidedTourAsync(GuidedTour guidedTour)
    {
        return httpClient.PostAsJsonAsync("api/guidedtours", guidedTour);
    }
}