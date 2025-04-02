using System.ComponentModel.DataAnnotations;

namespace SurveyBasket.Contracts.Requests
{
    public record CreatePollRequest(
        //[Required(ErrorMessage ="mohamed sherif say you 'this Field is required'")]
        string Title,
        string Description
        );
}
  
