using CloneIntime.Entities;
using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Repository;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CloneIntime.Services
{
    public class GroupService : IGroupService
    {
        private readonly Context _context;
        public GroupService(Context context)
        {
            _context = context;
        }

        private List<GroupDTO> FillGroups(IQueryable<GroupEntity> groups)
        {
            var result = new List<GroupDTO>();
            result.AddRange(groups.Select(group => new GroupDTO
            {
                Name = group.Name,
                Number = group.Number,
            }));

            return result;
        }

        public async Task<List<GroupDTO>> GetGroups(string directionId) // Получить группы на определенном направлении
        {
            var groupEntity = _context.GroupEntities.Include(x => x.Direction.Id)
                .Where(j => j.Direction.Id.ToString() == directionId);

            if (groupEntity == null)
                return new List<GroupDTO>(); //прописать исключение


            return FillGroups(groupEntity); 
        }
    }
}
