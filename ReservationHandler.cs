using System;
using System.Text.Json;
using System.Xml;
using System.Collections.Generic;
using System.IO;

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

    public void DeleteReservation(int dayIndex, int roomIndex, Reservation reservation)
    { 
        // Load existing JSON data from the file into memory
    string jsonString = File.ReadAllText("ReservationData.json");

    // Deserialize the JSON data into a list of reservations
    List<Reservation>? existingReservations = JsonSerializer.Deserialize<List<Reservation>>(jsonString);

    // Remove the specific reservation from the in-memory list
    existingReservations!.Remove(reservation);

    // Serialize the updated ReservationList and write it back to the ReservationData.json file
    jsonString = JsonSerializer.Serialize(existingReservations, new JsonSerializerOptions { WriteIndented = true });
    File.WriteAllText("ReservationData.json", jsonString);
    }

    }

 

