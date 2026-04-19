using System.ComponentModel.DataAnnotations;

namespace Czwiczenie6.Models;

public class Room
{
    public int Id { get; set; }
    [Required(ErrorMessage = "name is required")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "building code is required")]
    public string BuildingCode { get; set; } = string.Empty;
    public int Floor { get; set; }
    [Range(1,int.MaxValue,ErrorMessage = "capacity should be more that 0")]
    public int Capacity { get; set; }
    public bool HasProjector { get; set; }
    public bool isActive { get; set; }

}