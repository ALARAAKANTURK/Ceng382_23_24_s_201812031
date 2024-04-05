using System;
using System.Text.Json.Serialization;
public record Reservation
{ 
    
    [JsonPropertyName("reserverName")]
     public string? ReserverName { get; set; }
     
    [JsonPropertyName("room")]
    public Room? Room { get; set; }
    
    [JsonPropertyName("date")]
    public DateTime Date{ get; set; }
    
    [JsonPropertyName("time")]
    public TimeSpan Time { get; set; }

    

    public Reservation()
    {
        // Initialize non-nullable properties with default values
        Date = DateTime.MinValue;
        Time = TimeSpan.Zero;
    }
}