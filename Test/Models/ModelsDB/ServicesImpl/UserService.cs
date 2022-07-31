using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.ModelsDB.Context;
using Test.Models.ModelsDB.Entities;
using Test.Models.ModelsDB.Services;

namespace Test.Models.ModelsDB.ServicesImpl
{
    public class UserService : IUser
    {
        private DbModel _db;
        private string _nameTable;

        public string NameTable
        {
            get { return _nameTable ??= GetName(); }
            set { }
        }

        private string GetName()
        {
            var table = new User();
            return table.GetType().Name;
        }

        public UserService()
        {
            this._db = new DbModel();
        }

        public void Create(User item)
        {
            _db.Users.Add(item);
        }

        public void Delete(int id)
        {
            User user = _db.Users.Find(id);
            if (user != null)
                _db.Users.Remove(user);
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
        public IQueryable<User> GetObjectListAsyn()
        {
            _db.Roles.Load(); ;
            return _db.Users;
        }

        public User GetObject(int id)
        {
            return _db.Users.Find(id);
        }

        public IEnumerable<User> GetObjectList()
        {
            _db.Roles.Load();
            return _db.Users;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(User item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
