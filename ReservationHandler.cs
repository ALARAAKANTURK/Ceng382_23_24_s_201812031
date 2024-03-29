using System;

public class ReservationHandler
{
    private Reservation?[,] schedule;

    public ReservationHandler(int daysInWeek, int roomsCount)
    {
        schedule = new Reservation?[daysInWeek, roomsCount]; // Nullable Reservation
    }

    public void AddReservation(int dayIndex, int roomIndex, Reservation reservation)
    {
        // Calculate the hour of the day for the reservation
        int hourOfDay = reservation.Time.Hours;

        // Adjust the hour index to match the schedule array
        hourOfDay -= 9; // Assuming the schedule starts from 9:00 AM

        // Add the reservation to the schedule
        schedule[dayIndex, hourOfDay] = reservation;
    }

    public void DeleteReservation(int dayIndex, int roomIndex)
    {
        schedule[dayIndex, roomIndex] = null;
    }

 public void DisplayWeeklySchedule()
{
    string[] daysOfWeek = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
    int numDays = daysOfWeek.Length;

    // Determine the maximum width for each column
    int timeWidth = 8; // Default width for time column
    int[] dayWidths = new int[numDays];
    for (int i = 0; i < numDays; i++)
    {
        dayWidths[i] = Math.Max(daysOfWeek[i].Length + 2, 10); // Minimum width of 10 characters
        for (int hour = 9; hour <= 20; hour++) // Adjusted loop bounds
        {
            var reservation = schedule[i, hour - 9];
            if (reservation != null && reservation.Room != null)
            {
                if (reservation.Room.RoomName != null)
                {
                    int roomNameLength = reservation.Room.RoomName.Length;
                    dayWidths[i] = Math.Max(dayWidths[i], roomNameLength + 2);
                }
            }
        }
    }

    // Print table headers
    Console.Write("┌" + new string('─', timeWidth) + "┬"); // Adjusted for the top-left corner
    foreach (var dayWidth in dayWidths)
    {
        Console.Write(new string('─', dayWidth) + "┬"); // Day columns
    }
    Console.WriteLine();

    // Print day names
    Console.Write("│" + String.Format("{0,-" + timeWidth + "}", "Time") + "│");
    for (int i = 0; i < numDays; i++)
    {
        Console.Write($"{daysOfWeek[i].PadRight(dayWidths[i])}│");
    }
    Console.WriteLine();

    // Display schedule by time slots
    for (int hour = 9; hour <= 20; hour++) // Adjusted loop bounds
    {
        for (int minute = 0; minute < 60; minute += 30) // Time slots every 30 minutes
        {
            TimeSpan timeSlot = new TimeSpan(hour, minute, 0);

            // Display time slot
            Console.Write($"│{timeSlot.ToString("hh':'mm"),-7}");

            // Display room reservation for each day
            for (int dayIndex = 0; dayIndex < numDays; dayIndex++)
            {
                var reservation = schedule[dayIndex, hour - 9];
                if (reservation != null && reservation.Time == timeSlot)
                {
                    if (reservation.Room != null && reservation.Room.RoomName != null)
                    {
                        Console.Write($"│{reservation.Room.RoomName.PadRight(dayWidths[dayIndex])}");
                    }
                    else
                    {
                        // Handle the case where reservation.Room or reservation.Room.RoomName is null
                        Console.Write($"│{(new string(' ', dayWidths[dayIndex]))}");
                    }
                }
                else
                {
                    Console.Write($"│{(new string(' ', dayWidths[dayIndex]))}");
                }
            }
            Console.WriteLine("│");
        }
    }

    // Print table footer
    Console.Write("└" + new string('─', timeWidth) + "┴"); // Adjusted for the bottom-left corner
    foreach (var dayWidth in dayWidths)
    {
        Console.Write(new string('─', dayWidth) + "┴"); // Day columns
    }
    Console.WriteLine();
}
}
