using CloneIntime.Entities;
using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloneIntime.Services
{
    public class ProfessorsService : IProfessorsService
    {
        private readonly Context _context;
        public ProfessorsService(Context context)
        {
            _context = context;
        }

        private List<ProffessorDTO> FillProfessors(IQueryable<TeacherEntity> teachers)
        {
            var result = new List<ProffessorDTO>();
            result.AddRange(teachers.Select(professor => new ProffessorDTO
            {
                Name = professor.Name,
                Email = professor.Email,
            }));

            return result;
        }

        public async Task<List<ProffessorDTO>> GetProfessors() // Получить группы на определенном направлении
        {
            var professorsEntities = _context.TeachersEntities.Where(x => x.IsActive);

            if (professorsEntities == null)
                return new List<ProffessorDTO>(); //прописать исключение


            return FillProfessors(professorsEntities);
        }

        public async Task<List<ProffessorDTO>> GetProfessors(string disciplineId) // Получить группы на определенном направлении
        {
            var professorsEntities = _context.TeachersEntities.Where(x => x.IsActive && x.Disciplines.Any(d => d.Id.ToString() == disciplineId));


            if (professorsEntities == null)
                return new List<ProffessorDTO>(); //прописать исключение


            return FillProfessors(professorsEntities);
        }
    }
}
