using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property) ]
    public class MinAgeAttribute(int minAge) : ValidationAttribute
    {
        private readonly int _minAge = minAge;
        // DateOfBirth  == Attribute of DataAnnotation in this Class (=======validationContext=====)
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not null) 
            {
                // Validation data input 
                var data = (DateTime)value;
                if(DateTime.Today < data.AddYears(_minAge))
                {
                    return new ValidationResult($"invalid {validationContext.DisplayName},Age should be {_minAge} years old.");
                }

            }
            return ValidationResult.Success;

        }
    }
}
