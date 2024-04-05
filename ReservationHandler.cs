using System;
using System.Text.Json;
using System.Collections.Generic;
using System.IO;

public class ReservationHandler
{
    private readonly IReservationRepository reservationRepository;
    private readonly LogHandler logHandler;

    public ReservationHandler(IReservationRepository reservationRepository, LogHandler logHandler)
    {
        this.reservationRepository = reservationRepository ?? throw new ArgumentNullException(nameof(reservationRepository));
        this.logHandler = logHandler ?? throw new ArgumentNullException(nameof(logHandler));
    }

    public void AddReservation(int dayIndex, int roomIndex, Reservation reservation)
    {
        reservationRepository.AddReservation(reservation);

        // Log the add operation
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, "Add Reservation");
        logHandler.AddLog(log);
    }

    public void DeleteReservation(int dayIndex, int roomIndex, Reservation reservation)
    {
        reservationRepository.DeleteReservation(reservation);

        // Log the delete operation
        LogRecord log = new LogRecord(DateTime.Now, reservation.ReserverName, "Delete Reservation");
        logHandler.AddLog(log);
    }
}
