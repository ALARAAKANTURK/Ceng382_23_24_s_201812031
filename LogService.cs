using System;
using System.Collections.Generic;
using System.Linq;

namespace Ceng382_23_24_s_201812031
{
    public class LogService
    {
        private List<Log> _logs;

        public LogService(List<Log> logs)
        {
            _logs = logs;
        }

        public List<Log> DisplayLogsByName(string name)
        {
            List<Log> logs = _logs.Where(log => log.UserName == name).ToList();
            return logs;
        }

        public List<Log> DisplayLogs(DateTime start, DateTime end)
        {
            List<Log> logs = _logs.Where(log => log.Timestamp >= start && log.Timestamp <= end).ToList();
            return logs;
        }
    }
}
