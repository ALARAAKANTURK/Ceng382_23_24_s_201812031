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
              ILogger logger = new FileLogger("LogData.json");
        LogHandler logHandler = new LogHandler(logger);
        RoomHandler roomHandler = new RoomHandler("RoomData.json"); // Adjust file path as needed
         IReservationRepository reservationRepository = new ReservationRepository();
        ReservationHandler reservationHandler = new ReservationHandler(reservationRepository, logHandler, roomHandler);

                   
              
            Reservation AddReservation = new Reservation(
            
                ReserverName : "Sarah Miller",
                Room : new Room(RoomId: "007", RoomName: "A-107", Capacity: 25),
                Date : DateTime.Today.AddDays(1), // Tomorrow
                Time  : DateTime.Today.Date.AddHours(20).AddMinutes(0) // 8:00 PM
            );

            // Add the reservation
             Reservation addedReservation = new Reservation(
        ReserverName: "David Martinez",
      Room: new Room(RoomId: "008", RoomName: "A-108", Capacity: 30),
      Date: DateTime.Today.AddDays(1), // Tomorrow
       Time: DateTime.Today.Date.AddHours(20).AddMinutes(30) // 8:30 PM
        );









            // Display schedule
            //reservationHandler.DisplayWeeklySchedule();
        }
        else
        {
            Console.WriteLine("No room data found.");
        }
    }
}