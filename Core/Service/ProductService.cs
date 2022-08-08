using DataBase.Repository.Implementation;
using DataBase.Repository.Interface;
using DataBase.Entities;
using System.Collections.Generic;

namespace Core.Service
{
    public class ProductService
    {
        private IProductRepository _repository;
        private string _nameTable;

        public string NameTable => _nameTable ??= _repository.NameTable;
        public ProductService(IProductRepository pr)
        {
            _repository = pr;
        }

        public void Create(Product item)
        {
            _repository.Create(item);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public Product GetObject(int id)
        {
            return _repository.GetObject(id);
        }

        public IEnumerable<Product> GetObjectList()
        {
            return _repository.GetObjectList();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Product item)
        {
            _repository.Update(item);
            _repository.Save();
        }
    }
}
