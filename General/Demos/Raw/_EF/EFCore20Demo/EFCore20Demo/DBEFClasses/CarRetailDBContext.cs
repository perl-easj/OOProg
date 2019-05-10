using EFCore20Demo.DomainClasses;
using Microsoft.EntityFrameworkCore;

namespace EFCore20Demo.DBEFClasses
{
    public class CarRetailDBContext : DbContext
    {
        public DbSet<CarClass> Car { get; set; }
        public DbSet<CustomerClass> Customer { get; set; }
        public DbSet<EmployeeClass> Employee { get; set; }
        public DbSet<SaleClass> Sale { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=tcp:perldbserver.database.windows.net,1433;" +
                "Initial Catalog=CarRetailDBAzure;" +
                "Persist Security Info=False;" +
                "User ID=perl;" +
                "Password=Th1sIsN0tTh9R9alP4ssw0rd;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;");
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Data Source=EASJ3291\SQLEXPRESS;
        //                                    Initial Catalog=CarRetailDBOnLocal;
        //                                    Integrated Security=True;
        //                                    Connect Timeout=30;
        //                                    Encrypt=False;
        //                                    TrustServerCertificate=True;
        //                                    ApplicationIntent=ReadWrite;
        //                                    MultiSubnetFailover=False");
        //}
    }
}