
using CloneIntime.Entities;
using Microsoft.EntityFrameworkCore;

namespace CloneIntime.Repository
{
    public class InTimeContext: DbContext
    {
        public DbSet<AdminEntity> Admins { get; set; }
        public DbSet<AuditoryEntity> Auditories { get; set; }
        public DbSet<DirectionEntity> Directions { get; set; }
        public DbSet<DisciplineEntity> Disciplines { get; set; }
        public DbSet<FacultyEntity> Faculties { get; set; }
        public DbSet<GroupEntity> Groups { get; set; }
        public DbSet<PairEntity> Pairs { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }
        public DbSet<TimeSlotEntity> TimeSlots { get; set; }
        
        public InTimeContext(DbContextOptions<InTimeContext> options): base(options)
        {
        }
        
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
