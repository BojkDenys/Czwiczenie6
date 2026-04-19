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
    
}