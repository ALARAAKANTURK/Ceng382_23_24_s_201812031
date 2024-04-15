
namespace Ceng382_23_24_s_201812031
{
    public record Reservation
    {
        public string? ReserverName { get; init; }
        public Room? Room { get; init; }
        public DateTime Date { get; init; }
        public DateTime Time { get; init; }

        public Reservation(string? reserverName, Room? room, DateTime date, DateTime time)
        {
            ReserverName = reserverName;
            Room = room;
            Date = date;
            Time = time;
        }

        public Reservation()
        {
            Date = DateTime.MinValue;
            Time = DateTime.MinValue;
        }
    }
}