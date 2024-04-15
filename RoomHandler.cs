using System.Text.Json;

namespace Ceng382_23_24_s_201812031
{
    public class RoomHandler
    {
        private FileHandler _fileHandler;
        private string _filePath= "Data.json";

        public RoomHandler(FileHandler fileHandler)
        {
            _fileHandler = fileHandler;
        }

        public List<Room> GetRooms()
        {
            var roomData = _fileHandler.ReadFile<RoomData>(_filePath);
            return roomData?.Rooms?.ToList() ?? new List<Room>();
        }

        public void SaveRooms(List<Room> rooms)
        {
            _fileHandler.WriteFile<RoomData>(_filePath, new RoomData { Rooms = rooms.ToArray()});
        }
    }
}