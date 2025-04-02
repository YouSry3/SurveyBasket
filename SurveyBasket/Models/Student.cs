using SurveyBasket.ValidationAttributes;

namespace SurveyBasket.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FristName { get; set; } = string.Empty;
        public string MiddileName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        [MinAge(19)]

        public DateTime? DateOfBirth { get; set; }


    }
}
