using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloneIntime.Models.DTO;

namespace CloneIntime.Controllers
{
    [Route("api/groups")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(IGroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("{disciplineId}")]
        public async Task<List<GroupDTO>> GetGroups(string disciplineId)
        {
            return await _groupService.GetGroups(disciplineId);
            
        }

    }

}
