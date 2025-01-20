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

    public virtual DbSet<ProficienciesArmour> ProficienciesArmours { get; set; }

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
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC07059FCB89");
        });

        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appeals__3214EC071D636EB6");

            entity.HasOne(d => d.User).WithMany(p => p.Appeals).HasConstraintName("FK__Appeals__UserId__58D1301D");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC07DFFEDC34");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithMany(p => p.Characters).HasConstraintName("FK__Character__UserI__29572725");
        });

        modelBuilder.Entity<CharacterStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC071F1BB906");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CharacterStat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character_St__Id__2D27B809");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC07B9F9FF53");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Class)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Class__Id__32E0915F");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC078718A81C");

            entity.Property(e => e.Likes).HasDefaultValue(0);

            entity.HasOne(d => d.Post).WithMany(p => p.Comments).HasConstraintName("FK__Comments__PostId__55009F39");

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasConstraintName("FK__Comments__UserId__540C7B00");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3214EC0794334DE1");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Equipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipments__Id__40058253");
        });

        modelBuilder.Entity<Feat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feats__3214EC077F9AB4BF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LevelTaken).HasDefaultValue(1);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Feat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Feats__Id__36B12243");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forums__3214EC0792CB9BFB");
        });

        modelBuilder.Entity<PartieUser>(entity =>
        {
            entity.HasOne(d => d.Party).WithMany().HasConstraintName("FK__Partie_Us__Party__498EEC8D");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__Partie_Us__UserI__489AC854");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parties__3214EC07440B0104");

            entity.HasOne(d => d.Dm).WithMany(p => p.Parties).HasConstraintName("FK__Parties__DmId__46B27FE2");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC07F86B9BE4");

            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.Pviews).HasDefaultValue(0);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts).HasConstraintName("FK__Posts__Forum__4F47C5E3");

            entity.HasOne(d => d.User).WithMany(p => p.Posts).HasConstraintName("FK__Posts__UserId__4E53A1AA");
        });

        modelBuilder.Entity<ProficienciesArmour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC079CC0F4F4");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesArmour)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__3587F3E0");
        });

        modelBuilder.Entity<ProficienciesLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07EF5B5926");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesLanguage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__571DF1D5");
        });

        modelBuilder.Entity<ProficienciesSafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07D48FC3BF");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesSafe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__3A81B327");
        });

        modelBuilder.Entity<ProficienciesSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07C1DDBAF3");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__4316F928");
        });

        modelBuilder.Entity<ProficienciesTool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC072758C6C9");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesTool)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__6B24EA82");
        });

        modelBuilder.Entity<ProficienciesWeapon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07DC57699C");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesWeapon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__0D7A0286");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Race__3214EC07EF6DD511");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Race)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Race__Id__300424B4");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spells__3214EC07A074A7CA");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Spell)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Spells__Id__3C34F16F");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
