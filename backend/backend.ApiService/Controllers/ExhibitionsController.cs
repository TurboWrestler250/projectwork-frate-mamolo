using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExhibitionsController : ControllerBase
{
    private static readonly List<Exhibition> _list = new();

    [HttpGet]
    public ActionResult<IEnumerable<Exhibition>> Get() => Ok(_list);

    [HttpGet("{id}")]
    public ActionResult<Exhibition?> Get(int id)
    {
        var item = _list.FirstOrDefault(e => e.Id == id);
        if (item is null) return NotFound();
        return Ok(item);
    }

    //[HttpPost]
    //public ActionResult Post([FromBody] Exhibition ex)
    //{
    //    ex.Id = _list.Any() ? _list.Max(e => e.Id) + 1 : 1;
    //    _list.Add(ex);
    //    return CreatedAtAction(nameof(Get), new { id = ex.Id }, ex);
    //}

    //[HttpPut("{id}")]
    //public ActionResult Put(int id, [FromBody] Exhibition ex)
    //{
    //    var existing = _list.FirstOrDefault(e => e.Id == id);
    //    if (existing is null) return NotFound();
    //    existing.Title = ex.Title;
    //    existing.Description = ex.Description;
    //    existing.StartDate = ex.StartDate;
    //    existing.EndDate = ex.EndDate;
    //    existing.ImageUrl = ex.ImageUrl;
    //    existing.Status = ex.Status;
    //    return NoContent();
    //}

    //[HttpDelete("{id}")]
    //public ActionResult Delete(int id)
    //{
    //    var removed = _list.RemoveAll(e => e.Id == id);
    //    if (removed == 0) return NotFound();
    //    return NoContent();
    //}
}
