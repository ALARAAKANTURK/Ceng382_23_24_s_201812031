using Microsoft.EntityFrameworkCore;
using MyApp.Namespace;
using  LabProject.Models;

public class RoomService
{
    private readonly WebAppDatabaseContext a_context;
    public List<Room> RoomList { get; set; } = default!;
    public RoomService(WebAppDatabaseContext context)
    {
        this.a_context = context;
    }
    public void AddRooms(Room room)
    {
        a_context.Add(room);
        a_context.SaveChanges();
        LogAction("Add Room", $"Room added: {room.RoomName}");

    }
    public List<Room> GetRooms()
    {
        return a_context.Rooms.ToList<Room>();
    }
    public void AddReservation(Reservation reservation)
    {
        try
        {
            a_context.Reservations.Add(reservation);
            a_context.SaveChanges();
            LogAction("Add Reservation", $"Reservation was added: {reservation.Id}");

        }
        catch (Exception ex)
        {
            // Consider logging the exception
            Console.WriteLine("An error occurred: " + ex.Message);
            throw; // Rethrow the exception to handle it further up the call stack if necessary.
        }

    }
    public void DeleteReservation(int reservationId)
    {
        var reservation = a_context.Reservations.Find(reservationId);
        if (reservation != null)
        {
            a_context.Reservations.Remove(reservation);
            a_context.SaveChanges();
            LogAction("Delete Reservation", $"Reservation deleted: {reservation.Id}");

        }
    }
    public void EditReservation(Reservation Newreservation)
    {
        var existingReservation = a_context.Reservations.Find(Newreservation.Id);
        if (existingReservation != null)
        {
            existingReservation.RoomId = Newreservation.RoomId;
            existingReservation.ReservationDate =Newreservation.ReservationDate;
            existingReservation.ReservationEndDate = Newreservation.ReservationEndDate;
            existingReservation.ReserverName = Newreservation.ReserverName;
            a_context.SaveChanges();
            LogAction("Edit Reservation", $"Reservation edited: {Newreservation.Id}");

        }
    }
    public List<Reservation> GetReservations()
    {
        return a_context.Reservations.Include(r => r.Room).ToList();
    }
    private void LogAction(string action, string details)
    {
        var log = new LogTable    
        {
            LogDate = DateTime.Now,
            Details = $"{action}: {details}"
        };

        a_context.LogTables.Add(log);
        a_context.SaveChanges();
    }
}