public class Reservation
{       
    public int Id { get; set; }
    public string ReserverName { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
    public DateTime ReservationDate { get; set; }


      



}