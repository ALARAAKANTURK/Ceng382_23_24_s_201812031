
namespace ReservationApp
{
    public class Reservation
    {
        public string? ReserverName { get;}
        public Room? Room { get;}
        public DateTime Date { get; }
        public DateTime Time { get; }

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