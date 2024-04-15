namespace Ceng382_23_24_s_201812031
{
    public class FileLogger : ILogger
    {
        private FileHandler _fileHandler;
        private string _fileName="LogData.json";

        public FileLogger(FileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public LoggerType LoggerType => LoggerType.FileLogger;

        public void Log(LogRecord log)
        {
            _fileHandler.AppendFile(_fileName, log);
        }
    }
}
