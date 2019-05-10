namespace EFClient01
{
    using System.Data.Entity;

    public partial class MovieContext : DbContext
    {
        public MovieContext()
            : base("name=MovieContext")
        {
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

            modelBuilder.Entity<Studio>()
                .HasMany(e => e.Movies)
                .WithRequired(e => e.Studio)
                .WillCascadeOnDelete(false);
        }
    }
}
