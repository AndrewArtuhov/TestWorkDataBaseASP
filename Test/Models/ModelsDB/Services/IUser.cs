using Test.Models.ModelsDB.Entities;
using System.Linq;

namespace Test.Models.ModelsDB.Services
{
    public interface IUser : IRepositoryService<User>
    {
        public IQueryable<User> GetObjectListAsyn();
    }
}
