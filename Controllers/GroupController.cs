using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        [HttpGet]
        public async Task GetGroups()
        {
            
        }

    }

}
