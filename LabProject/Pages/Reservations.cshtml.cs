using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{
    [Authorize]
    public class ReservationsModel : PageModel
    {
        private RoomService roomService;
        public List<Room> Rooms { get; set; }

        public ReservationsModel(RoomService roomService)
        {
            this.roomService = roomService;
        }

        [BindProperty]
        public Reservation Reservation { get; set; }

      
        public IActionResult OnPost()
        {
            
           // Set the ReserverName to the current logged-in user's username
            Reservation.ReserverName = User.Identity.Name;

            roomService.AddReservation(Reservation);
            return RedirectToPage("/Index");
        }
          public void OnGet()
        {
            Rooms = roomService.GetRooms();
        }

    }
}