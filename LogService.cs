using System;
using System.Collections.Generic;
using System.Linq;

namespace Ceng382_23_24_s_201812031
{
    public class LogService
    {
        public static List<LogRecord> DisplayLogsByName(string name)
        {
            // Read logs from JSON file
            var fileHandler = new FileHandler();
            var logs = fileHandler.ReadFile<List<LogRecord>>("LogData.json") ?? new List<LogRecord>();

            // Filter logs by username
            var logsByName = logs.Where(log => log.ReserverName == name).ToList();
            return logsByName;
        }

        public static List<LogRecord> DisplayLogs(DateTime start, DateTime end)
        {
            // Read logs from JSON file
            var fileHandler = new FileHandler();
            var logs = fileHandler.ReadFile<List<LogRecord>>("LogData.json") ?? new List<LogRecord>();

            // Filter logs by timestamp range
            var logsBetween = logs.Where(log => log.Timestamp >= start && log.Timestamp <= end).ToList();
            return logsBetween;
        }
    }
}
