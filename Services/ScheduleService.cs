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

        private static PairDTO fillPairs(PairEntity pair)
        {
            return new PairDTO
            {
                LessonType = pair.LessonType,
                Audiroty = pair.Auditory.Number,
                Discipline = pair.Discipline.Name,
                Groups = fillGroups(pair.Group),
                Proffessor = pair.Teacher.Name
            };
        }

        private static List<TimeSlotDTO> TimeSlotFilling(List<TimeSlotEntity> timeslot)
        {
            var TimeSlots = new List<TimeSlotDTO>();
            TimeSlots.AddRange(timeslot.Select(j => new TimeSlotDTO
            {
                Pair = fillPairs(j.Pair),

            }));
            return TimeSlots;
        }
        private static WeekDTO FillGroupSchedule(IQueryable<DayEntity> days)
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

        public async Task<WeekDTO> GetGroupsSchedule(string groupNumber)
        {
            var groupScheduleEntity = _context.DayEntities
                .Include(k => k.Group)
                .Include(x => x.Lessons)
                .ThenInclude(j => j.Pair)
                .Where(l => l.Group.Number == groupNumber);

             return FillGroupSchedule(groupScheduleEntity);
        }
        public async Task<WeekDTO> GetAuditorySchedule(string audId)
        {
            return new WeekDTO(); //заглушка
        }

        public async Task<WeekDTO> GetTecherSchedule(string teacherId)
        {
            return new WeekDTO(); //заглушка
        }
    }
}
