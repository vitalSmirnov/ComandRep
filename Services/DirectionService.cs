using CloneIntime.Entities;
using CloneIntime.Models.DTO;
using CloneIntime.Repository;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CloneIntime.Services
{
    public class DirectionService : IDirectionService
    {
        private readonly InTimeContext _context;
        public DirectionService(InTimeContext context)
        {
            _context = context;
        }

        private List<DirectionDTO> FillGroups(IQueryable<DirectionEntity> faculty)
        {
            var result = new List<DirectionDTO>();
            result.AddRange(faculty.Select(direction => new DirectionDTO
            {
                Name = direction.Name,
                Number = direction.Number,
            }));

            return result;
        }

        public async Task<List<DirectionDTO>> GetDirections(string facultyId) // Получить группы на определенном направлении
        {
            var directionEntity = _context.Directions.Include(x => x.Faculty.Id)
                .Where(j => j.Faculty.Id.ToString() == facultyId);

            if (directionEntity == null)
                return new List<DirectionDTO>(); //прописать исключение


            return FillGroups(directionEntity);
        }
    }
}