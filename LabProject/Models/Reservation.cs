public class Reservation
{       
    public int Id { get; set; }
    public string ReserverName { get; set; }
    public int RoomId { get; set; } //Foreign key
    public Room Room { get; set; } //nEREYE FOREIGN KEY OLDUĞUNUN CALSSINI VERDİK
    public DateTime ReservationDate { get; set; }


      



}