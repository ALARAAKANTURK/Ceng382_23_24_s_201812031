using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabProject.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System;
using Microsoft.AspNetCore.Authorization;

namespace MyApp.Namespace
{
     [Authorize]
    public class ReservationsModel : PageModel
    {

        [BindProperty]
          
        public Reservation Reservation { get; set; }
         RoomService roomService;
           public List<Room> Rooms { get; set; }

       public ReservationsModel(WebAppDataBaseContext context)
        {
            this.roomService = new RoomService(context);
        }
      
         public IActionResult OnPost()
        {
            
            roomService.AddReservation(Reservation);
            return RedirectToAction("Get");
        }
        

        public void OnGet()
        {
            Rooms = roomService.GetRooms();
        }


        }
  }

