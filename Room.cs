using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_201812031
{
    public record Room
    {
        [JsonPropertyName("roomId")]
        public string? Id { get; init; }
        
        [JsonPropertyName("roomName")]
        public string? Name { get; init; }

        [JsonPropertyName("capacity")]
        public int Capacity { get; init; }

        public Room(string id, string name, int capacity)
        {
            Id = id;
            Name = name;
            Capacity = capacity;
        }
    }

}
