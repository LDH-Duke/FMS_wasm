using System;
using System.Collections.Generic;
using FMS.Shared.Models;
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

    public virtual DbSet<DeviceInfo> DeviceInfos { get; set; }

    public virtual DbSet<FloorInfo> FloorInfos { get; set; }

    public virtual DbSet<LocationInfo> LocationInfos { get; set; }

    public virtual DbSet<PlaceInfo> PlaceInfos { get; set; }

    public virtual DbSet<PlantInfo> PlantInfos { get; set; }

    public virtual DbSet<UserInfo> UserInfos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=123.2.156.122,1002;Database=FMS;User Id=stec;Password=stecdev1234!;TrustServerCertificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DeviceIn__3214EC073F5457E5");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.LocationInfo).WithMany(p => p.DeviceInfos).HasConstraintName("FK__DeviceInf__Locat__1AD3FDA4");
        });

        modelBuilder.Entity<FloorInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FloorInf__3214EC07A467F7E1");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.PlantInfoCodeNavigation).WithMany(p => p.FloorInfos).HasConstraintName("FK__FloorInfo__Plant__1332DBDC");
        });

        modelBuilder.Entity<LocationInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC0715597769");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.FloorInfo).WithMany(p => p.LocationInfos).HasConstraintName("FK__LocationI__Floor__17036CC0");
        });

        modelBuilder.Entity<PlaceInfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__PlaceInf__A25C5AA6EB653993");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PlantInfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__PlantInf__A25C5AA64542EC39");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.HasOne(d => d.PlaceInfoCodeNavigation).WithMany(p => p.PlantInfos).HasConstraintName("FK__PlantInfo__Place__0F624AF8");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__UserInfo__1788CC4C02383385");

            entity.Property(e => e.CreateDt).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");
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

            entity.HasOne(d => d.PlaceInfoCodeNavigation).WithMany(p => p.UserInfos).HasConstraintName("FK__UserInfo__PlaceI__2B0A656D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
