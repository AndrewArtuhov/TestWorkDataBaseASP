using Microsoft.EntityFrameworkCore;
using Test.Models.ModelsDB.Entities;

namespace Test.Models.ModelsDB.Context
{
    public class DbModel : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Products.db");
        }
    }
}
