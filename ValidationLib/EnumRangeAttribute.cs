using System.ComponentModel.DataAnnotations;

namespace ValidationLib;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public class EnumRangeAttribute : ValidationAttribute
{
    public Type EnumType { get; }

    public EnumRangeAttribute(Type enumType)
    {
        if (!enumType.IsEnum)
        {
            throw new ArgumentException($"{enumType.Name} is not an enum type.");
        }
        EnumType = enumType;
    }

    public override bool IsValid(object value)
    {
        if (value == null)
        {
            return true;
        }

        if (Enum.TryParse(EnumType, value.ToString(), out object parsedValue))
        {
            return Enum.IsDefined(EnumType, parsedValue);
        }

        return false;
    }
}