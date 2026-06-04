//using backend.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace backend.ApiService.Controllers;

//[ApiController]
//[Route("api/[controller]")]
//public class GuidedToursController : ControllerBase
//{
//    private static readonly List<GuidedTour> _list = new();

//    [HttpGet]
//    public ActionResult<IEnumerable<GuidedTour>> Get() => Ok(_list);

//    [HttpGet("{id}")]
//    public ActionResult<GuidedTour?> Get(int id)
//    {
//        var item = _list.FirstOrDefault(e => e.Id == id);
//        if (item is null) return NotFound();
//        return Ok(item);
//    }

//    [HttpPost]
//    public ActionResult Post([FromBody] GuidedTour gt)
//    {
//        gt.Id = _list.Any() ? _list.Max(e => e.Id) + 1 : 1;
//        _list.Add(gt);
//        return CreatedAtAction(nameof(Get), new { id = gt.Id }, gt);
//    }
//}
