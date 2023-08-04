using NET_Restaurant_API.Models;
using NET_Restaurant_API.Models.Base;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public interface IDatabaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetAllWithInclude();
        Task<List<TEntity>> GetAllWithIncludeAsync();
        List<TEntity> GetAllWithJoin();
        Task<List<TEntity>> GetAllWithJoinAsync();
    }
}
