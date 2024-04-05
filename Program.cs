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
                Room = new Room(roomId: "001", roomName: "A-101", capacity: 30),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(10, 0, 0) // 10:00 AM
            });




            reservationHandler.AddReservation(1, 1, new Reservation
            {
                ReserverName = "Jane Smith",
                Room = new Room (roomId :"002", roomName :"A-102", capacity :24) ,
                Date = DateTime.Today.AddDays(2), // Day after tomorrow
                Time = new TimeSpan(14, 0, 0) // 2:00 PM
            });
            reservationHandler.AddReservation(1, 2, new Reservation
            {
                ReserverName = "Jany Same",
                Room = new Room (roomId : "003", roomName : "A-104", capacity :27 ),
                Date = DateTime.Today.AddDays(3), // Day after tomorrow
                Time = new TimeSpan(15, 0, 0) // 2:00 PM
            });
            reservationHandler.AddReservation(2, 2, new Reservation
            {
                ReserverName = "Ally kell",
                Room = new Room (roomId : "004", roomName :"A-105", capacity : 28 ),
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(17, 0, 0)
            });

            reservationHandler.AddReservation(2, 3, new Reservation
            {
                ReserverName = "Alice  mall",
                Room = new Room (roomId : "005", roomName : "A-108", capacity : 29 ),
                Date = DateTime.Today.AddDays(5),
                Time = new TimeSpan(12, 0, 0)
            });
            reservationHandler.AddReservation(2, 4, new Reservation
            {
                ReserverName = "Emily  wall",
                Room = new Room (roomId : "006", roomName : "A-121", capacity : 39 ),
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(17, 0, 0)
            });
            reservationHandler.AddReservation(1, 5, new Reservation
            {
                ReserverName = "Eline  sell",
                Room = new Room (roomId : "007", roomName : "A-131", capacity : 24 ),
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(17, 30, 0)
            });

            reservationHandler.AddReservation(1, 5, new Reservation
            {
                ReserverName = "Qell  sell",
                Room = new Room (roomId : "019", roomName : "A-240", capacity : 12 ),
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(12, 30, 0)
            });
            reservationHandler.AddReservation(1, 2, new Reservation
            {
                ReserverName = "kim  loren",
                Room = new Room (roomId : "022", roomName : "A-172", capacity : 22 ),
                Date = DateTime.Today.AddDays(4),
                Time = new TimeSpan(12, 30, 0)
            });

            for (int i = 0; i < 20; i++)
            {
                reservationHandler.AddReservation(i % 7, i % 8, new Reservation
                {
                    ReserverName = $"Person in CampanyA  {i + 1}", //Reservation by people at company A
                    Room = new Room (roomId : $"00{i + 1}", roomName : "$A-1{i + 1}", capacity : 22 ),
                    Date = DateTime.Today.AddDays(i + 10),
                    Time = new TimeSpan(9 + i % 9, 0, 0)
                });
            }

            for (int i = 0; i < 10; i++)
            {
                reservationHandler.AddReservation((i + 20) % 7, (i + 20) % 8, new Reservation
                {
                    ReserverName = $"Person in CampanyB {i + 21}", //Reservation by people at company B
                     Room = new Room (roomId : $"01{i + 1}", roomName : "$A-2{i + 1}", capacity : 23 ),
                    Date = DateTime.Today.AddDays(i + 20),
                    Time = new TimeSpan(10 + i % 8, 0, 0)
                });
            }
            // Add dummy reservations for time slots from 17:30 to 20:00
            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Jane Smith",
                Room = new Room (roomId : "002", roomName : "A-102", capacity : 25 ),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(17, 30, 0) // 5:30 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Alice Johnson",
                Room = new Room (roomId : "003", roomName : "A-103", capacity : 20 ),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(18, 0, 0) // 6:00 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Bob Brown",
                Room = new Room (roomId : "004", roomName : "A-104", capacity : 15 ),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(18, 30, 0) // 6:30 PM
            });

            // Add more dummy reservations as needed
            // Add dummy reservations for time slots from 19:00 to 20:30
            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Emily Wilson",
                Room = new Room (roomId : "005", roomName : "A-105", capacity : 20 ),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(19, 0, 0) // 7:00 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Michael Davis",
                Room = new Room (roomId : "006", roomName : "A-106", capacity : 15 ),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(19, 30, 0) // 7:30 PM
            });

            reservationHandler.AddReservation(0, 0, new Reservation
            {
                ReserverName = "Sarah Miller",
                Room = new Room (roomId : "007", roomName : "A-107", capacity : 25 ),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(20, 0, 0) // 8:00 PM
            });

            // Add the reservation
            Reservation addedReservation = new Reservation
            {
                ReserverName = "David Martinez",
                Room = new Room (roomId : "008", roomName : "A-108", capacity : 30 ),
                Date = DateTime.Today.AddDays(1), // Tomorrow
                Time = new TimeSpan(20, 30, 0) // 8:30 PM
            };

            reservationHandler.AddReservation(0, 0, addedReservation);


            reservationHandler.DeleteReservation(0, 0, addedReservation);





            // Display schedule
            //reservationHandler.DisplayWeeklySchedule();
        }
        else
        {
            Console.WriteLine("No room data found.");
        }
    }
}