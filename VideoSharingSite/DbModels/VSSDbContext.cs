using Microsoft.EntityFrameworkCore;

namespace VideoSharingSite.DbModels
{
    public class VSSDbContext : DbContext 
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User
            modelBuilder.Entity<User>()
           .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
             .Property(e => e.Email)
             .IsRequired();

            modelBuilder.Entity<User>()
             .Property(e => e.Firstname)
             .IsRequired();

            modelBuilder.Entity<User>()
             .Property(e => e.Lastname)
             .IsRequired();

            modelBuilder.Entity<User>()
             .Property(e => e.Password)
             .IsRequired();

            #endregion



        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=BS-1139;Database=VSS_DEV;Trusted_Connection=True;User Id=sa;Password=admin;Encrypt=True;TrustServerCertificate=True;");

            optionsBuilder.EnableDetailedErrors();
        }

        public DbSet<User> Users { get; set; }
    }
}
