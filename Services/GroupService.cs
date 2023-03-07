﻿using CloneIntime.Entities;
using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

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
                Direction = new DirectionDTO
                {
                    id = group.Id,
                    Name = group.Direction.Name,
                    Number = group.Direction.Number,
                    Faculty = new FacultyDTO{
                        id = group.Direction.Faculty.Id,
                        Name = group.Direction.Faculty.Name,
                        Number = group.Direction.Faculty.Number
                    }

                }
                
            }));

            return result;
        }

        public async Task<List<GroupDTO>> GetGroups(string FacultyNumber) // Получить группы на определенном направлении
        {
            var groupEntity = _context.GroupEntities
                .Include(x => x.Direction)
                .ThenInclude(l => l.Faculty)
                .Where(j => j.Direction.Faculty.Id.ToString() == FacultyNumber && j.IsActive);

            if (groupEntity == null)
                return new List<GroupDTO>(); //прописать исключение

            return FillGroups(groupEntity);
        }
    }
}
