

using LabProject.Models;
using System.Collections.Generic;

public class RoomService
{
    private readonly WebAppDataBaseContext _context;

    public RoomService(WebAppDataBaseContext context)
    {
        _context = context;
    }

    public void AddRoom(Room room)
    { 
        _context.Rooms.Add(room); // Corrected casing and method name
        _context.SaveChanges();
    }

    public void AddReservation(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();

    }

    public List<Room> GetRooms()
    {
        return _context.Rooms.ToList();
    }
    
}
