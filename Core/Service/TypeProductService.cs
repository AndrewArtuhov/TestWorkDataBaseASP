using DataBase.Repository.Implementation;
using DataBase.Repository.Interface;
using DataBase.Entities;
using System.Collections.Generic;

namespace Core.Service
{
    public class TypeProductService
    {
        private ITypeProductRepository _repository;
        private string _nameTable;

        public string NameTable => _nameTable ??= _repository.NameTable;
        public TypeProductService(ITypeProductRepository pr)
        {
            _repository = pr;
        }

        public void Create(TypeProduct item)
        {
            _repository.Create(item);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public TypeProduct GetObject(int id)
        {
            return _repository.GetObject(id);
        }

        public IEnumerable<TypeProduct> GetObjectList()
        {
            return _repository.GetObjectList();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(TypeProduct item)
        {
            _repository.Update(item);
            _repository.Save();
        }
    }
}
