using Czwiczenie6.Models;

namespace Czwiczenie6.Data;

public class AppData
{
    public static List<Room> Rooms { get; private set; } = new();
    public static List<Reservation> Reservations { get; private set; } = new();

    public static void Init()
    {
        Rooms = new List<Room>
        {
            new Room
            {
                Id = 1,
                Name = "Room A101",
                BuildingCode = "A",
                Floor = 1,
                Capacity = 20,
                HasProjector = true,
                isActive = true
            },
            new Room
            {
                Id = 2,
                Name = "Room B204",
                BuildingCode = "B",
                Floor = 2,
                Capacity = 36,
                HasProjector = true,
                isActive = true
            },
            new Room
            {
                Id = 3,
                Name = "Room C304",
                BuildingCode = "C",
                Floor = 3,
                Capacity = 12,
                HasProjector = true,
                isActive = true
            },
            new Room
            {
                Id = 4,
                Name = "Room B580",
                BuildingCode = "B",
                Floor = 5,
                Capacity = 47,
                HasProjector = false,
                isActive = true
            },
            new Room
            {
                Id = 5,
                Name = "Room A404",
                BuildingCode = "A",
                Floor = 4,
                Capacity = 33,
                HasProjector = false,
                isActive = false
            }
        };
        
    }
}