using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using DataBase.DBContext;

namespace Test.Models.ModelsDB.ServicesImpl
{
    public class ModelBaseService
    {
        private DbModel _db;
        public ModelBaseService(DbModel db)
        {
            this._db = db;           
        }

        public List<string> GetTable()
        {
            return _db.Model.GetEntityTypes()
                .Select(t => t.ShortName())
                .Distinct()
                .ToList();
        }
    }
}
