using System;
using System.Text.Json;
using System.Xml;

public class ReservationHandler
{
     private List<Reservation>ReservationList= new List<Reservation>();
      
    public ReservationHandler(int daysInWeek, int roomsCount)
    {
        
    }

    public void AddReservation(int dayIndex, int roomIndex, Reservation reservation)
    { 
        ReservationList.Add(reservation);
        // Calculate the hour of the day for the reservation
        int hourOfDay = reservation.Time.Hours;
         
        // Adjust the hour index to match the schedule array
        hourOfDay -= 9; // Assuming the schedule starts from 9:00 AM
      
       var jsonString = JsonSerializer.Serialize(ReservationList, new JsonSerializerOptions { WriteIndented = true });
       File.WriteAllText("ReservationData.json",jsonString);
    }

    public void DeleteReservation(int dayIndex, int roomIndex)
    {

    }

 
}
