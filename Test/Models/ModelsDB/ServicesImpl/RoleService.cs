using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Test.Models.ModelsDB.Context;
using Test.Models.ModelsDB.Entities;
using Test.Models.ModelsDB.Services;

namespace Test.Models.ModelsDB.ServicesImpl
{
    public class RoleService : IRole
    {
        private DbModel _db;
        private string _nameTable;

        public string NameTable
        {
            get { return _nameTable ??= GetName(); }
            set { }
        }

        public RoleService()
        {
            this._db = new DbModel();
        }

        private string GetName()
        {
            var table = new Role();
            return table.GetType().Name;
        }

        public void Create(Role item)
        {
            _db.Roles.Add(item);
        }

        public void Delete(int id)
        {
            Role role = _db.Roles.Find(id);
            if (role != null)
                _db.Roles.Remove(role);
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

        public Role GetObject(int id)
        {
            return _db.Roles.Find(id);
        }

        public IEnumerable<Role> GetObjectList()
        {
            return _db.Roles;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Role item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}
