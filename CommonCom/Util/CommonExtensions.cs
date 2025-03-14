using System;
using System.ComponentModel;
using System.Reflection;

namespace CommonCom.Util;

public static class EnumExtensions
{
    // DescriptionAttribute format: "name|description"
    public static string GetName<T>(this T value) where T : Enum
    {
        FieldInfo field = value.GetType().GetField(value.ToString());

        if (field != null)
        {
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute != null)
            {
                // Split the description into name and description parts
                string[] parts = attribute.Description.Split(new[] { '|' }, 2);
                return parts[0];  // Part before '|' is considered the name
            }
        }

        // Return an empty string if there's no description
        return string.Empty;
    }
    public static string GetDescription<T>(this T value) where T : Enum
    {
        FieldInfo field = value.GetType().GetField(value.ToString());

        if (field != null)
        {
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

            if (attribute != null)
            {
                // Split the description only at the first occurrence of '|'
                string[] parts = attribute.Description.Split(new[] { '|' }, 2);
                if (parts.Length > 1)
                {
                    return parts[1];  // Part after '|' is considered the description
                }
            }
        }

        // Return an empty string if there's no description
        return string.Empty;
    }
}


public static class StringExtensions
{
	/// A stable (consistent) hash code for a specific string
    public static int GetStableHashCode(this string str)
    {
        // Taken from https://stackoverflow.com/a/36845864
        unchecked {
            int hash1 = 5381;
            int hash2 = hash1;

            for (int i = 0; i < str.Length && str[i] != '\0'; i += 2) {
                hash1 = ((hash1 << 5) + hash1) ^ str[i];
                if (i == str.Length - 1 || str[i+1] == '\0') {
                    break;
                }
                hash2 = ((hash2 << 5) + hash2) ^ str[i+1];
            }

            return hash1 + (hash2*1566083941);
        }
    }
}