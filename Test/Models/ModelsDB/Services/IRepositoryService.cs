using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models.ModelsDB.Services
{
    public interface IRepositoryService<T> : IDisposable
    {
        public string NameTable { get; set; }
        public void Create(T item); // создание объекта
        public IEnumerable<T> GetObjectList(); // достать все объекты из бд
        public T GetObject(int id); // чтение объекта
        public void Update(T item); // обновление объекта
        public void Delete(int id); // удаление объекта по id
        public void Save(); // сохранение изменений
    }
}
