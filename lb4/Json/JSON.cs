using System.IO;
using System.Text.Json;

namespace lb4;

public static class JSON
{
    public static void StringifyToFile<T>(string path, T obj)
    {
        var serializedString = JsonSerializer.Serialize(obj);
        File.WriteAllText(path, serializedString);
    }

    public static T? ParseFromFile<T>(string path)
    {
        if (File.Exists(path) && new FileInfo(path).Length != 0)
        {
            var jsonString = File.ReadAllText(path);
            return JsonSerializer.Deserialize<T>(jsonString);
        }

        return default;
    }
}