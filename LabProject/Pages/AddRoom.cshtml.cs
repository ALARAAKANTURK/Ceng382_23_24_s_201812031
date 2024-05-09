using LabProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MyApp.Namespace
{
    [Authorize]

    public class AddRoomModel : PageModel
    {
        [BindProperty]
        public Room Room { get; set; }
        // public AddRoomModel AddNewRoom { get; set; } = default!;
        RoomService roomService;
        public AddRoomModel(WebAppDataBaseContext context)
        {
            this.roomService = new RoomService(context);
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Room == null)
            {
                return Page();
            }
            roomService.AddRoom(Room);
            return RedirectToAction("Get");
        }
        public void OnGet()
        {
        }
    }
}
