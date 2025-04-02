namespace SurveyBasket.Contracts.Validations
{
    public class StudentValidator : AbstractValidator<Student>
    {
        public StudentValidator()
        {
            RuleFor(x => x.DateOfBirth)
                .Must( beMorethan18)
                .When(x => x.DateOfBirth.HasValue)
                .WithMessage("{PropertyName} is inVaild,age Should be 18 years old. ");
        }
        private bool beMorethan18(DateTime? dateOfBirth)
        {
            return DateTime.Now > dateOfBirth!.Value.AddYears(18);

        }
    }
}
