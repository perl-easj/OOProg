using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreHotel
{
    public partial class HotelDBContext : DbContext
    {
        public HotelDBContext()
        {
        }

        public HotelDBContext(DbContextOptions<HotelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<Guest> Guests { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HotelDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.DateFrom)
                    .HasColumnName("date_from")
                    .HasColumnType("date");

                entity.Property(e => e.DateTo)
                    .HasColumnName("date_to")
                    .HasColumnType("date");

                entity.Property(e => e.GuestNo).HasColumnName("guest_no");

                entity.Property(e => e.HotelNo).HasColumnName("hotel_no");

                entity.Property(e => e.RoomNo).HasColumnName("room_no");

                entity.HasOne(d => d.GuestNoNavigation)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.GuestNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__guest_n__1AD3FDA4");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => new { d.RoomNo, d.HotelNo })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__1BC821DD");
            });

            modelBuilder.Entity<Guest>(entity =>
            {
                entity.HasKey(e => e.GuestNo);

                entity.ToTable("Guest");

                entity.Property(e => e.GuestNo)
                    .HasColumnName("guest_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.HasKey(e => e.HotelNo);

                entity.ToTable("Hotel");

                entity.Property(e => e.HotelNo)
                    .HasColumnName("hotel_no")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => new { e.RoomNo, e.HotelNo });

                entity.ToTable("Room");

                entity.Property(e => e.RoomNo).HasColumnName("room_no");

                entity.Property(e => e.HotelNo).HasColumnName("hotel_no");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Types)
                    .HasColumnName("types")
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('S')");

                entity.HasOne(d => d.HotelNoNavigation)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.HotelNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Room__hotel_no__160F4887");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
