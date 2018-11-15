using Microsoft.EntityFrameworkCore;

namespace SimpleRPGDemo.Data.Persistent
{
    public partial class SimpleRPGDBContext : DbContext
    {
        public SimpleRPGDBContext()
        {
        }

        public SimpleRPGDBContext(DbContextOptions<SimpleRPGDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<CharacterConfig> CharacterConfigs { get; set; }
        public virtual DbSet<Jewel> Jewels { get; set; }
        public virtual DbSet<JewelCutQuality> JewelCutQualities { get; set; }
        public virtual DbSet<JewelModel> JewelModels { get; set; }
        public virtual DbSet<RarityTier> RarityTiers { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponJewelMatch> WeaponJewelMatches { get; set; }
        public virtual DbSet<WeaponModel> WeaponModels { get; set; }
        public virtual DbSet<WeaponType> WeaponTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=perldbserver.database.windows.net;Initial Catalog=CarRetailDBAzure;Persist Security Info=True;User ID=perl;Password=111!!!aaa");
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

                entity.Property(e => e.HealthPoints).HasColumnName("health_points");

                entity.Property(e => e.Level).HasColumnName("level");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<CharacterConfig>(entity =>
            {
                entity.ToTable("CharacterConfig");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterId).HasColumnName("character_id");

                entity.Property(e => e.WeaponIdLeft).HasColumnName("weapon_id_left");

                entity.Property(e => e.WeaponIdRight).HasColumnName("weapon_id_right");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.CharacterConfigs)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CharacterConfigCharacter");

                entity.HasOne(d => d.WeaponIdLeftNavigation)
                    .WithMany(p => p.CharacterConfigWeaponIdLeftNavigations)
                    .HasForeignKey(d => d.WeaponIdLeft)
                    .HasConstraintName("FK_CharacterConfigWeaponLeft");

                entity.HasOne(d => d.WeaponIdRightNavigation)
                    .WithMany(p => p.CharacterConfigWeaponIdRightNavigations)
                    .HasForeignKey(d => d.WeaponIdRight)
                    .HasConstraintName("FK_CharacterConfigWeaponRight");
            });

            modelBuilder.Entity<Jewel>(entity =>
            {
                entity.ToTable("Jewel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CutQualityId).HasColumnName("cut_quality_id");

                entity.Property(e => e.JewelModelId).HasColumnName("jewel_model_id");

                entity.Property(e => e.WeaponId).HasColumnName("weapon_id");

                entity.HasOne(d => d.CutQuality)
                    .WithMany(p => p.Jewels)
                    .HasForeignKey(d => d.CutQualityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JewelJewelCutQuality");

                entity.HasOne(d => d.JewelModel)
                    .WithMany(p => p.Jewels)
                    .HasForeignKey(d => d.JewelModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JewelJewelModel");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.Jewels)
                    .HasForeignKey(d => d.WeaponId)
                    .HasConstraintName("FK_JewelWeapon");
            });

            modelBuilder.Entity<JewelCutQuality>(entity =>
            {
                entity.ToTable("JewelCutQuality");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Factor).HasColumnName("factor");
            });

            modelBuilder.Entity<JewelModel>(entity =>
            {
                entity.ToTable("JewelModel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.BaseDamage).HasColumnName("base_damage");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.RarityTierId).HasColumnName("rarity_tier_id");

                entity.HasOne(d => d.RarityTier)
                    .WithMany(p => p.JewelModels)
                    .HasForeignKey(d => d.RarityTierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JewelModelRarityTier");
            });

            modelBuilder.Entity<RarityTier>(entity =>
            {
                entity.ToTable("RarityTier");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.ToTable("Weapon");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CharacterId).HasColumnName("character_id");

                entity.Property(e => e.WeaponModelId).HasColumnName("weapon_model_id");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.CharacterId)
                    .HasConstraintName("FK_WeaponCharacter");

                entity.HasOne(d => d.WeaponModel)
                    .WithMany(p => p.Weapons)
                    .HasForeignKey(d => d.WeaponModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponWeaponModel");
            });

            modelBuilder.Entity<WeaponJewelMatch>(entity =>
            {
                entity.ToTable("WeaponJewelMatch");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Factor).HasColumnName("factor");

                entity.Property(e => e.JewelModelId).HasColumnName("jewel_model_id");

                entity.Property(e => e.WeaponModelId).HasColumnName("weapon_model_id");

                entity.HasOne(d => d.JewelModel)
                    .WithMany(p => p.WeaponJewelMatches)
                    .HasForeignKey(d => d.JewelModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponJewelMatchJewelModel");

                entity.HasOne(d => d.WeaponModel)
                    .WithMany(p => p.WeaponJewelMatches)
                    .HasForeignKey(d => d.WeaponModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponJewelMatchWeaponModel");
            });

            modelBuilder.Entity<WeaponModel>(entity =>
            {
                entity.ToTable("WeaponModel");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.JewelSockets).HasColumnName("jewel_sockets");

                entity.Property(e => e.MaxDamage).HasColumnName("max_damage");

                entity.Property(e => e.MinDamage).HasColumnName("min_damage");

                entity.Property(e => e.RarityTierId).HasColumnName("rarity_tier_id");

                entity.Property(e => e.WeaponTypeId).HasColumnName("weapon_type_id");

                entity.HasOne(d => d.RarityTier)
                    .WithMany(p => p.WeaponModels)
                    .HasForeignKey(d => d.RarityTierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponModelRarityTier");

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.WeaponModels)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_WeaponModelWeaponType");
            });

            modelBuilder.Entity<WeaponType>(entity =>
            {
                entity.ToTable("WeaponType");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.HandsRequired).HasColumnName("hands_required");
            });

            // Code from the OnModelCreating method
            // in the CarRetailDBAzureContext class.
            modelBuilder.Entity<Character>().Ignore(item => item.Key);
            modelBuilder.Entity<CharacterConfig>().Ignore(item => item.Key);
            modelBuilder.Entity<Jewel>().Ignore(item => item.Key);
            modelBuilder.Entity<JewelCutQuality>().Ignore(item => item.Key);
            modelBuilder.Entity<JewelModel>().Ignore(item => item.Key);
            modelBuilder.Entity<RarityTier>().Ignore(item => item.Key);
            modelBuilder.Entity<Weapon>().Ignore(item => item.Key);
            modelBuilder.Entity<WeaponJewelMatch>().Ignore(item => item.Key);
            modelBuilder.Entity<WeaponModel>().Ignore(item => item.Key);
            modelBuilder.Entity<WeaponType>().Ignore(item => item.Key);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
