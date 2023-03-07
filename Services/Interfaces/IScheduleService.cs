using CloneIntime.Entities;
using CloneIntime.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<WeekDTO> GetGroupsSchedule(string groupId, DateTime startDate, DateTime endDate);
        Task<List<DayEntity>> GetAuditorySchedule(string audId, DateTime day);
        Task<WeekDTO> GetTecherSchedule(string teacherId, WeekDateDTO model);
    }
}
