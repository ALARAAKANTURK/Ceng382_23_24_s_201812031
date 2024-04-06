using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class ReservationHandler
{
    private readonly IReservationRepository reservationRepository;
    private readonly LogHandler logHandler;
    private readonly RoomHandler roomHandler;

    public ReservationHandler(IReservationRepository reservationRepository, LogHandler logHandler, RoomHandler roomHandler)
    {
        this.reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        this.logHandler = logHandler ?? throw new ArgumentNullException(nameof(logHandler));
        this.roomHandler = roomHandler ?? throw new ArgumentNullException(nameof(roomHandler));
    }

    public void AddReservation(int dayIndex, int roomIndex, Reservation reservation)
    {
        // Get room data
        List<Room>? rooms = roomHandler.GetRooms();
        if (rooms == null)
        {
            Console.WriteLine("Error retrieving room data.");
            return;
        }

        // Add reservation
        reservationRepository.AddReservation(reservation);

        // Log the add operation
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, "Add Reservation");
        logHandler.AddLog(log);
    }

    public void DeleteReservation(int dayIndex, int roomIndex, Reservation reservation)
    {
        // Get room data
        List<Room>? rooms = roomHandler.GetRooms();
        if (rooms == null)
        {
            Console.WriteLine("Error retrieving room data.");
            return;
        }

        // Delete reservation
        reservationRepository.DeleteReservation(reservation);

        // Log the delete operation
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, "Delete Reservation");
        logHandler.AddLog(log);
    }
}
