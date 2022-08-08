using DataBase.Repository.Implementation;
using DataBase.Repository.Interface;
using DataBase.Entities;
using System.Collections.Generic;

namespace Core.Service
{
    public class RoleService
    {
        private IRoleRepository _repository;
        private string _nameTable;

        public string NameTable => _nameTable ??= _repository.NameTable;
        public RoleService(IRoleRepository pr)
        {
            _repository = pr;
        }

        public void Create(Role item)
        {
            _repository.Create(item);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public Role GetObject(int id)
        {
            return _repository.GetObject(id);
        }

        public IEnumerable<Role> GetObjectList()
        {
            return _repository.GetObjectList();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Role item)
        {
            _repository.Update(item);
            _repository.Save();
        }
    }
}
