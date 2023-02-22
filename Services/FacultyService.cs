using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Repository;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloneIntime.Services
{
    public class FacultyService : IFacultyService
    {
        private readonly Context _context;

        public FacultyService(Context context)
        {
            _context = context;
        }

        public async Task<List<FacultyDTO>> GetFaculties()
        {
            var facultyEntities = await _context
                .FacultyEntities
                .ToListAsync(); // ToList() не надо делать при запросе из бд, это перегружает сервер

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
