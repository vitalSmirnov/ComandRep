﻿using CloneIntime.Entities;
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
        public async Task<WeekDTO> GetGroupsSchedule(string number, DateTime startDate, DateTime endDate)
        {
            return await _scheduleService.GetGroupsSchedule(number, startDate, endDate);
        }

        [HttpGet("auditory/{id}")]
        public async Task<List<DayEntity>> GetAuditorySchedule(string id, DateTime day)
        {
            return await _scheduleService.GetAuditorySchedule(id, day);
        }

        [HttpGet("teacher/{id}")]
        public async Task<WeekDTO> GetTecherSchedule(string id, WeekDateDTO model)
        {
            return await _scheduleService.GetTecherSchedule(id, model);
        }
    }
}
