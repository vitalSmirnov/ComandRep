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

        private List<DisciplineDTO> FillDisciplines(IQueryable<DisciplineEntity> disciplines, string groupId)
        {
            var result = new List<DisciplineDTO>();

            foreach (var disc in disciplines)
            {
                foreach (var group in disc.Groups)
                {
                    if (group.Number == groupId)
                    {
                        result.Add(new DisciplineDTO
                        {
                            Number = group.Number
                        });
                        break;
                    }
                }
            }
            return result;
        }
        public async Task<List<DisciplineDTO>> GetDisciplines(string groupId)
        {
            var disciplineEntity = _context.DisciplineEntities.Include(x => x.Groups);

            if (disciplineEntity == null)
                return new List<DisciplineDTO>();


            return FillDisciplines(disciplineEntity, groupId);

        }
    }
}
