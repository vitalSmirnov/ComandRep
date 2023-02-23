using CloneIntime.Models.DTO;

namespace CloneIntime.Services.Interfaces
{
    public interface IProfessorsService
    {
        Task<List<ProffessorDTO>> GetTeachers();
    }
}
