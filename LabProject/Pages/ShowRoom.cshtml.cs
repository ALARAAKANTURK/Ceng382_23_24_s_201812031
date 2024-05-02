using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace MyApp.Namespace
{
    public class ShowRoomModel : PageModel
    {



        //public ShowRoomModel ShowRoom { get; set; } = default!; 
        private readonly AppDbContext show_contex ; //readonly üzeri değiştirilemez
        
    public ShowRoomModel(AppDbContext context)
    {
        show_contex=context;
    }
        public List<Room> RoomList { get; set; } = default!;

        public void OnGet()
        {
            /*RoomList = (from item in show_contex.Rooms
                        select item).ToList();*/
                        RoomList=show_contex.Rooms.ToList<Room>();
        }


    }
}
