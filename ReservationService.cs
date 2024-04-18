using System;
using System.Collections.Generic;
using System.Linq;

namespace Ceng382_23_24_s_201812031
{
    public class ReservationService : IReservationService
    {
        private ReservationHandler _reservationHandler;

        public ReservationService(ReservationHandler reservationHandler)
        {
            _reservationHandler = reservationHandler;
        }

        public void AddReservation(Reservation reservation, string reserverName)
        {
            _reservationHandler.AddReservation(reservation, reserverName);
        }

        public void DeleteReservation(Reservation reservation)
        {
            _reservationHandler.DeleteReservation(reservation);
        }

        public void DisplayWeeklySchedule()
        {

            var reservations = _reservationHandler.GetAllReservations().OrderBy(x => x.Date).ThenBy(x => x.Time);
            if (reservations.Count() > 0)
            {
                var first = reservations.FirstOrDefault();
                var last = reservations.LastOrDefault();
                var d = ((int)first.Date.DayOfWeek) - 1; //ilk rezervasyon tarihi 
                var date = first.Date.AddDays(-1 * d);//Geriye gitme
                var dayCount = Math.Ceiling((last?.Date - first?.Date)?.TotalDays ?? 0) + d;

                Console.WriteLine("This week's schedule:");

                // Display schedule header

                for (int dayIndex = 0; dayIndex <= dayCount + 1; dayIndex++)
                {
                    Console.Write("+------------");
                }
                Console.WriteLine("+");

                // Display day names
                Console.Write("| Time       ");
                for (int dayIndex = 0; dayIndex <= dayCount; dayIndex++)
                {
                    var day = date.AddDays(dayIndex);

                    Console.Write($"|  {day.DayOfWeek,-10}");
                }
                Console.WriteLine("|");


                for (int dayIndex = 0; dayIndex <= dayCount + 1; dayIndex++)
                {
                    Console.Write("+------------");
                }
                Console.WriteLine("+");

                // Display schedule by time slots
                for (int hour = 9; hour <= 17; hour++) // Assuming time slots from 9:00 AM to 5:00 PM
                {
                    for (int minute = 0; minute < 60; minute += 30) // Time slots every 30 minutes
                    {
                        DateTime timeSlot = date.AddHours(hour).AddMinutes(minute);

                        for (int dayIndex = 0; dayIndex <= dayCount + 1; dayIndex++)
                        {
                            Console.Write("+------------");
                        }
                        Console.WriteLine("+");

                        // Display time slot
                        Console.Write($"|{timeSlot.ToString("HH':'mm"),-11}");

                        // Display room reservation for each day
                        for (int dayIndex = 0; dayIndex <= dayCount; dayIndex++)
                        {
                            var rdate = date.AddDays(dayIndex);
                            var reservation = reservations.FirstOrDefault(x => x.Date == rdate && x.Time.Hour == timeSlot.Hour && x.Time.Minute == timeSlot.Minute);

                            if (reservation != null)
                            {
                                string roomName = reservation.Room?.Name ?? string.Empty;
                                Console.Write($" |   {roomName,-8}");
                            }
                            else
                            {
                                Console.Write(" |           "); // Empty cell
                            }
                        }
                        Console.WriteLine(" |");
                    }
                }
                for (int dayIndex = 0; dayIndex <= dayCount + 1; dayIndex++)
                {
                    Console.Write("+------------");
                }
                Console.WriteLine("+");
            }

        }
        public static List<Reservation> DisplayReservationByReserver(string name)
        {
            // Read reservations from JSON file
            var fileHandler = new FileHandler();
            var reservations = fileHandler.ReadFile<List<Reservation>>("ReservationData.json") ?? new List<Reservation>();

            // Filter reservations by reserver name
            var reservationsByReserver = reservations.Where(r => r.ReserverName == name).ToList();
            return reservationsByReserver;
        }
        public static List<Reservation> DisplayReservationByRoomId(string roomId)
        {
            // Read reservations from JSON file
            var fileHandler = new FileHandler();
            var reservations = fileHandler.ReadFile<List<Reservation>>("ReservationData.json") ?? new List<Reservation>();

            // Filter reservations by room ID
            var reservationsByRoomId = reservations.Where(r => r.Room?.Id == roomId).ToList();
            return reservationsByRoomId;
        }
   }


}

