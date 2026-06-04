using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private static readonly List<Reservation> _list = new();

    [HttpGet]
    public ActionResult<IEnumerable<Reservation>> Get() => Ok(_list);

    [HttpGet("{id}")]
    public ActionResult<Reservation?> Get(int id)
    {
        var item = _list.FirstOrDefault(e => e.Id == id);
        if (item is null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Reservation r)
    {
        r.Id = _list.Any() ? _list.Max(e => e.Id) + 1 : 1;
        _list.Add(r);
        return CreatedAtAction(nameof(Get), new { id = r.Id }, r);
    }
}
