using backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace backend.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TicketsController : ControllerBase
{
    private static readonly List<Ticket> _list = new();

    [HttpGet]
    public ActionResult<IEnumerable<Ticket>> Get() => Ok(_list);

    [HttpGet("{id}")]
    public ActionResult<Ticket?> Get(int id)
    {
        var item = _list.FirstOrDefault(e => e.Id == id);
        if (item is null) return NotFound();
        return Ok(item);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Ticket t)
    {
        t.Id = _list.Any() ? _list.Max(e => e.Id) + 1 : 1;
        _list.Add(t);
        return CreatedAtAction(nameof(Get), new { id = t.Id }, t);
    }
}
