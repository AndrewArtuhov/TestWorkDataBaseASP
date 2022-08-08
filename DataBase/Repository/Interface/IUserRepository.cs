using DataBase.Entities;
using System.Linq;

namespace DataBase.Repository.Interface
{
    public interface IUserRepository : IRepository<User>
    {
        public IQueryable<User> GetUserList();
    }
}
