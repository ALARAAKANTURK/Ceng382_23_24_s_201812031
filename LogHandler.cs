using System;

public class LogHandler
{
    private readonly ILogger logger;

    public LogHandler(ILogger logger)
    {
        this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void AddLog(LogRecord log)
    {
        if (log == null)
        {
            throw new ArgumentNullException(nameof(log));
        }

        // Log the record using the provided ILogger instance
        logger.Log(log);
    }
}
