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

        [HttpGet("group/{id}")]
        public async Task<WeekDTO> GetGroupsSchedule(string id)
        {
            return await _scheduleService.GetGroupsSchedule(id);
        }

        [HttpGet("auditory/{id}")]
        public async Task<WeekDTO> GetAuditorySchedule(string id)
        {
            return await _scheduleService.GetAuditorySchedule(id);
        }

        [HttpGet("teacher/{id}")]
        public async Task<WeekDTO> GetTecherSchedule(string id)
        {
            return await _scheduleService.GetTecherSchedule(id);
        }
    }
}
