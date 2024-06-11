using System.Globalization;
using System.Windows.Controls;

namespace lb4.Validations;

public class StudentNameValidation : ValidationRule
{
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
        string valueToValidate = value as string;
        if (valueToValidate.Length < 6 || valueToValidate.Length > 10)
        {
            return new ValidationResult(false, "Name should be between range 3-50");
        }

        return new ValidationResult(true, null);
    }
}