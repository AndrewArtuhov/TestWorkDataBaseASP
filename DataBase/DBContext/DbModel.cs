using Microsoft.EntityFrameworkCore;
using DataBase.Entities;

namespace DataBase.DBContext
{
    public class DbModel : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<TypeProduct> TypeProducts { get; set; }
        public DbSet<Price> Prices { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        public DbModel(DbContextOptions<DbModel> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string adminRoleName = "Admin";
            string userRoleName = "User";

            // добавляем роли
            Role adminRole = new Role { Id = 1, Name = adminRoleName };
            Role userRole = new Role { Id = 2, Name = userRoleName };

            modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
            base.OnModelCreating(modelBuilder);
        }
    }
}
