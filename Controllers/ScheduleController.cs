using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloneIntime.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        [HttpGet("group/{groupId}")]
        public async Task GetGroupsSchedule([FromQuery] string groupId)
        {
        
        }

        [HttpGet("auditory/{auditoryId}")]
        public async Task Get([FromQuery] string AudId)
        {
            
        }

        [HttpGet("teacher/{teacherId}")]
        public async Task Post([FromQuery] string teacherId)
        {

        }
    }
}
