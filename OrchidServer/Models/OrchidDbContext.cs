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
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC077BCC5DDF");
        });

        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appeals__3214EC07E72F949B");

            entity.HasOne(d => d.User).WithMany(p => p.Appeals).HasConstraintName("FK__Appeals__UserId__59C55456");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC0786D5FFE4");

            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithMany(p => p.Characters).HasConstraintName("FK__Character__UserI__29572725");
        });

        modelBuilder.Entity<CharacterStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC07A8FBA575");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.CharacterStat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Character_St__Id__2D27B809");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Class__3214EC070C08C1A0");

            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.Character).WithMany(p => p.Classes).HasConstraintName("FK__Class__Character__32E0915F");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC07B748A38E");

            entity.Property(e => e.Likes).HasDefaultValue(0);

            entity.HasOne(d => d.Post).WithMany(p => p.Comments).HasConstraintName("FK__Comments__PostId__55F4C372");

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasConstraintName("FK__Comments__UserId__55009F39");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3214EC0779A421F3");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Equipment)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Equipments__Id__40F9A68C");
        });

        modelBuilder.Entity<Feat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feats__3214EC07E936BF10");

            entity.Property(e => e.LevelTaken).HasDefaultValue(1);

            entity.HasOne(d => d.Character).WithMany(p => p.Feats).HasConstraintName("FK__Feats__Character__36B12243");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forums__3214EC074AED4BEF");
        });

        modelBuilder.Entity<PartieUser>(entity =>
        {
            entity.HasOne(d => d.Party).WithMany().HasConstraintName("FK__Partie_Us__Party__4A8310C6");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__Partie_Us__UserI__498EEC8D");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parties__3214EC07529CB1D1");

            entity.HasOne(d => d.Dm).WithMany(p => p.Parties).HasConstraintName("FK__Parties__DmId__47A6A41B");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC0727B10179");

            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.Pviews).HasDefaultValue(0);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts).HasConstraintName("FK__Posts__Forum__503BEA1C");

            entity.HasOne(d => d.User).WithMany(p => p.Posts).HasConstraintName("FK__Posts__UserId__4F47C5E3");
        });

        modelBuilder.Entity<ProficienciesArmor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07728C48BD");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesArmor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__3587F3E0");
        });

        modelBuilder.Entity<ProficienciesLanguage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC07A3813848");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesLanguage)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__571DF1D5");
        });

        modelBuilder.Entity<ProficienciesSafe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC073619D8D6");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesSafe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__3A81B327");
        });

        modelBuilder.Entity<ProficienciesSkill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC074E8D07A0");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesSkill)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__4316F928");
        });

        modelBuilder.Entity<ProficienciesTool>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC070D0C142F");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesTool)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__6B24EA82");
        });

        modelBuilder.Entity<ProficienciesWeapon>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Proficie__3214EC0706EFE1D0");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.ProficienciesWeapon)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Proficiencie__Id__0D7A0286");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Race__3214EC07FC249830");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Race)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Race__Id__300424B4");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spells__3214EC0758237832");

            entity.HasOne(d => d.Character).WithMany(p => p.Spells).HasConstraintName("FK__Spells__Characte__3D2915A8");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
