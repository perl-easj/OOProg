using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameDBApp
{
    public partial class GameDBContext : DbContext
    {
        public GameDBContext()
        {
        }

        public GameDBContext(DbContextOptions<GameDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Jewel> Jewels { get; set; }
        public virtual DbSet<JewelCutQuality> JewelCutQualities { get; set; }
        public virtual DbSet<JewelModel> JewelModels { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponJewelMatch> WeaponJewelMatches { get; set; }
        public virtual DbSet<WeaponModel> WeaponModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GameDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("Character");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasMaxLength(50);

                entity.Property(e => e.HealthPoints).HasColumnName("health_points");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Race)
                    .IsRequired()
                    .HasColumnName("race")
                    .HasMaxLength(50);

                entity.Property(e => e.WeaponLeft).HasColumnName("weapon_left");

                entity.Property(e => e.WeaponRight).HasColumnName("weapon_right");

                entity.HasOne(d => d.WeaponLeftNavigation)
                    .WithMany(p => p.CharacterWeaponLeftNavigations)
                    .HasForeignKey(d => d.WeaponLeft)
                    .HasConstraintName("FK_WeaponLeft");

                entity.HasOne(d => d.WeaponRightNavigation)
                    .WithMany(p => p.CharacterWeaponRightNavigations)
                    .HasForeignKey(d => d.WeaponRight)
                    .HasConstraintName("FK_WeaponRight");
            });

            modelBuilder.Entity<Jewel>(entity =>
            {
                entity.ToTable("Jewel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CutQuality)
                    .HasColumnName("cut_quality")
                    .HasMaxLength(50);

                entity.Property(e => e.JewelModelId).HasColumnName("jewel_model_id");

                entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

                entity.HasOne(d => d.CutQualityNavigation)
                    .WithMany(p => p.Jewels)
                    .HasForeignKey(d => d.CutQuality)
                    .HasConstraintName("FK_CutQuality");

                entity.HasOne(d => d.JewelModel)
                    .WithMany(p => p.Jewels)
                    .HasForeignKey(d => d.JewelModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JewelModel");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.Jewels)
                    .HasForeignKey(d => d.WeaponId)
                    .HasConstraintName("FK_Weapon");
            });

            modelBuilder.Entity<JewelCutQuality>(entity =>
            {
                entity.HasKey(e => e.CutQuality);

                entity.ToTable("JewelCutQuality");

                entity.Property(e => e.CutQuality)
                    .HasColumnName("cut_quality")
                    .HasMaxLength(50)
                    .ValueGeneratedNever();

                entity.Property(e => e.Factor).HasColumnName("factor");
            });

            modelBuilder.Entity<JewelModel>(entity =>
            {
                entity.ToTable("JewelModel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedDamage).HasColumnName("added_damage");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rarity)
                    .IsRequired()
                    .HasColumnName("rarity")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.ToTable("Weapon");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.WeaponModelId).HasColumnName("weapon_model_id");

                entity.HasOne(d => d.WeaponModel)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponModel");
            });

            modelBuilder.Entity<WeaponJewelMatch>(entity =>
            {
                entity.HasKey(e => new { e.WeaponModelId, e.JewelModelId });

                entity.ToTable("WeaponJewelMatch");

                entity.Property(e => e.WeaponModelId).HasColumnName("weapon_model_id");

                entity.Property(e => e.JewelModelId).HasColumnName("jewel_model_id");

                entity.Property(e => e.MatchFactor).HasColumnName("match_factor");

                entity.HasOne(d => d.JewelModel)
                    .WithMany(p => p.WeaponJewelMatches)
                    .HasForeignKey(d => d.JewelModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JewelModelMatch");

                entity.HasOne(d => d.WeaponModel)
                    .WithMany(p => p.WeaponJewelMatches)
                    .HasForeignKey(d => d.WeaponModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponModelMatch");
            });

            modelBuilder.Entity<WeaponModel>(entity =>
            {
                entity.ToTable("WeaponModel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.ItemLevel).HasColumnName("item_level");

                entity.Property(e => e.JewelSockets).HasColumnName("jewel_sockets");

                entity.Property(e => e.MaxDamage).HasColumnName("max_damage");

                entity.Property(e => e.MinDamage).HasColumnName("min_damage");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Rarity)
                    .IsRequired()
                    .HasColumnName("rarity")
                    .HasMaxLength(50);

                entity.Property(e => e.TwoHanded).HasColumnName("two_handed");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasColumnName("type")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
