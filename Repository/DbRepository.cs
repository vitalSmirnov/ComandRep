using System.Linq.Expressions;
using CloneIntime.Entities;

namespace CloneIntime.Repository
{
    // Реализация этого класса используется для работы с БД
    public interface IDbRepository
    {
        // Эти методы предназначены для сохранения одной сущности и листа из сущностей в БД
        Task Save<T>(T entity) where T : BaseEntity;
        Task SaveAll<T>(IEnumerable<T> entities) where T : BaseEntity;
        
        // Эти методы - для поиска функции-селектору, которые передается, как параметр и также находит только записи, где IsActive == true
        IQueryable<T> FindBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity;
        IQueryable<T> FindActiveBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity;
        
        // Эти - для поиска вообще всех записей и всех записей, где IsActive == true
        IQueryable<T> FindAll<T>() where T : BaseEntity;
        IQueryable<T> FindAllActive<T>() where T : BaseEntity;

        // Эти - для обновления сущности и листа из сущностей в БД
        Task Update<T>(T entity) where T : BaseEntity;
        Task UpdateAll<T>(IEnumerable<T> entity) where T : BaseEntity;

        // Эти - для полного удаления сущности и сущностей по функции-селектору из БД
        Task Delete<T>(T entity) where T : BaseEntity;
        Task DeleteBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity;
        
        // Эти - для условного или добавления удаления сущности и сущностей по функции-селектору в БД, путем смены флажка IsActive 
        Task ChangeActivity<T>(T entity) where T : BaseEntity;
        Task ChangeActivityBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity;

        // Тоже самое, что выше, но для списка
        Task ChangeAllActivity<T>(IEnumerable<T> entity) where T : BaseEntity;
        
        // Метод, который нужен, чтобы принять все изменения
        Task<int> SaveChangesAsync();
    }
    
    public class DbRepository : IDbRepository
    {
        private readonly InTimeContext _context;

        public DbRepository(InTimeContext context)
        {
            _context = context;
        }
        
        public async Task Save<T>(T entity) where T : BaseEntity
        {
            await _context.Set<T>().AddAsync(entity);
        }
        public async Task SaveAll<T>(IEnumerable<T> entities) where T : BaseEntity
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }
        
        public IQueryable<T> FindBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity
        {
            return _context.Set<T>().Where(selector)
                    .AsQueryable();
        }
        public IQueryable<T> FindActiveBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity
        {
            return _context.Set<T>().Where(selector).Where(x => x.IsActive)
                    .AsQueryable();
        }
        
        public IQueryable<T> FindAll<T>() where T : BaseEntity
        {
            return _context.Set<T>()
                    .AsQueryable();
        }
        public IQueryable<T> FindAllActive<T>() where T : BaseEntity
        {
            return _context.Set<T>().Where(x => x.IsActive)
                    .AsQueryable();
        }
        
        public async Task Update<T>(T entity) where T : BaseEntity
        {
            entity = _UpdateDate(entity);
            await Task.Run(() => 
                _context.Set<T>().Update(entity));
        }
        public async Task UpdateAll<T>(IEnumerable<T> entity) where T : BaseEntity
        {
            entity = entity.Select(_UpdateDate);
            await Task.Run(() => 
                _context.Set<T>().UpdateRange(entity));
        }

        public async Task ChangeActivity<T>(T entity) where T : BaseEntity
        {
            var entities = FindBy<T>(it => it.Id == entity.Id);
            await UpdateAll(entities.AsEnumerable().Select(_ChangeActivity).ToList());
        }
        public async Task ChangeActivityBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity
        {
            var entities = FindBy(selector);
            await UpdateAll(entities.AsEnumerable().Select(_ChangeActivity).ToList());
        }
        
        public async Task ChangeAllActivity<T>(IEnumerable<T> entity) where T : BaseEntity
        {
            await UpdateAll(entity.AsEnumerable().Select(_ChangeActivity).ToList());
        }

        public async Task Delete<T>(T entity) where T : BaseEntity
        {
            var entities = FindBy<T>(it => it.Id == entity.Id);
            await Task.Run(() => _context.Set<T>().RemoveRange(entities));
        }
        public async Task DeleteBy<T>(Expression<Func<T, bool>> selector) where T : BaseEntity
        {
            var entities = FindBy(selector);
            await Task.Run(() => _context.Set<T>().RemoveRange(entities));
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        private static T _ChangeActivity<T>(T entity) where T : BaseEntity
        {
            entity.IsActive = !entity.IsActive;
            return entity;
        }

        private static T _UpdateDate<T>(T entity) where T : BaseEntity
        {
            entity.DateUpdated = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.ms", System.Globalization.CultureInfo.InvariantCulture);
            return entity;
        }
    }
}
