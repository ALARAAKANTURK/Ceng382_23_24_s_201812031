using Microsoft.Extensions.DependencyInjection;
namespace ReservationApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, FileLogger>()
                .AddSingleton<IReservationRepository, ReservationRepository>()
                .AddSingleton<IReservationService, ReservationService>()
                .AddSingleton<LogHandler>()
                .AddSingleton<RoomHandler>()
                .AddSingleton<ReservationHandler>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger>();
            //logger.Log("Starting application");
            var reservationService = serviceProvider.GetService<IReservationService>();
            var reservationHandler = serviceProvider.GetService<ReservationHandler>();
            var rooms = reservationHandler.GetRooms();


            if (rooms?.Count > 0)
            {
                // Add dummy reservations
                reservationHandler.AddReservation(new Reservation(
                    "John Doe",
                    rooms.FirstOrDefault(),
                    DateTime.Today.AddDays(1), // Tomorrow
                    DateTime.Today.AddHours(10) // 10:00 AM
                ));

                reservationHandler.AddReservation(new Reservation(
                    "Jane Smith",
                    rooms.FirstOrDefault(),
                    DateTime.Today.AddDays(2), // Tomorrow
                    DateTime.Today.AddHours(14) // 14:00 AM
                ));

                // Display schedule
                reservationService.DisplayWeeklySchedule();
            }
            else
            {
                Console.WriteLine("No room data found.");
            }
        }
    }
}
