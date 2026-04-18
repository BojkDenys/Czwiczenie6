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

    [HttpGet("{id:int}")]
    public ActionResult<Room> GetRoomById(int id)
    {
        var room = AppData.Rooms.FirstOrDefault(r => r.Id == id);
        if (room == null)
        {
            return NotFound();
        }

        return Ok(room);
    }

    [HttpGet("building/{buildingCode}")]
    public ActionResult<IEnumerable<Room>> GetRoomsByBuilding(string buildingCode)
    {
        var rooms = AppData.Rooms
            .Where(r => r.BuildingCode.Equals(buildingCode, StringComparison.OrdinalIgnoreCase))
            .ToList();
        return Ok(rooms);
    }

    [HttpPost]
    public ActionResult<Room> CreateRoom([FromBody] Room room)
    {
        var newId = AppData.Rooms.Max(r => r.Id) + 1;
        room.Id = newId;
        AppData.Rooms.Add(room);
        return CreatedAtAction(nameof(GetRoomById), new { id = room.Id }, room);
    } 
}