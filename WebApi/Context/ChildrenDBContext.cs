using Microsoft.EntityFrameworkCore;
using WebApi.Models;

namespace WebApi.Context
{
    public class ChildrenDBContext : DbContext
    {

        public DbSet<Child> Children { get; set; }
        public DbSet<Toy> Toys { get; set; }

   
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=ChildrenDB");
        }
    }
}
