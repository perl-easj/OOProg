namespace Client
{
    using System.Data.Entity;

    public partial class MovieDBContext : DbContext
    {
        public MovieDBContext()
            : base("name=MovieDBContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Studio> Studios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Studio>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Studio>()
                .Property(e => e.HQCity)
                .IsFixedLength();
        }
    }
}
