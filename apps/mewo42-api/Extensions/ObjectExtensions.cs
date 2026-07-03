using System.Text.Json;

namespace preponto_api.Extensions;

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