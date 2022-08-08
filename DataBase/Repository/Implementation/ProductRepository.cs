using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DataBase.DBContext;
using DataBase.Entities;
using DataBase.Repository.Interface;
using System.Linq;

namespace DataBase.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {
        private DbModel _db;
        private string _nameTable;

        public string NameTable 
        {
            get { return _nameTable ??= GetName(); }
            set { } 
        }  

        public ProductRepository(DbModel db)
        {
            this._db = db;
        }

        private string GetName()
        {
            var table = new Product();
            return table.GetType().Name;
        }

        public void Create(Product item)
        {
            _db.Products.Add(item);
        }

        public void Delete(int id)
        {
            Product product = _db.Products.Find(id);
            if (product != null)
                _db.Products.Remove(product);
        }

        public Product GetObject(int id)
        {
            return _db.Products.Find(id);
        }

        public IEnumerable<Product> GetObjectList()
        {
            _db.Prices.Load();
            _db.TypeProducts.Load();
            return _db.Products;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Product item)
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
