using Czwiczenie6.Data;
using Czwiczenie6.Models;
using Microsoft.AspNetCore.Mvc;

namespace Czwiczenie6.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Reservation>> GetAllReservations(
        [FromQuery] DateOnly? date,
        [FromQuery] string? status,
        [FromQuery] int? roomId
    )
    {
        IEnumerable<Reservation> reservations = AppData.Reservations;
        if (date.HasValue)
        {
            reservations = reservations.Where(r => r.Date == date.Value);
        }

        if (!string.IsNullOrWhiteSpace(status))
        {
            reservations = reservations.Where(r => r.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        if (roomId.HasValue)
        {
            reservations = reservations.Where(r => r.RoomId == roomId.Value);
        }

        return Ok(reservations);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Reservation> GetReservationById(int id)
    {
        var reservation = AppData.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }

        return Ok(reservation);
    }

    [HttpPost]
    public ActionResult<Reservation> CreateReservation([FromBody] Reservation reservation)
    {
        var room = AppData.Rooms.FirstOrDefault(r => r.Id == reservation.RoomId);
        if (room == null)
        {
            return BadRequest("Invalid room Id");
        }

        if (!room.isActive)
        {
            return BadRequest("Can not create reservation for inactive room");
        }

        var isReservation = AppData.Reservations.Any(r =>
            r.RoomId == reservation.RoomId &&
            r.Date == reservation.Date &&
            reservation.StartTime < r.EndTime &&
            reservation.EndTime > r.StartTime);
        if (isReservation)
        {
            return Conflict("It is another reservation for this room for this time");
        }

        var newId = AppData.Reservations.Max(r => r.Id) + 1;
        reservation.Id = newId;
        AppData.Reservations.Add(reservation);
        return CreatedAtAction(nameof(GetReservationById), new { id = reservation.Id },reservation);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateReservation(int id, [FromBody] Reservation updatedReservation)
    {
        var reservation = AppData.Reservations.FirstOrDefault(r => r.Id == id);
        if (reservation == null)
        {
            return NotFound();
        }

        var room = AppData.Rooms.FirstOrDefault(r => r.Id == updatedReservation.RoomId);
        if (room == null)
        {
            return BadRequest("Invalid room Id");
        }

        if (!room.isActive)
        {
            return BadRequest("Can not create reservation for inactive room");
        }

        var isReservation = AppData.Reservations.Any(r =>
            r.RoomId == reservation.RoomId &&
            r.Date == reservation.Date &&
            reservation.StartTime < r.EndTime &&
            reservation.EndTime > r.StartTime);
        if (isReservation)
        {
            return Conflict("It is another reservation for this room for this time");
        }

        reservation.RoomId = updatedReservation.RoomId;
        reservation.Date = updatedReservation.Date;
        reservation.EndTime = updatedReservation.EndTime;
        reservation.StartTime = updatedReservation.StartTime;
        reservation.Status = updatedReservation.Status;
        reservation.OrganizerName = updatedReservation.OrganizerName;
        reservation.Topic = updatedReservation.Topic;
        return Ok(room);
    }
}