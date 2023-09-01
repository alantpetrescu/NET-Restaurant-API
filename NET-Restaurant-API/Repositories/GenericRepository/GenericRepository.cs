using Microsoft.EntityFrameworkCore;
using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models.Base;
using System.Linq.Expressions;

namespace NET_Restaurant_API.Repositories.GenericRepository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly AppDBContext _context;
        protected readonly DbSet<TEntity> _table;

        public GenericRepository(AppDBContext context)
        {
            _context = context;
            _table = _context.Set<TEntity>();
        }

        //Get
        public async Task<List<TEntity>> GetAll()
        {
            return await _table.ToListAsync();
        }

        public async Task<List<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _table;

            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }

            return await query.AsNoTracking().ToListAsync();
        }

        public IQueryable<TEntity> GetAllAsQueryable()
        {
            return _table.AsNoTracking().AsQueryable();
        }

        //Create
        public void Create(TEntity entity)
        {
            Console.WriteLine("ceva aici");
            _table.Add(entity);
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _table.AddAsync(entity);
        }

        public void CreateRange(IEnumerable<TEntity> entities)
        {
            _table.AddRange(entities);
        }

        public async Task CreateRangeAsync(IEnumerable<TEntity> entities)
        {
            await _table.AddRangeAsync(entities);
        }


        //Update
        public void Update(TEntity entity)
        {
            _table.Update(entity);
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            _table.UpdateRange(entities);
        }

        //Delete
        public void Delete(TEntity entity)
        {
            _table.Remove(entity);
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _table.RemoveRange(entities);
        }

        //Find
        public TEntity FindById(object id)
        {
            return _table.Find(id);
           // return _table.FirstOrDefault(x => x.Id.Equals(id));
        }

        public async Task<TEntity> FindByIdAsync(object id)
        {
            return await _table.FindAsync(id);
           // return await _table.FirstOrDefault(x => x.Id.Equals(id));
        }

        //Save
        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
