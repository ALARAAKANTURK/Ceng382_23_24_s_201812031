namespace Ceng382_23_24_s_201812031
{
    public class LogFactory
    {
        private IEnumerable<ILogger> _loggers;

        public LogFactory(IEnumerable<ILogger> loggers)
        {
            _loggers = loggers;
        }

        public ILogger GetLogger(LoggerType loggerType)
        {
            return _loggers.FirstOrDefault(e => e.LoggerType == loggerType)
                ?? throw new NotSupportedException();
        }
    }
}
