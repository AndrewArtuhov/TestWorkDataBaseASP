using System;
using System.Collections.Generic;
using DataBase.Entities;

namespace DataBase.Repository.Interface
{
    public interface IRepository<T> : IDisposable
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
