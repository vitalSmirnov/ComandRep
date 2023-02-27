using CloneIntime.Models;
using CloneIntime.Services.Interfaces;
using CloneIntime.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloneIntime.Models.DTO;

namespace CloneIntime.Controllers
{
    [Route("api/group")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _directionService;

        public GroupController(GroupService groupService)
        {
            _directionService = groupService;
        }

        [HttpGet("{directionId}")]
        public async Task<List<GroupDTO>> GetGroups(string directionId)
        {
            var groups = await _directionService.GetGroups(directionId);
            return groups;
        }

    }

}
