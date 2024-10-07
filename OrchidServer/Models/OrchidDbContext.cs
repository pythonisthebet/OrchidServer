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

    public virtual DbSet<ChList> ChLists { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<EquipRarity> EquipRarities { get; set; }

    public virtual DbSet<EquipType> EquipTypes { get; set; }

    public virtual DbSet<Equipment> Equipments { get; set; }

    public virtual DbSet<Feat> Feats { get; set; }

    public virtual DbSet<Forum> Forums { get; set; }

    public virtual DbSet<PartieUser> PartieUsers { get; set; }

    public virtual DbSet<Party> Parties { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<Skill> Skills { get; set; }

    public virtual DbSet<SkillStat> SkillStats { get; set; }

    public virtual DbSet<Spell> Spells { get; set; }

    public virtual DbSet<SubClass> SubClasses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=OrchidDB;User ID=OrchidAdminLogin;Password=theOrchid;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AppUsers__3214EC0713A66A3D");
        });

        modelBuilder.Entity<Appeal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Appeals__3214EC07DFBDD2D9");

            entity.HasOne(d => d.User).WithMany(p => p.Appeals).HasConstraintName("FK__Appeals__UserId__68487DD7");
        });

        modelBuilder.Entity<ChList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ch_List__3214EC0745C42B26");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.LevelValue).HasDefaultValue(1);

            entity.HasOne(d => d.MainClassNavigation).WithMany(p => p.ChLists).HasConstraintName("FK__Ch_List__Main_Cl__4F7CD00D");

            entity.HasOne(d => d.RaceNavigation).WithMany(p => p.ChListRaceNavigations).HasConstraintName("FK__Ch_List__Race__5070F446");

            entity.HasOne(d => d.SubclassNavigation).WithMany(p => p.ChListSubclassNavigations).HasConstraintName("FK__Ch_List__Subclas__5165187F");

            entity.HasOne(d => d.User).WithMany(p => p.ChLists).HasConstraintName("FK__Ch_List__UserId__4E88ABD4");
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Classes__3214EC07C5383F5D");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Comments__3214EC075377C9BD");

            entity.Property(e => e.Likes).HasDefaultValue(0);

            entity.HasOne(d => d.Post).WithMany(p => p.Comments).HasConstraintName("FK__Comments__PostId__6477ECF3");

            entity.HasOne(d => d.User).WithMany(p => p.Comments).HasConstraintName("FK__Comments__UserId__6383C8BA");
        });

        modelBuilder.Entity<EquipRarity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equip_Ra__3214EC07AFF37B42");
        });

        modelBuilder.Entity<EquipType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equip_Ty__3214EC0740CAFF21");
        });

        modelBuilder.Entity<Equipment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Equipmen__3214EC077CEE3FB4");

            entity.HasOne(d => d.Rarity).WithMany(p => p.Equipment).HasConstraintName("FK__Equipment__Rarit__4AB81AF0");

            entity.HasOne(d => d.Type).WithMany(p => p.Equipment).HasConstraintName("FK__Equipment__TypeI__49C3F6B7");
        });

        modelBuilder.Entity<Feat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feats__3214EC074484DE38");
        });

        modelBuilder.Entity<Forum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Forums__3214EC07EAE9363B");
        });

        modelBuilder.Entity<PartieUser>(entity =>
        {
            entity.HasOne(d => d.Party).WithMany().HasConstraintName("FK__Partie_Us__Party__59063A47");

            entity.HasOne(d => d.User).WithMany().HasConstraintName("FK__Partie_Us__UserI__5812160E");
        });

        modelBuilder.Entity<Party>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Parties__3214EC07FA3CFE34");

            entity.HasOne(d => d.Dm).WithMany(p => p.Parties).HasConstraintName("FK__Parties__DmId__5629CD9C");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Posts__3214EC070D5F85D7");

            entity.Property(e => e.Likes).HasDefaultValue(0);
            entity.Property(e => e.Pviews).HasDefaultValue(0);

            entity.HasOne(d => d.ForumNavigation).WithMany(p => p.Posts).HasConstraintName("FK__Posts__Forum__5EBF139D");

            entity.HasOne(d => d.User).WithMany(p => p.Posts).HasConstraintName("FK__Posts__UserId__5DCAEF64");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Races__3214EC07225EA465");
        });

        modelBuilder.Entity<Skill>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skills__3214EC07612EC173");

            entity.HasOne(d => d.StatNavigation).WithMany(p => p.Skills).HasConstraintName("FK__Skills__Stat__412EB0B6");
        });

        modelBuilder.Entity<SkillStat>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Skill_St__3214EC075DA6258E");
        });

        modelBuilder.Entity<Spell>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Spells__3214EC070B8C9CE6");
        });

        modelBuilder.Entity<SubClass>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Sub_Clas__3214EC0740344270");

            entity.HasOne(d => d.Class).WithMany(p => p.SubClasses).HasConstraintName("FK__Sub_Class__Class__30F848ED");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
