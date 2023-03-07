using CloneIntime.Entities;
using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CloneIntime.Services
{
    public class DisciplineService : IDisciplineService
    {
        private readonly Context _context;
        public DisciplineService(Context context)
        {
            _context = context;
        }

        private List<DisciplineDTO> FillDisciplines(List<GroupEntity> disciplines)
        {
            var result = new List<DisciplineDTO>();

            result.AddRange(disciplines.Select(x => new DisciplineDTO
            {
                Name = x.Name,
                Id = x.Id,
                IsActive = x.IsActive,
            }));
            return result;
        }
        public async Task<List<DisciplineDTO>> GetDisciplines(string groupId)
        {
            var disciplineEntity = await _context.GroupEntities
                .Include(x => x.Disciplines)
                .ToListAsync();

            if (disciplineEntity == null)
                return new List<DisciplineDTO>();


            return FillDisciplines(disciplineEntity);

        }
    }
}
