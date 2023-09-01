using NET_Restaurant_API.Data;
using NET_Restaurant_API.Models;
using NET_Restaurant_API.Repositories.GenericRepository;

namespace NET_Restaurant_API.Repositories.DatabaseRepository
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(AppDBContext context) : base(context)
        {

        }

        public User Get(Guid Id)
        {
            return _table.First(x => x.Id == Id);
        }

        public User FindByEmail(string email)
        {
            return _table.FirstOrDefault(x => x.Email == email);
        }
    }
}
