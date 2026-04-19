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
        Reservations = new List<Reservation>
        {
            new Reservation
            {
                Id = 1,
                Date = new DateOnly(2026, 4, 19),
                StartTime = new TimeOnly(9, 0),
                EndTime = new TimeOnly(10, 30),
                OrganizerName = "Denys Boiko",
                RoomId = 1,
                Status = "confirmed",
                Topic = "Java 2026"
            },
            new Reservation
            {
                Id = 2,
                Date = new DateOnly(2026, 4, 19),
                StartTime = new TimeOnly(11, 0),
                EndTime = new TimeOnly(12, 30),
                OrganizerName = "August Rugoz",
                RoomId = 2,
                Status = "planned",
                Topic = "C# 2026"
            },
            new Reservation
            {
                Id = 3,
                Date = new DateOnly(2026, 4, 20),
                StartTime = new TimeOnly(13, 0),
                EndTime = new TimeOnly(14, 0),
                OrganizerName = "Mychajlo Cherpak",
                RoomId = 3,
                Status = "confirmed",
                Topic = "Python 2026"
            },
            new Reservation
            {
                Id = 4,
                Date = new DateOnly(2026, 4, 21),
                StartTime = new TimeOnly(8, 30),
                EndTime = new TimeOnly(10, 0),
                OrganizerName = "Voidek Pamanchuk",
                RoomId = 4,
                Status = "cancelled",
                Topic = "C++ 2026"
            },
            new Reservation
            {
                Id = 5,
                Date = new DateOnly(2026, 4, 22),
                StartTime = new TimeOnly(15, 0),
                EndTime = new TimeOnly(16, 30),
                OrganizerName = "Purum Surum",
                RoomId = 2,
                Status = "confirmed",
                Topic = "C 2026"
            }
        };

    }
}