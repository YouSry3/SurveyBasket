




using Mapster;
using SurveyBasket.Models;

namespace SurveyBasket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PollsController(IPollService pollService) : ControllerBase
{
    private readonly IPollService _pollService = pollService;
    //private readonly IMapper _mapper = mapper;




    [HttpGet]
    public IActionResult GetAll()
    {
                var polls = _pollService.GetAll();
                var response = polls.Adapt<IEnumerable<PollResponse>>();

                return Ok(response);
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] int id)
    {
            var poll = _pollService.Get(id);
            if(poll is  null)
                return NotFound();


        // Configration mapping bettween two variable in DTO  



        var response = poll?.Adapt<PollResponse>();


        return Ok(response); 
    }
    // Prameter Binding types 
    //       - Routes ==> like Route [Route("{id}")]
    //       - Query String ==> in url /?id=2  this Q.S
    //       - Headers ==> in header request
    //       - Body => (json)



    [HttpPost("add")]
    public IActionResult Add([FromBody] CreatePollRequest request)
    {
        

                var newPoll = _pollService.Add(request.Adapt<Poll>());
        
                return CreatedAtAction(nameof(Get), new { id = newPoll.Id }, newPoll);
     }
    


    [HttpPut("{id}")]
    public IActionResult Update(int id, CreatePollRequest request) 
    {
        
        var isUpdated = _pollService.Update(id, request.Adapt<Poll>());

        if(!isUpdated )
            return NotFound();

        return NoContent();
    }
    [HttpDelete("delete/{id}")]
    public IActionResult Delete(int id) 
    {
        var isDeleted= _pollService.Delete(id);

        if (!isDeleted)
            return NotFound();

        return NoContent();
    }
   
 
}