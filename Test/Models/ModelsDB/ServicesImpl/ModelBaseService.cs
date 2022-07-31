using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Models.ModelsDB.Context;

namespace Test.Models.ModelsDB.ServicesImpl
{
    public class ModelBaseService
    {
        private DbModel _db;
        public ModelBaseService()
        {
            this._db = new DbModel();           
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
