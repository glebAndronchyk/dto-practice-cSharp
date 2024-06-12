using System;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.Json;

namespace lb4;

public static class JSON
{
    public static void StringifyToFile<T>(string path, List<T> obj)
    {
        var serializedString = JsonSerializer.Serialize(obj);
        File.WriteAllText(path, serializedString);
    }

    public static List<T>? ParseFromFile<T>(string path)
    {
        if (File.Exists(path) && new FileInfo(path).Length != 0)
        {
            var jsonString = File.ReadAllText(path);
            var deserializedList = JsonSerializer.Deserialize<List<T>>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (deserializedList == null)
            {
                throw new Exception("Deserialization failed.");
            }

            return ValidateList(deserializedList);
        }

        return default;
    }
    
    
    private static List<T> ValidateList<T>(List<T> list)
    {
        var validationResults = new List<ValidationResult>();

        return list.Where(item =>
        {
            var validationContext = new ValidationContext(item);
            bool isValid = Validator.TryValidateObject(item, validationContext, validationResults, true);

            if (!isValid)
            {
                foreach (var result in validationResults)
                {
                    Console.WriteLine(result.ErrorMessage);
                }
            }

            return isValid;
        }).ToList();
    }
}