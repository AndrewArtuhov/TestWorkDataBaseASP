using DataBase.Repository.Implementation;
using DataBase.Repository.Interface;
using DataBase.Entities;
using System.Collections.Generic;

namespace Core.Service
{
    public class PriceService
    {
        private IPriceRepository _repository;
        private string _nameTable;

        public string NameTable => _nameTable ??= _repository.NameTable;
        public PriceService(IPriceRepository pr)
        {
            _repository = pr;
        }

        public void Create(Price item)
        {
            _repository.Create(item);
            _repository.Save();
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
            _repository.Save();
        }

        public Price GetObject(int id)
        {
            return _repository.GetObject(id);
        }

        public IEnumerable<Price> GetObjectList()
        {
            return _repository.GetObjectList();
        }

        public void Save()
        {
            _repository.Save();
        }

        public void Update(Price item)
        {
            _repository.Update(item);
            _repository.Save();
        }

    }
}
