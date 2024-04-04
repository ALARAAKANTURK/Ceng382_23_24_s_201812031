using System;

public record LogRecord
{
    public string? ReserverName { get; set; }

   string? RoomName { get; set; }

    public DateTime Timestamp { get; set; }

    public LogRecord()
    {
       
    }
}