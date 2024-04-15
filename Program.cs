using Microsoft.Extensions.DependencyInjection;
namespace Ceng382_23_24_s_201812031
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var serviceProvider = ConfigureServices(new ServiceCollection()).BuildServiceProvider(); ;

            var logger = serviceProvider.GetService<ILogger>();
            //logger.Log("Starting application");
            var reservationService = serviceProvider.GetService<IReservationService>();
            var reservationHandler = serviceProvider.GetService<ReservationHandler>();
            var rooms = reservationHandler.GetRooms();


            if (rooms?.Count > 0)
            {
                // Add dummy reservations

                var oldReservation = new Reservation(
                    "John Doe",
                    rooms.LastOrDefault(),
                    DateTime.Today.AddDays(1), // Tomorrow
                    DateTime.Today.AddDays(1).AddHours(14) // 10:00 AM
                );

                reservationHandler.AddReservation(oldReservation, "John Doe");

                reservationHandler.DeleteReservation(oldReservation);

                reservationHandler.AddReservation(new Reservation(
                    "John Doe",
                    rooms.FirstOrDefault(),
                    DateTime.Today.AddDays(1), // Tomorrow
                    DateTime.Today.AddDays(1).AddHours(10) // 10:00 AM
                ), "John Doe");

                reservationHandler.AddReservation(new Reservation(
                    "Jane Smith",
                    rooms.LastOrDefault(),
                    DateTime.Today.AddDays(2), // Tomorrow
                    DateTime.Today.AddDays(2).AddHours(14) // 14:00 AM
                ), "Jane Smith");

                // Display schedule
                reservationService.DisplayWeeklySchedule();
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
