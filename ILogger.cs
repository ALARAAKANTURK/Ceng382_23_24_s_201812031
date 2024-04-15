namespace Ceng382_23_24_s_201812031
{
    public interface ILogger
    {
        LoggerType LoggerType { get; }
        void Log(LogRecord log);
    }
}