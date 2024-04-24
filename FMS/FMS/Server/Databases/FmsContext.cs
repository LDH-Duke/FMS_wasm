using System;
using System.Collections.Generic;
using FMS.Shared.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.Server.Databases;

public partial class FmsContext : DbContext
{
    public FmsContext()
    {
    }

    public FmsContext(DbContextOptions<FmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alarminfo> Alarminfos { get; set; }

    public virtual DbSet<Alarmtalklog> Alarmtalklogs { get; set; }

    public virtual DbSet<Buildinginfo> Buildinginfos { get; set; }

    public virtual DbSet<Energyinfo> Energyinfos { get; set; }

    public virtual DbSet<Energymonthinfo> Energymonthinfos { get; set; }

    public virtual DbSet<Facilityinfo> Facilityinfos { get; set; }

    public virtual DbSet<Floorinfo> Floorinfos { get; set; }

    public virtual DbSet<Materialinfo> Materialinfos { get; set; }

    public virtual DbSet<Placeinfo> Placeinfos { get; set; }

    public virtual DbSet<RoomInventory> RoomInventories { get; set; }

    public virtual DbSet<Roominfo> Roominfos { get; set; }

    public virtual DbSet<Socketroominfo> Socketroominfos { get; set; }

    public virtual DbSet<Subitem> Subitems { get; set; }

    public virtual DbSet<TotalInventory> TotalInventories { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    public virtual DbSet<Vocinfo> Vocinfos { get; set; }

    public virtual DbSet<VocinfoComment> VocinfoComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=123.2.156.122,1002;Database=FMS;User Id=stec;Password=stecdev1234!;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alarminfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ALARMINF__3214EC27EA30F64E");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Socketroominfo).WithMany(p => p.Alarminfos).HasConstraintName("FK__ALARMINFO__SOCKE__0BE6BFCF");

            entity.HasOne(d => d.UserinfoUser).WithMany(p => p.Alarminfos).HasConstraintName("FK__ALARMINFO__USERI__09FE775D");

            entity.HasOne(d => d.Vocinfo).WithMany(p => p.Alarminfos).HasConstraintName("FK__ALARMINFO__VOCIN__0AF29B96");
        });

        modelBuilder.Entity<Alarmtalklog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ALARMTAL__3214EC27B638B645");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Buildinginfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__BUILDING__AA1D4378CC0B17B2");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.PlaceinfoCodeNavigation).WithMany(p => p.Buildinginfos).HasConstraintName("FK__BUILDINGI__PLACE__50C5FA01");
        });

        modelBuilder.Entity<Energyinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ENERGYIN__3214EC273521FA9A");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Energymonthinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ENERGYMO__3214EC2709F0CC37");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.Energymonthinfos).HasConstraintName("FK__ENERGYMON__BUILD__414EAC47");
        });

        modelBuilder.Entity<Facilityinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FACILITY__3214EC2732CB3A66");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.FacilityCreatedt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Roominfo).WithMany(p => p.Facilityinfos).HasConstraintName("FK__FACILITYI__ROOMI__5832119F");
        });

        modelBuilder.Entity<Floorinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FLOORINF__3214EC270F115E83");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.Floorinfos).HasConstraintName("FK__FLOORINFO__BUILD__5B438874");
        });

        modelBuilder.Entity<Materialinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAL__3214EC279EA05BCD");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Placeinfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__PLACEINF__AA1D4378EE7F5696");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<RoomInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROOM_INV__3214EC2742553AC4");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.RoomInventories).HasConstraintName("FK__ROOM_INVE__BUILD__7F80E8EA");

            entity.HasOne(d => d.Roominfo).WithMany(p => p.RoomInventories).HasConstraintName("FK__ROOM_INVE__ROOMI__7E8CC4B1");
        });

        modelBuilder.Entity<Roominfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROOMINFO__3214EC274895D6F8");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Floorinfo).WithMany(p => p.Roominfos).HasConstraintName("FK__ROOMINFO__FLOORI__65C116E7");
        });

        modelBuilder.Entity<Socketroominfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SOCKETRO__3214EC273C4DA122");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Subitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SUBITEM__3214EC27083DD45D");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.Subitems).HasConstraintName("FK__SUBITEM__BUILDIN__5CF6C6BC");

            entity.HasOne(d => d.Facilityinfo).WithMany(p => p.Subitems).HasConstraintName("FK__SUBITEM__FACILIT__5DEAEAF5");
        });

        modelBuilder.Entity<TotalInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TOTAL_IN__3214EC272E1576B5");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.TotalInventories).HasConstraintName("FK__TOTAL_INV__BUILD__658C0CBD");

            entity.HasOne(d => d.Meterialinfo).WithMany(p => p.TotalInventories).HasConstraintName("FK__TOTAL_INV__METER__6497E884");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__USERINFO__7B9E7F35E634073D");

            entity.Property(e => e.AdminYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.AlarmYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.PermAdm).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermClaim).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermComp).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermConst).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermDevice).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermEnergy).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermImployee).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermLawck).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermLawedu).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermMaterial).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermPlace).HasDefaultValueSql("((0))");
            entity.Property(e => e.PermSys).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((1))");

            entity.HasOne(d => d.PlaceinfoCodeNavigation).WithMany(p => p.Userinfos).HasConstraintName("FK__USERINFO__PLACEI__0E04126B");
        });

        modelBuilder.Entity<Vocinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOCINFO__3214EC27856EF568");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.ReplyYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<VocinfoComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOCINFO___3214EC272C93F75C");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.UserinfoUser).WithMany(p => p.VocinfoComments).HasConstraintName("FK__VOCINFO_C__USERI__27C3E46E");

            entity.HasOne(d => d.Vocinfo).WithMany(p => p.VocinfoComments).HasConstraintName("FK__VOCINFO_C__VOCIN__26CFC035");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
