using System.ComponentModel.DataAnnotations;

namespace Czwiczenie6.Models;

public class Reservation : IValidatableObject
{
    public int Id { get; set; }
    [Range(1,int.MaxValue,ErrorMessage = "room id should be more than 0")]
    public int RoomId { get; set; }
    [Required(ErrorMessage = "organizer name is required")]
    public string OrganizerName { get; set; } = string.Empty;
    [Required(ErrorMessage = "topic is required")]
    public string Topic { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public TimeOnly StartTime { get; set; }
    public TimeOnly EndTime { get; set; }
    [Required(ErrorMessage = "status is required")]
    public string Status { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (EndTime <= StartTime)
        {
            yield return new ValidationResult(
                "end time must be later start time", new[] { nameof(EndTime), nameof(StartTime) });
        }
    }
}