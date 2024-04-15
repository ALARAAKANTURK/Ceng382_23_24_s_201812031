namespace Ceng382_23_24_s_201812031
{
    public record LogRecord
    {
        public DateTime Timestamp { get; init; }
        public string ReserverName { get; init; }
        public string RoomName { get; init; }
        public LogRecord(DateTime timeStamp, string reserverName, string roomName)
        {
            Timestamp = timeStamp;
            ReserverName = reserverName;
            RoomName = roomName;
        }
    }
}