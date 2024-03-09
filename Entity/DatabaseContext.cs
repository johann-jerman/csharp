using Microsoft.EntityFrameworkCore;

namespace Entity
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext(DbContextOptions<DatabaseContext> dbContextOptions): base(dbContextOptions) 
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Categorys> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}