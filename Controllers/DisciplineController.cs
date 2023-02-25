using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CloneIntime.Controllers
{
    [Route("api/discipline")]
    [ApiController]
    public class DisciplineController : ControllerBase
    {
        [HttpGet("{groupId}")]
        public Task GetDisciplines([FromQuery] string groupId)
        {
            return Task.FromResult(0);
        }
    }
}
