using CloneIntime.Models.DTO;

namespace CloneIntime.Services.Interfaces
{
    public interface IDisciplineService
    {
        Task<List<DirectionDTO>> GetDisciplines(string groupId);
    }
}
