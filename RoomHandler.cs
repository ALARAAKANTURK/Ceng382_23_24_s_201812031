using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

public class RoomHandler
{
    private readonly string filePath;

    public RoomHandler(string filePath)
    {
        this.filePath = filePath;
    }

    public List<Room>? GetRooms()
    {
        try
        {
            string jsonString = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Room>>(jsonString);
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Room data file not found.");
        }
        catch (JsonException)
        {
            Console.WriteLine("Error deserializing room data.");
        }
        return null;
    }

    public void SaveRooms(List<Room> rooms)
    {
        try
        {
            string jsonString = JsonSerializer.Serialize(rooms, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);
        }
        catch (IOException)
        {
            Console.WriteLine("Error writing room data to file.");
        }
    }
}
