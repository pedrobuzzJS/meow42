namespace meow42_api.Extensions;

public static class StringExtension
{
    public static string Revert(this string value)
    {
        return new string(value.ToCharArray().Reverse().ToArray());
    }
    public static string SnakeToCamel(this string value)
    {
        if (string.IsNullOrEmpty(value))
            return value;

        var chars = value.Split("_");
        var result = chars[0].ToLower();
        
        for (int i = 1; i < chars.Length; i++)
        {
            result += char.ToUpper(chars[i][0]) + chars[i].Substring(1).ToLower();
        }

        return result;
    }
    public static string CamleToSnake(this string value)
    {
        if  (string.IsNullOrEmpty(value))
            return value;
        
        var result = new System.Text.StringBuilder();

        foreach (var c in value)
        {
            if (char.IsUpper(c))
            {
                result.Append('_');
                result.Append(char.ToLower(c));
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}