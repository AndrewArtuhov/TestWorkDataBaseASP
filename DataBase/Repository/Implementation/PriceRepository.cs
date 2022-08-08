using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using DataBase.DBContext;
using DataBase.Entities;
using DataBase.Repository.Interface;

namespace DataBase.Repository.Implementation
{
    public class PriceRepository : IPriceRepository
    {
        private DbModel _db;
        private string _nameTable;

        public string NameTable
        {
            get { return _nameTable ??= GetName(); }
            set { }
        }
        public PriceRepository(DbModel db)
        {
            this._db = db;
        }

        public string GetName()
        {
            var table = new Price();
            return table.GetType().Name;
        }

        public void Create(Price item)
        {
            _db.Prices.Add(item);
        }

        public void Delete(int id)
        {
            Price price = _db.Prices.Find(id);
            if (price != null)
                _db.Prices.Remove(price);
        }

        public Price GetObject(int id)
        {
            return _db.Prices.Find(id);
        }

        public IEnumerable<Price> GetObjectList()
        {
            return _db.Prices;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Price item)
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
