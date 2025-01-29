using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace OrchidServer.Models;

public partial class OrchidDbContext : DbContext
{
    public OrchidDbContext()
    {
    }

    public OrchidDbContext(DbContextOptions<OrchidDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AppUser> AppUsers { get; set; }

    public virtual DbSet<Appeal> Appeals { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<CharacterStat> CharacterStats { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Feat> Feats { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<PartieUser> PartieUsers { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<ProficienciesArmor> ProficienciesArmors { get; set; }

    public virtual DbSet<ProficienciesLanguage> ProficienciesLanguages { get; set; }

    public virtual DbSet<ProficienciesSafe> ProficienciesSaves { get; set; }

    public virtual DbSet<ProficienciesSkill> ProficienciesSkills { get; set; }

    public virtual DbSet<ProficienciesTool> ProficienciesTools { get; set; }

    public virtual DbSet<ProficienciesWeapon> ProficienciesWeapons { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Spell> Spells { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=OrchidDB;User ID=OrchidAdminLogin;Password=theOrchid;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC074AF1AB91");
        });

        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appeals__3214EC07544C8180");

            entity.HasOne(d => d.User).WithMany(p => p.Appeals).HasConstraintName("FK__Appeals__UserId__56E8E7AB");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC077D73F3B8");

            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithMany(p => p.Characters).HasConstraintName("FK__Character__UserI__29572725");
        });

        modelBuilder.Entity<CharacterStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC079BCDAFE9");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CharacterStat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character_St__Id__2D27B809");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.IdNavigation).WithMany().HasConstraintName("FK__Class__Id__31EC6D26");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07DA2803F4");

            entity.Property(e => e.Likes).HasDefaultValue(0);

            entity.HasOne(d => d.Post).WithMany(p => p.Comments).HasConstraintName("FK__Comments__PostId__531856C7");

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasConstraintName("FK__Comments__UserId__5224328E");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3214EC07ECE32B3E");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Equipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipments__Id__3E1D39E1");
        });

        modelBuilder.Entity<Feat>(entity =>
        {
            entity.Property(e => e.LevelTaken).HasDefaultValue(1);

            entity.HasOne(d => d.IdNavigation).WithMany().HasConstraintName("FK__Feats__Id__34C8D9D1");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forums__3214EC071E0D5785");
        });

        modelBuilder.Entity<PartieUser>(entity =>
        {
            entity.HasOne(d => d.Party).WithMany().HasConstraintName("FK__Partie_Us__Party__47A6A41B");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__Partie_Us__UserI__46B27FE2");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parties__3214EC075E89ADF2");

            entity.HasOne(d => d.Dm).WithMany(p => p.Parties).HasConstraintName("FK__Parties__DmId__44CA3770");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC07AA4CF634");

            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.Pviews).HasDefaultValue(0);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts).HasConstraintName("FK__Posts__Forum__4D5F7D71");

            entity.HasOne(d => d.User).WithMany(p => p.Posts).HasConstraintName("FK__Posts__UserId__4C6B5938");
        });

        modelBuilder.Entity<ProficienciesArmor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC0727764021");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesArmor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__339FAB6E");
        });

        modelBuilder.Entity<ProficienciesLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07342187A5");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesLanguage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__5535A963");
        });

        modelBuilder.Entity<ProficienciesSafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07FBD94519");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesSafe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__38996AB5");
        });

        modelBuilder.Entity<ProficienciesSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC075CE21480");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__412EB0B6");
        });

        modelBuilder.Entity<ProficienciesTool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC077898B054");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesTool)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__693CA210");
        });

        modelBuilder.Entity<ProficienciesWeapon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC0787D292E1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesWeapon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__0B91BA14");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Race__3214EC0730B47B8E");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Race)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Race__Id__300424B4");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasOne(d => d.IdNavigation).WithMany().HasConstraintName("FK__Spells__Id__3A4CA8FD");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
