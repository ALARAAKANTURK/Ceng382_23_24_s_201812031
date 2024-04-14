namespace ReservationApp
{
    public class LogHandler
    {
        private readonly ILogger? _logger;
        private readonly RoomHandler roomHandler;

        public LogHandler(ILogger logger, RoomHandler roomHandler)
        {
            _logger = logger;
            this.roomHandler = roomHandler;
        }

        public void AddLog(LogRecord log)
        {
            _logger?.Log(log);
        }
    }
}