using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Test.Models.ModelsDB.Context;
using Test.Models.ModelsDB.Entities;
using Test.Models.ModelsDB.Services;

namespace Test.Models.ModelsDB.ServicesImpl
{
    public class TypeService : ITypeProduct
    {
        private DbModel _db;
        private string _nameTable;

        public string NameTable
        {
            get { return _nameTable ??= GetName(); }
            set { }
        }
        public TypeService()
        {
            this._db = new DbModel();
        }

        public string GetName()
        {
            var table = new TypeProduct();
            return table.GetType().Name;
        }

        public void Create(TypeProduct item)
        {
            _db.TypeProducts.Add(item);
        }

        public void Delete(int id)
        {
            TypeProduct typeProduct = _db.TypeProducts.Find(id);
            if (typeProduct != null)
                _db.TypeProducts.Remove(typeProduct);
        }

        public TypeProduct GetObject(int id)
        {
            return _db.TypeProducts.Find(id);
        }

        public IEnumerable<TypeProduct> GetObjectList()
        {
            return _db.TypeProducts;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(TypeProduct item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
