using System;
using System.Collections.Generic;

namespace LabProject.Models;

public partial class Reservation
{
    public int Id { get; set; }

    public string ReserverName { get; set; } = null!;

    public int RoomId { get; set; }

    public DateTime ReservationDate { get; set; }

    public virtual Room Room { get; set; } = null!;
}
