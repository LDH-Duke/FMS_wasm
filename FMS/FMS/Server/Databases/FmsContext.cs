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

    public virtual DbSet<MaterialinfoInventory> MaterialinfoInventories { get; set; }

    public virtual DbSet<Placeinfo> Placeinfos { get; set; }

    public virtual DbSet<Roominfo> Roominfos { get; set; }

    public virtual DbSet<Socketroominfo> Socketroominfos { get; set; }

    public virtual DbSet<Subitem> Subitems { get; set; }

    public virtual DbSet<Userinfo> Userinfos { get; set; }

    public virtual DbSet<Vocinfo> Vocinfos { get; set; }

    public virtual DbSet<VocinfoComment> VocinfoComments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=123.2.156.122,1002;Database=FMS;User Id=stec;Password=stecdev1234!;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alarminfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ALARMINF__3214EC2764BBAF24");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Socketroominfo).WithMany(p => p.Alarminfos).HasConstraintName("FK__ALARMINFO__SOCKE__4589517F");

            entity.HasOne(d => d.UserinfoUser).WithMany(p => p.Alarminfos).HasConstraintName("FK__ALARMINFO__USERI__43A1090D");

            entity.HasOne(d => d.Vocinfo).WithMany(p => p.Alarminfos).HasConstraintName("FK__ALARMINFO__VOCIN__44952D46");
        });

        modelBuilder.Entity<Alarmtalklog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ALARMTAL__3214EC275ABD95BC");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Buildinginfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__BUILDING__AA1D4378113E78B4");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.PlaceinfoCodeNavigation).WithMany(p => p.Buildinginfos).HasConstraintName("FK__BUILDINGI__PLACE__5BAD9CC8");
        });

        modelBuilder.Entity<Energyinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ENERGYIN__3214EC27922A7A4B");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Energymonthinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ENERGYMO__3214EC27ABBA954B");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.Energymonthinfos).HasConstraintName("FK__ENERGYMON__BUILD__4A4E069C");
        });

        modelBuilder.Entity<Facilityinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FACILITY__3214EC279D5B2336");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.FacilityCreatedt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Roominfo).WithMany(p => p.Facilityinfos).HasConstraintName("FK__FACILITYI__ROOMI__22401542");
        });

        modelBuilder.Entity<Floorinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FLOORINF__3214EC273BEAFB19");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.Floorinfos).HasConstraintName("FK__FLOORINFO__BUILD__12FDD1B2");
        });

        modelBuilder.Entity<Materialinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAL__3214EC27E823001F");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Roominfo).WithMany(p => p.Materialinfos).HasConstraintName("FK__MATERIALI__ROOMI__1C873BEC");
        });

        modelBuilder.Entity<MaterialinfoInventory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__MATERIAL__3214EC27DFE6634A");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Meterialinfo).WithMany(p => p.MaterialinfoInventories).HasConstraintName("FK__MATERIALI__METER__29E1370A");
        });

        modelBuilder.Entity<Placeinfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__PLACEINF__AA1D4378FE87E3AD");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Roominfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ROOMINFO__3214EC2706AD525A");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.Floorinfo).WithMany(p => p.Roominfos).HasConstraintName("FK__ROOMINFO__FLOORI__17C286CF");
        });

        modelBuilder.Entity<Socketroominfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SOCKETRO__3214EC27C5EB30D2");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<Subitem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SUBITEM__3214EC271924932D");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.BuildinginfoCodeNavigation).WithMany(p => p.Subitems).HasConstraintName("FK__SUBITEM__BUILDIN__5D60DB10");

            entity.HasOne(d => d.Facilityinfo).WithMany(p => p.Subitems).HasConstraintName("FK__SUBITEM__FACILIT__5E54FF49");
        });

        modelBuilder.Entity<Userinfo>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__USERINFO__7B9E7F35D45C27C7");

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

            entity.HasOne(d => d.PlaceinfoCodeNavigation).WithMany(p => p.Userinfos).HasConstraintName("FK__USERINFO__PLACEI__7FEAFD3E");
        });

        modelBuilder.Entity<Vocinfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOCINFO__3214EC279AE64C96");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.ReplyYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");
        });

        modelBuilder.Entity<VocinfoComment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VOCINFO___3214EC2719E92A90");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.DelYn).HasDefaultValueSql("((0))");
            entity.Property(e => e.Status).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.UserinfoUser).WithMany(p => p.VocinfoComments).HasConstraintName("FK__VOCINFO_C__USERI__3DE82FB7");

            entity.HasOne(d => d.Vocinfo).WithMany(p => p.VocinfoComments).HasConstraintName("FK__VOCINFO_C__VOCIN__3CF40B7E");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
