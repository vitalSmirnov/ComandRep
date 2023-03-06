using CloneIntime.Models.DTO;

namespace CloneIntime.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<WeekDTO> GetGroupsSchedule(string groupId, WeekDateDTO model);
        Task<WeekDTO> GetAuditorySchedule(string audId, WeekDateDTO model);
        Task<WeekDTO> GetTecherSchedule(string teacherId, WeekDateDTO model);
    }
}
