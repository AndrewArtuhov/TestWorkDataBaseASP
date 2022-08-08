using DataBase.Repository.Implementation;
using DataBase.Repository.Interface;
using DataBase.Entities;
using System.Collections.Generic;

namespace Core.Service
{
    public class UserService
    {
        private IUserRepository _repository;
        private string _nameTable;

        public string NameTable => _nameTable ??= _repository.NameTable;

        public UserService(IUserRepository pr)
        {
            _repository = pr;
        }

        public void Create(User item)
        {
            _repository.Create(item);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public User GetObject(int id)
        {
            return _repository.GetObject(id);
        }

        public IEnumerable<User> GetObjectList()
        {
            return _repository.GetObjectList();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(User item)
        {
            _repository.Update(item);
            _repository.Save();
        }
    }
}
