using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LabProject.Models;
using System.Collections.Generic;

namespace MyApp.Namespace
{
    public class ShowReservationsModel : PageModel
    {
        private readonly RoomService _roomService;
        public List<Reservation> Reservations { get; set; }

        public ShowReservationsModel(RoomService roomService)
        {
            _roomService = roomService;
        }

        public void OnGet()
        {
            Reservations = _roomService.GetReservations();
        }
    }
}
