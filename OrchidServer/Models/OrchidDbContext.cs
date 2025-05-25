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

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<Filter> Filters { get; set; }

    public virtual DbSet<FiltersToCharacter> FiltersToCharacters { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=OrchidDB;User ID=OrchidAdminLogin;Password=theOrchid;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC078E70D98A");

            entity.Property(e => e.PremiumUntil).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appeals__3214EC070965E75A");

            entity.HasOne(d => d.User).WithMany(p => p.Appeals).HasConstraintName("FK__Appeals__UserId__412EB0B6");
        });

        modelBuilder.Entity<Character>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Characte__3214EC0744A2A46F");

            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.User).WithMany(p => p.Characters).HasConstraintName("FK__Character__UserI__2B3F6F97");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC073F2A2793");

            entity.Property(e => e.Likes).HasDefaultValue(0);

            entity.HasOne(d => d.Post).WithMany(p => p.Comments).HasConstraintName("FK__Comments__PostId__3D5E1FD2");

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasConstraintName("FK__Comments__UserId__3C69FB99");
        });

        modelBuilder.Entity<Filter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Filters__3214EC0741689E88");
        });

        modelBuilder.Entity<FiltersToCharacter>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FiltersT__3214EC0713045ED1");

            entity.HasOne(d => d.Character).WithMany(p => p.FiltersToCharacters).HasConstraintName("FK__FiltersTo__Chara__30F848ED");

            entity.HasOne(d => d.Filter).WithMany(p => p.FiltersToCharacters).HasConstraintName("FK__FiltersTo__Filte__31EC6D26");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forums__3214EC07E4560A8E");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC07D3041DF2");

            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.Pviews).HasDefaultValue(0);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts).HasConstraintName("FK__Posts__Forum__37A5467C");

            entity.HasOne(d => d.User).WithMany(p => p.Posts).HasConstraintName("FK__Posts__UserId__36B12243");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
