namespace AzureCarRetailDBWebService
{
    using System.Data.Entity;

    public partial class CarRetailDBContext : DbContext
    {
        public CarRetailDBContext()
            : base("name=CarRetailDBContext")
        {
            base.Configuration.LazyLoadingEnabled = false;
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .Property(e => e.LicensePlate)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .Property(e => e.Brand)
                .IsFixedLength();

            modelBuilder.Entity<Car>()
                .Property(e => e.Model)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.FullName)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Address)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.City)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Email)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.FullName)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsFixedLength();
        }
    }
}
