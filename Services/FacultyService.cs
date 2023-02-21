using CloneIntime.Models.DTO;
using CloneIntime.Repository;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloneIntime.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly InTimeContext _context;

        public FacultyService(InTimeContext context)
        {
            _context = context;
        }

        public async Task<List<FacultyDTO>> GetFaculties()
        {
            var facultyEntities = await _context
                .Faculties
                .ToListAsync();

            var faculties = 
                facultyEntities
                .Select(facultyEntity => new FacultyDTO
                {
                    Name = facultyEntity.Name,
                    Number = facultyEntity.Number
                })
                .ToList();

            return faculties;
        }
    }
}
