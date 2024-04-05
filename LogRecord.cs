using System;
using System.Text.Json.Serialization;
public record LogRecord
{  
     [JsonPropertyName("reserverName")]
   public string? ReserverName { get; set; }

   [JsonPropertyName("roomName")]
   public string? RoomName { get; set; }

   [JsonPropertyName("timestamp")]
   public DateTime Timestamp { get; set; }
   
   public LogRecord(string? reserverName, string? roomName, DateTime timestamp)
    {
        ReserverName = reserverName;
        RoomName = roomName;
        Timestamp = timestamp;
    }
   
}