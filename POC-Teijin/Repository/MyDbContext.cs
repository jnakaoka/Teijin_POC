using Microsoft.EntityFrameworkCore;
using Npgsql;
namespace POC_Teijin.Repository
{
    

    public class MyDbContext : DbContext
    {
        public DbSet<Sensores> Sensores { get; set; }

        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Sensores>().ToTable("Sensores");
        //    modelBuilder.Entity<Sensores>().HasKey(s => s.Id);
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ModelConfig());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<MyDbContext>();
            optionsBuilder.UseNpgsql("Host=my_host;Database=Teijin_POC;Username=postgres;Password=admin_123");

            var options = dbContextOptionsBuilder.Options;
        }
    }
}
