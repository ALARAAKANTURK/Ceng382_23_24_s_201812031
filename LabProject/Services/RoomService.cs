using MyApp.Namespace;

public class RoomService
{
    private readonly AppDbContext addNew_contex;
    private readonly AppDbContext show_contex;
    public RoomService(AppDbContext context)
    {
        this.addNew_contex = context;
        this.show_contex = context;
    }

    public void AddRoom(Room room)
    {
        addNew_contex.Add(room);
        addNew_contex.SaveChanges();
    }




}