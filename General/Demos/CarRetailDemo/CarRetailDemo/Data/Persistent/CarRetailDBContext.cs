using Microsoft.EntityFrameworkCore;
using MVVMStarterDemoA.Data.Domain;

namespace CarRetailDemo.Data.Persistent
{
    /// <summary>
    /// This class defines an Entity Framework DbContext class, 
    /// which connects to an SQL Server database running on Azure.
    /// </summary>
    public class CarRetailDBContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Sale> Sale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:perldbserver.database.windows.net,1433;
                                            Initial Catalog=CarRetailDBAzure;
                                            Persist Security Info=False;
                                            User ID=perl;
                                            Password=111!!!aaa;
                                            MultipleActiveResultSets=False;
                                            Encrypt=True;
                                            TrustServerCertificate=False;
                                            Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>().Ignore(item => item.Key);
            modelBuilder.Entity<Customer>().Ignore(item => item.Key);
            modelBuilder.Entity<Employee>().Ignore(item => item.Key);
            modelBuilder.Entity<Sale>().Ignore(item => item.Key);
        }
    }
}