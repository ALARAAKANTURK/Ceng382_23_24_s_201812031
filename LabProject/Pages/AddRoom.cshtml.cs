using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace MyApp.Namespace
{
    public class AddRoomModel : PageModel
    {
        [BindProperty] 
    public Room Room { get; set; }
    // public AddRoomModel AddNewRoom { get; set; } = default!;
     private readonly AppDbContext addNew_contex =new(new DbContextOptions<AppDbContext>()); 
    
      public IActionResult OnPost()
        {
            if (!ModelState.IsValid || Room == null)
            {
                return Page();
            }
            addNew_contex.Add(Room);
            addNew_contex.SaveChanges();
            return RedirectToAction("Get");
        }
        public void OnGet()
        {
        }
    }
}
