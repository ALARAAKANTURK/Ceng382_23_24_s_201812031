

using LabProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;

public class RoomService
{
    private readonly WebAppDataBaseContext _context;
  //private readonly AplicationDbContext _context2;

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
    try
    {
        _context.Reservations.Add(reservation);
        _context.SaveChanges();
    }
    catch (Exception ex)
    {
        // Consider logging the exception
        Console.WriteLine("An error occurred: " + ex.Message);
        throw; // Rethrow the exception to handle it further up the call stack if necessary.
    }
}

    public List<Room> GetRooms()
    {
        return _context.Rooms.ToList();
    }
    /*public List<Reservation> GetReservations()
    {
           return _context.Reservations.ToList();
    }*/
    public List<Reservation> GetReservations()
{
    return _context.Reservations.Include(r => r.Room).ToList();
}

    
}

