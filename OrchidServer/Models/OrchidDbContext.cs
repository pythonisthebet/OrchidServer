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

    public virtual DbSet<BanReason> BanReasons { get; set; }

    public virtual DbSet<Character> Characters { get; set; }

    public virtual DbSet<Filter> Filters { get; set; }

    public virtual DbSet<FiltersToCharacter> FiltersToCharacters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=OrchidDB;User ID=OrchidAdminLogin;Password=theOrchid;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC070D7D5142");

            entity.Property(e => e.PremiumUntil).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appeals__3214EC07170E2515");

            entity.HasOne(d => d.User).WithMany(p => p.Appeals).HasConstraintName("FK__Appeals__UserId__33D4B598");
        });

        modelBuilder.Entity<BanReason>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__BanReaso__3214EC071AB3FBE4");

            entity.HasOne(d => d.User).WithMany(p => p.BanReasons).HasConstraintName("FK__BanReason__UserI__30F848ED");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC0747B63047");

            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithMany(p => p.Characters).HasConstraintName("FK__Character__UserI__2B3F6F97");
        });

        modelBuilder.Entity<Filter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Filters__3214EC07BFBC1D8F");
        });

        modelBuilder.Entity<FiltersToCharacter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FiltersT__3214EC079984F155");

            entity.HasOne(d => d.Character).WithMany(p => p.FiltersToCharacters).HasConstraintName("FK__FiltersTo__Chara__36B12243");

            entity.HasOne(d => d.Filter).WithMany(p => p.FiltersToCharacters).HasConstraintName("FK__FiltersTo__Filte__37A5467C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
