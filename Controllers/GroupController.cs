using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using CloneIntime.Services;
using CloneIntime.Entities;

namespace CloneIntime.Controllers
{
    [ApiController]
    [Route("api/groups")]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService _groupService;

        public GroupController(GroupService groupService)
        {
            _groupService = groupService;
        }

        [HttpGet("{directionId}")]
        public async Task<List<GroupDTO>> GetGroups(string directionId)
        {
            return await _groupService.GetGroups(directionId);
        }

    }

}
