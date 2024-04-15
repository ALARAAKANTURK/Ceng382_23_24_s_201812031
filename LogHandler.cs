namespace Ceng382_23_24_s_201812031
{
    public class LogHandler
    {
        private ILogger? _logger;

        public LogHandler(ILogger logger)
        {
            _logger = logger;
        }

        public void AddLog(LogRecord log)
        {
            _logger?.Log(log);
        }
    }
}