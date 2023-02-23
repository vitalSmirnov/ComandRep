using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CloneIntime.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("group/{groupId}")]
        public async Task<WeekDTO> GetGroupsSchedule([FromQuery] string groupId)
        {
            return await _scheduleService.GetGroupsSchedule(groupId);
        }

        [HttpGet("auditory/{auditoryId}")]
        public async Task<WeekDTO> GetAuditorySchedule([FromQuery] string audId)
        {
            return await _scheduleService.GetAuditorySchedule(audId);
        }

        [HttpGet("teacher/{teacherId}")]
        public async Task<WeekDTO> GetTecherSchedule([FromQuery] string teacherId)
        {
            return await _scheduleService.GetTecherSchedule(teacherId);
        }
    }
}
