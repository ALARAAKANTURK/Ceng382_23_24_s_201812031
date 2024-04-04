using System;

public record LogRecord
{
   private string? ReserverName { get; set; }

   private string? RoomName { get; set; }

   private DateTime Timestamp { get; set; }

   public LogRecord(string? reserverName, string? roomName, DateTime timestamp)
    {
        ReserverName = reserverName;
        RoomName = roomName;
        Timestamp = timestamp;
    }
     public string? GetReserverName() => ReserverName;
    public string? GetRoomName() => RoomName;
    public DateTime GetTimestamp() => Timestamp;
}