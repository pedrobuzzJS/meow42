using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace meow42_api.Extensions;

public static class EntityExtensions
{
    public static bool HasMappedProperty(this EntityEntry entry, string propertyName)
    {
        return entry.Entity.GetType().GetProperty(propertyName) != null;
    }
}