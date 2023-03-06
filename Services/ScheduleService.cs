using CloneIntime.Entities;
using CloneIntime.Models;
using CloneIntime.Models.DTO;
using CloneIntime.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace CloneIntime.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly Context _context;
        public ScheduleService(Context context)
        {
            _context = context;
        }

        private static List<GroupDTO> fillGroups(List<GroupEntity> pairs)
        {
            var groups = new List<GroupDTO>();
            groups.AddRange(pairs.Select(x => new GroupDTO
            {
                Name = x.Name,
                Number = x.Number,
            }));
            return groups;
        }

        private static List<PairDTO> fillPairs(List<PairEntity> pair)
        {
            var result = new List<PairDTO>();
            result.AddRange(pair.Select(j => new PairDTO
            {
                LessonType = j.LessonType,
                Audiroty = j.Auditory.Number,
                Discipline = j.Discipline.Name,
                Groups = fillGroups(j.Group),
                Proffessor = j.Teacher.Name
            }));
            return result;
        }

        private static List<TimeSlotDTO> TimeSlotFilling(List<TimeSlotEntity> timeslot)
        {
            var TimeSlots = new List<TimeSlotDTO>();
            TimeSlots.AddRange(timeslot.Select(j => new TimeSlotDTO
            {
                Pairs = fillPairs(j.Pair),

            }));
            return TimeSlots;
        }
        private WeekDTO FillGroupSchedule(List<DayEntity> days)
        { 
            var result = new List<DayDTO>();
            result.AddRange(days.Select(x => new DayDTO
            {
                Day = x.Date.ToString(),
                Timeslot = TimeSlotFilling(x.Lessons),
                WeekDay = 0,
            }));
            return new WeekDTO
            {
                Days = result
            };
        }

        public async Task<WeekDTO> GetGroupsSchedule(string groupNumber, WeekDateDTO model)
        {
            var groupScheduleEntity = await _context.DayEntities
                .Include(k => k.Group)
                .Include(x => x.Lessons)
                .ThenInclude(j => j.Pair)
                .Where(l => l.Group.Number == groupNumber && (l.Date >= model.StartDate && l.Date <= model.EndDate) && l.IsActive)
                .ToListAsync();

             var result =  FillGroupSchedule(groupScheduleEntity);

            return result;
        }
        public async Task<WeekDTO> GetAuditorySchedule(string audId, WeekDateDTO model)
        {
            return new WeekDTO(); //заглушка
        }

        public async Task<WeekDTO> GetTecherSchedule(string teacherId, WeekDateDTO model)
        {
            return new WeekDTO(); //заглушка
        }
    }
}
