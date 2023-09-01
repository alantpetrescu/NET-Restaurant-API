using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class ManagerRepository : GenericRepository<Manager>
    {
        public ManagerRepository(AppDBContext context) : base(context)
        {
        }
        public Manager Get(Guid Id)
        {
            return _table.First(x => x.Id == Id);
        }

    }
}
