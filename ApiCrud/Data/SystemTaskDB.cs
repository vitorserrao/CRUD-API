using ApiCrud.Map;
using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data
{
    public class SystemTaskDB : DbContext
    {
        public SystemTaskDB(DbContextOptions <SystemTaskDB> options) : base(options)
        {
 
        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<TaskModel> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TaskMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}