using System;
using System.Text.Json;
using System.Xml;
using System.Collections.Generic;
using System.IO;

public class ReservationHandler
{
    private List<Reservation> ReservationList = new List<Reservation>();

    public ReservationHandler(int daysInWeek, int roomsCount)
    {

    }

    public void AddReservation(int dayIndex, int roomIndex, Reservation reservation)
    {
        ReservationList.Add(reservation);
        // Calculate the hour of the day for the reservation
        int hourOfDay = reservation.Time.Hour;

        // Adjust the hour index to match the schedule array
        hourOfDay -= 9; // Assuming the schedule starts from 9:00 AM

        /* var jsonString = JsonSerializer.Serialize(ReservationList, new JsonSerializerOptions { WriteIndented = true });
         File.WriteAllText("ReservationData.json", jsonString);
          LogOperation(reservation.ReserverName, "add");
         UpdateReservationDataJson();*/
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, "Add Reservation");
        ILogger logger = new FileLogger("LogData.json");
        logger.Log(log);


    }

    public void DeleteReservation(int dayIndex, int roomIndex, Reservation reservation)
    {
        string jsonString = File.ReadAllText("ReservationData.json");

        List<Reservation>? existingReservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString);

        existingReservations!.Remove(reservation);
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, "Delete Reservation");
        ILogger logger = new FileLogger("LogData.json");
        logger.Log(log);

        /*jsonString = JsonSerializer.Serialize(existingReservations, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText("ReservationData.json", jsonString);
        ReservationList.Remove(reservation);
         ReservationList.Remove(reservation);
        LogOperation(reservation.ReserverName, "delete");
        UpdateReservationDataJson();*/


    }
    /* private void LogOperation(string? reservationName, string operation)
   {
        if (reservationName == null)
   {
       reservationName = "Unknown";
   }

      LogRecord logRecord = new LogRecord(reservationName!, operation!, DateTime.Now);
       string logJson = JsonSerializer.Serialize(logRecord, new JsonSerializerOptions { WriteIndented = true });
       File.AppendAllText("LogData.json", logJson + Environment.NewLine);
   }

   private void UpdateReservationDataJson()
   {

       string jsonString = JsonSerializer.Serialize(ReservationList, new JsonSerializerOptions { WriteIndented = true });
       File.WriteAllText("ReservationData.json", jsonString);
   }
   public record LogRecord(string Name, string Operation, DateTime Time);
  */
}













