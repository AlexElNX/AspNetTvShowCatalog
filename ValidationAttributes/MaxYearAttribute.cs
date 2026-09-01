using System.ComponentModel.DataAnnotations;

namespace TVShowCatalog.ValidationAttributes
{
    public class PastOrPresentDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            if (value is DateOnly date)
            {
                return date <= DateOnly.FromDateTime(DateTime.Now) && date.Year >= 1946;
            }
            return true;
        }
    }
}