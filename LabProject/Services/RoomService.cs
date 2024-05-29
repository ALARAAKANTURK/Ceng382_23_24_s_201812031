using LabProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class RoomService
{
    private readonly WebAppDataBaseContext _context;

    public RoomService(WebAppDataBaseContext context)
    {
        _context = context;
    }

    public void AddRoom(Room room)
    { 
        _context.Rooms.Add(room);
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

    public List<Reservation> GetReservations()
    {
        return _context.Reservations.Include(r => r.Room).ToList();
    }

    public Reservation GetReservationById(int id)
    {
        return _context.Reservations.Include(r => r.Room).FirstOrDefault(r => r.Id == id);
    }

    public void UpdateReservation(Reservation reservation)
    {
        var existingReservation = GetReservationById(reservation.Id);
        if (existingReservation != null)
        {
            existingReservation.ReserverName = reservation.ReserverName;
            existingReservation.ReservationDate = reservation.ReservationDate;
            existingReservation.RoomId = reservation.RoomId;
            _context.SaveChanges();
        }
    }

    public void DeleteReservation(int id)
    {
        var reservation = GetReservationById(id);
        if (reservation != null)
        {
            _context.Reservations.Remove(reservation);
            _context.SaveChanges();
        }
    }
}
