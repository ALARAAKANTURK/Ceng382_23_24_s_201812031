using System.Text.Json;

namespace Ceng382_23_24_s_201812031
{
    public class FileHandler
    {
        public T ReadFile<T>(string path)
        {
            try
            {
                var jsonString = File.ReadAllText(path);

                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                };

                var data = JsonSerializer.Deserialize<T>(jsonString, options);
                return data;
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"\n{path} file not found!\n");
            }
            catch 
            {
                return default(T);
            }
            return default(T);
        }

        public void WriteFile<T>(string path, T data)
        {
            try
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                };

                var jsonString = JsonSerializer.Serialize<T>(data, options);
                File.WriteAllText(path, jsonString);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"\n{path} file not found!\n");
            }
        }

        public void AppendFile<T>(string path, T data)
        {
            try
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNameCaseInsensitive = true,
                    ReadCommentHandling = JsonCommentHandling.Skip,
                    AllowTrailingCommas = true
                };

                var jsonString = JsonSerializer.Serialize<T>(data, options);
                File.AppendAllText(path, jsonString);
                File.AppendAllText(path, "\n");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"\n{path} file not found!\n");
            }
        }
    }
}
