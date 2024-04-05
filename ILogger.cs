using System;
using System.Text.Json.Serialization;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;


public class ILogger
{
    public void Log(LogRecord log)
    {
        // Your logging logic here
        Console.WriteLine($"Logging: ReserverName - {log.ReserverName}, RoomName - {log.RoomName}, Timestamp - {log.Timestamp}");
    }
}