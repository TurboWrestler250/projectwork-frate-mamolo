//using backend.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace backend.ApiService.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class ArtworksController : ControllerBase
//{
//    private static readonly List<Artwork> _list = new()
//    {
//        new Artwork
//        {
//            Id = 1,
//            Title = "Persistenza della memoria",
//            Author = "Gerry Scotty",
//            Year = 67,
//            Description = "A famous painting",
//            Technique = "Olio su tela",
//            ImageUrl = "https://example.com/image1.jpg"
//        },
//        new Artwork
//        {
//            Id = 2,
//            Title = "Skibidi toilet",
//            Author = "Thomas Turbato",
//            Year = 1690,
//            Description = "Another work",
//            Technique = "Aglio su pasta",
//            ImageUrl = "https://example.com/image2.jpg"
//        }
//    };

//    [HttpGet]
//    public ActionResult<IEnumerable<Artwork>> Get()
//    {
//        return Ok(_list);
//    }

//    [HttpGet("{id}")]
//    public ActionResult<Artwork?> Get(int id)
//    {
//        var item = _list.FirstOrDefault(a => a.Id == id);
//        if (item is null) return NotFound();
//        return Ok(item);
//    }

//    [HttpPost]
//    public ActionResult Post([FromBody] Artwork artwork)
//    {
//        artwork.Id = _list.Any() ? _list.Max(a => a.Id) + 1 : 1;
//        _list.Add(artwork);
//        return CreatedAtAction(nameof(Get), new { id = artwork.Id }, artwork);
//    }

//    [HttpPut("{id}")]
//    public ActionResult Put(int id, [FromBody] Artwork artwork)
//    {
//        var existing = _list.FirstOrDefault(a => a.Id == id);
//        if (existing is null) return NotFound();
//        existing.Title = artwork.Title;
//        existing.Author = artwork.Author;
//        existing.Year = artwork.Year;
//        existing.Description = artwork.Description;
//        existing.Technique = artwork.Technique;
//        existing.ImageUrl = artwork.ImageUrl;
//        return NoContent();
//    }

//    [HttpDelete("{id}")]
//    public ActionResult Delete(int id)
//    {
//        var removed = _list.RemoveAll(a => a.Id == id);
//        if (removed == 0) return NotFound();
//        return NoContent();
//    }
//}
