using System.Text.Json.Serialization;

namespace Ceng382_23_24_s_201812031
{
    public class RoomData
    {
        [JsonPropertyName("Room")]
        public Room[] Rooms { get; set; }
    }

}
