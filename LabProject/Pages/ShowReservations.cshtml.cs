using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LabProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Namespace
{
    public class ShowReservationsModel : PageModel
    {
        private readonly RoomService _roomService;
        public List<Reservation> Reservations { get; set; }
        public List<Room> Rooms { get; set; }

        [BindProperty(SupportsGet = true)]
        public string RoomName { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public DateTime? StartDate { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public DateTime? EndDate { get; set; }
        
        [BindProperty(SupportsGet = true)]
        public int? RoomCapacity { get; set; }

        [BindProperty]
        public Reservation Reservation { get; set; }

        public ShowReservationsModel(RoomService roomService)
        {
            _roomService = roomService;
        }

        public void OnGet()
        {
            Rooms = _roomService.GetRooms();
            Reservations = _roomService.GetReservations();
            
            if (!string.IsNullOrEmpty(RoomName))
            {
                Reservations = Reservations.Where(r => r.Room.RoomName.Contains(RoomName)).ToList();
            }

            if (StartDate.HasValue && EndDate.HasValue)
            {
                Reservations = Reservations.Where(r => r.ReservationDate >= StartDate && r.ReservationDate < EndDate.Value.AddDays(1)).ToList();
            }

            if (RoomCapacity.HasValue)
            {
                Reservations = Reservations.Where(r => r.Room.Capacity >= RoomCapacity).ToList();
            }
        }

        public IActionResult OnPostDelete(int id)
        {
            _roomService.DeleteReservation(id);
            return RedirectToPage();
        }

        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                Rooms = _roomService.GetRooms();
                return Page();
            }

            _roomService.EditReservation(Reservation);
            return RedirectToPage();
        }
    }
}
