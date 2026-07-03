using System.Text.Json;

namespace meow42_api.Extensions;

public static class ObjectExtensions
{
    public static string ToJson(this Object obj)
    {
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true,
        };
        
        return JsonSerializer.Serialize(obj, options);
    }
}