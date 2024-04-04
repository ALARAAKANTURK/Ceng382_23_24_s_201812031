using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public record RoomData
{
    public Room[]? Room { get; set; }
}



class Program
{
    static void Main(string[] args)
    {
        string jsonFilePath = "Data.json";
        string jsonString;

        try
        {
            jsonString = File.ReadAllText(jsonFilePath);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File Not Found.");
            return;
        }

        var options = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            ReadCommentHandling = JsonCommentHandling.Skip,
            AllowTrailingCommas = true
        };

        var roomData = JsonSerializer.Deserialize<RoomData>(jsonString, options);

        if (roomData?.Room != null)
        {
            ReservationHandler reservationHandler = new ReservationHandler(7, roomData.Room.Length);

            // Add dummy reservations
            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "John Doe",
                Room = new Room { RoomId = "001", RoomName = "A-101", Capacity = "30" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(10, 0, 0) // 10:00 AM
            });

            reservationHandler.AddReservation(1, 1, new Reservation
            {
                ReserverName = "Jane Smith",
                Room = new Room { RoomId = "002", RoomName = "A-102", Capacity = "24" },
                Date = DateTime.Today.AddDays(2), // Day after tomorrow
                Time = new TimeSpan(14, 0, 0) // 2:00 PM
            });
            reservationHandler.AddReservation(1, 2, new Reservation
            {
                ReserverName = "Jany Same",
                Room = new Room { RoomId = "003", RoomName = "A-104", Capacity = "27" },
                Date = DateTime.Today.AddDays(3), // Day after tomorrow
                Time = new TimeSpan(15, 0, 0) // 2:00 PM
            });
            reservationHandler.AddReservation(2, 2, new Reservation
            {
                ReserverName = "Ally kell",
                Room = new Room { RoomId = "004", RoomName = "A-105", Capacity = "28" },
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(17, 0, 0)
            });

            reservationHandler.AddReservation(2, 3, new Reservation
            {
                ReserverName = "Alice  mall",
                Room = new Room { RoomId = "005", RoomName = "A-108", Capacity = "29" },
                Date = DateTime.Today.AddDays(5),
                Time = new TimeSpan(12, 0, 0)
            });
            reservationHandler.AddReservation(2, 4, new Reservation
            {
                ReserverName = "Emily  wall",
                Room = new Room { RoomId = "006", RoomName = "A-121", Capacity = "39" },
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(17, 0, 0)
            });
            reservationHandler.AddReservation(1, 5, new Reservation
            {
                ReserverName = "Eline  sell",
                Room = new Room { RoomId = "007", RoomName = "A-131", Capacity = "24" },
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(17, 30, 0)
            });

            reservationHandler.AddReservation(1, 5, new Reservation
            {
                ReserverName = "Qell  sell",
                Room = new Room { RoomId = "019", RoomName = "A-240", Capacity = "12" },
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(12, 30, 0)
            });
            reservationHandler.AddReservation(1, 2, new Reservation
            {
                ReserverName = "kim  loren",
                Room = new Room { RoomId = "022", RoomName = "A-172", Capacity = "22" },
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(12, 30, 0)
            });

            for (int i = 0; i < 20; i++)
            {
                reservationHandler.AddReservation(i % 7, i % 8, new Reservation
                {
                    ReserverName = $"Person in CampanyA  {i + 1}", //Reservation by people at company A
                    Room = new Room { RoomId = $"00{i + 1}", RoomName = $"A-1{i + 1}", Capacity = "22" },
                    Date = DateTime.Today.AddDays(i + 10),
                    Time = new TimeSpan(9 + i % 9, 0, 0)
                });
            }

            for (int i = 0; i < 10; i++)
            {
                reservationHandler.AddReservation((i + 20) % 7, (i + 20) % 8, new Reservation
                {
                    ReserverName = $"Person in CampanyB {i + 21}", //Reservation by people at company B
                    Room = new Room { RoomId = $"01{i + 1}", RoomName = $"A-2{i + 1}", Capacity = "22" },
                    Date = DateTime.Today.AddDays(i + 20),
                    Time = new TimeSpan(10 + i % 8, 0, 0)
                });
            }
            // Add dummy reservations for time slots from 17:30 to 20:00
            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Jane Smith",
                Room = new Room { RoomId = "002", RoomName = "A-102", Capacity = "25" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(17, 30, 0) // 5:30 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Alice Johnson",
                Room = new Room { RoomId = "003", RoomName = "A-103", Capacity = "20" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(18, 0, 0) // 6:00 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Bob Brown",
                Room = new Room { RoomId = "004", RoomName = "A-104", Capacity = "15" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(18, 30, 0) // 6:30 PM
            });

            // Add more dummy reservations as needed
            // Add dummy reservations for time slots from 19:00 to 20:30
            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Emily Wilson",
                Room = new Room { RoomId = "005", RoomName = "A-105", Capacity = "20" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(19, 0, 0) // 7:00 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Michael Davis",
                Room = new Room { RoomId = "006", RoomName = "A-106", Capacity = "15" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(19, 30, 0) // 7:30 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Sarah Miller",
                Room = new Room { RoomId = "007", RoomName = "A-107", Capacity = "25" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(20, 0, 0) // 8:00 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "David Martinez",
                Room = new Room { RoomId = "008", RoomName = "A-108", Capacity = "30" },
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(20, 30, 0) // 8:30 PM
            });

            



            // Display schedule
            //reservationHandler.DisplayWeeklySchedule();
        }
        else
        {
            Console.WriteLine("No room data found.");
        }
    }
}