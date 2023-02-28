using CloneIntime.Models.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CloneIntime.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<WeekDTO> GetGroupsSchedule(string groupId);
        Task<WeekDTO> GetAuditorySchedule(string audId);
        Task<WeekDTO> GetTecherSchedule(string teacherId);
    }
}
