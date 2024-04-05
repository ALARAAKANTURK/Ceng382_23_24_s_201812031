using System;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

public record Room
{
    [JsonPropertyName("roomId")]
    public string? RoomId { get; set; }

    [JsonPropertyName("roomName")]
    public string? RoomName { get; set; }

    [JsonPropertyName("capacity")]
    public string? Capacity { get; set; }

    
    public Room(string? roomId, string? roomName, string? capacity)
    {
        RoomId = roomId;
        RoomName = roomName;
        Capacity = capacity;
    }
    public Room()
    {
        
    }

   
}
