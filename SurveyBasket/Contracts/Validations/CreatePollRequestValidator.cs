

namespace SurveyBasket.Contracts.Validations
{
    public class CreatePollRequestValidator : AbstractValidator<CreatePollRequest>
    {
        public CreatePollRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                //.WithMessage("Please Add Correct {PropertyName}")
                .Length(3, 100);
            //.WithMessage("Title Shoud be least {MinLength} and maxamim {MaxLength} in Interval [{PropertyValue}]");
           
            RuleFor(x => x.Description)
                       .NotEmpty()
                       .Length(3, 1000);



        }
    }
}
