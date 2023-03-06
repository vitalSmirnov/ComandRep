using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Services;
using CloneIntime.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Controllers
{
    [Route("api/schedule")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpGet("group/{number}")]
        public async Task<WeekDTO> GetGroupsSchedule(string number, WeekDateDTO model)
        {
            return await _scheduleService.GetGroupsSchedule(number, model);
        }

        [HttpGet("auditory/{id}")]
        public async Task<WeekDTO> GetAuditorySchedule(string id, WeekDateDTO model)
        {
            return await _scheduleService.GetAuditorySchedule(id, model);
        }

        [HttpGet("teacher/{id}")]
        public async Task<WeekDTO> GetTecherSchedule(string id, WeekDateDTO model)
        {
            return await _scheduleService.GetTecherSchedule(id, model);
        }
    }
}
