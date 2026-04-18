using Czwiczenie6.Data;
using Czwiczenie6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Czwiczenie6.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Room>> GetAllRooms(
        [FromQuery] int? minCapacity,
        [FromQuery] bool? hasProjector,
        [FromQuery] bool? activeOnly
    )
    {
        IEnumerable<Room> rooms = AppData.Rooms;
        if (minCapacity.HasValue)
        {
            rooms = rooms.Where(r => r.Capacity >= minCapacity.Value);
        }

        if (hasProjector.HasValue)
        {
            rooms = rooms.Where(r => r.HasProjector == hasProjector.Value);
        }

        if (activeOnly.HasValue && activeOnly.Value)
        {
            rooms = rooms.Where(r => r.isActive);
        }

        return Ok(rooms);
    }
}