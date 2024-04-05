using System;
using System.IO;
using System.Text.Json;

public class FileLogger : ILogger
{
    private readonly string filePath;

    public FileLogger(string filePath)
    {
        this.filePath = filePath;
    }

    public  void Log(LogRecord log)
    {
        string jsonString = JsonSerializer.Serialize(log);

        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(jsonString);
        }

        Console.WriteLine("Log record logged successfully.");
    }
}
