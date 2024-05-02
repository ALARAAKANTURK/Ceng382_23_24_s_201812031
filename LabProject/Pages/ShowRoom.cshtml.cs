using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class ShowRoomModel : PageModel
    {
        
        [BindProperty]
     public ShowRoomModel ShowRoom { get; set; } = default!;
     private readonly AppDbContext show_contex  =new(new DbContextOptions<AppDbContext>()); 
     
        public void OnGet()
        {
        }
    }
}
