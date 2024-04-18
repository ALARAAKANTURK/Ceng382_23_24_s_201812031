using Microsoft.Extensions.DependencyInjection;
using System;

namespace Ceng382_23_24_s_201812031
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices(new ServiceCollection()).BuildServiceProvider(); ;

            // Display weekly schedule using ReservationService
            var reservationService = serviceProvider.GetService<IReservationService>();
            var reservationHandler = serviceProvider.GetService<ReservationHandler>();
            var rooms = reservationHandler?.GetRooms();

            if (rooms?.Count > 0)
            {
                // Add dummy reservations
                var oldReservation = new Reservation(
                    "John Doe",
                    rooms.LastOrDefault(),
                    DateTime.Today.AddDays(1), // Tomorrow
                    DateTime.Today.AddDays(1).AddHours(14) // 10:00 AM
                );

                reservationHandler?.AddReservation(oldReservation, "John Doe");

                reservationHandler?.DeleteReservation(oldReservation);

                reservationHandler?.AddReservation(new Reservation(
                    "John Doe",
                    rooms.FirstOrDefault(),
                    DateTime.Today.AddDays(1), // Tomorrow
                    DateTime.Today.AddDays(1).AddHours(10) // 10:00 AM
                ), "John Doe");

                reservationHandler?.AddReservation(new Reservation(
                    "Jane Smith",
                    rooms.LastOrDefault(),
                    DateTime.Today.AddDays(2), // Tomorrow
                    DateTime.Today.AddDays(2).AddHours(14) // 14:00 AM
                ), "Jane Smith");

                // Display schedule
                reservationService?.DisplayWeeklySchedule();

                // Example usage of DisplayReservationByReserver method
                var johnReservations = ReservationService.DisplayReservationByReserver("John Doe");
                Console.WriteLine("\nReservations by John Doe:");
                foreach (var reservation in johnReservations)
                {
                    Console.WriteLine($"{reservation.ReserverName} - {reservation.Date} {reservation.Time}");
                }

                // Example usage of DisplayReservationByRoomId method
                var roomReservations = ReservationService.DisplayReservationByRoomId(rooms.FirstOrDefault()?.Id);
                Console.WriteLine("\nReservations for Room 1:");
                foreach (var reservation in roomReservations)
                {
                    Console.WriteLine($"{reservation.ReserverName} - {reservation.Date} {reservation.Time}");
                }

                // Example usage of LogService methods
                var logByName = LogService.DisplayLogsByName("John Doe");
                Console.WriteLine("\nLogs for John Doe:");
                foreach (var log in logByName)
                {
                    Console.WriteLine($"{log.ReserverName} - {log.RoomName} - {log.Timestamp}");

                }

                var start = DateTime.Today.AddDays(-1);
                var end = DateTime.Today;
                var logsBetween = LogService.DisplayLogs(start, end);
                Console.WriteLine($"\nLogs between {start} and {end}:");
                foreach (var log in logsBetween)
                {
                    Console.WriteLine($"{log.ReserverName} - {log.RoomName} - {log.Timestamp}");

                }
            }
            else
            {
                Console.WriteLine("No room data found.");
            }
        }

        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ILogger, FileLogger>();
            services.AddSingleton<LogFactory>();
            services.AddSingleton<IReservationRepository, ReservationRepository>();
            services.AddSingleton<IReservationService, ReservationService>();
            services.AddSingleton<LogHandler>();
            services.AddSingleton<RoomHandler>();
            services.AddSingleton<ReservationHandler>();
            services.AddSingleton<FileHandler>();

            return services;
        }        
    }
}
