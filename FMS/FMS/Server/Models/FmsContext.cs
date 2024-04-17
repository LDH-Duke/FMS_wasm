using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FMS.Shared.Entity;

namespace FMS.Server.Models;


public partial class FmsContext : DbContext
{
    public FmsContext()
    {
    }

    public FmsContext(DbContextOptions<FmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DeviceInfo> DeviceInfo { get; set; }

    public virtual DbSet<FloorInfo> FloorInfo { get; set; }

    public virtual DbSet<LocationInfo> LocationInfo { get; set; }

    public virtual DbSet<PlaceInfo> PlaceInfo { get; set; }

    public virtual DbSet<PlantInfo> PlantInfo { get; set; }

    public virtual DbSet<UserInfo> UserInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DefaultConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DeviceInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DeviceInfo");

            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateDT");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LocationInfoId).HasColumnName("LocationInfo_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("UpdateDT");

            entity.HasOne(d => d.LocationInfo).WithMany()
                .HasForeignKey(d => d.LocationInfoId)
                .HasConstraintName("FK__DeviceInf__Locat__45F365D3");
        });

        modelBuilder.Entity<FloorInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FloorInf__3214EC0726F6BCAB");

            entity.ToTable("FloorInfo");

            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateDT");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PlantInfoCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PlantInfo_Code");
            entity.Property(e => e.UpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("UpdateDT");

            entity.HasOne(d => d.PlantInfoCodeNavigation).WithMany(p => p.FloorInfos)
                .HasForeignKey(d => d.PlantInfoCode)
                .HasConstraintName("FK__FloorInfo__Plant__3F466844");
        });

        modelBuilder.Entity<LocationInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC07BB802BBF");

            entity.ToTable("LocationInfo");

            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateDT");
            entity.Property(e => e.FloorInfoId).HasColumnName("FloorInfo_Id");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("UpdateDT");

            entity.HasOne(d => d.FloorInfo).WithMany(p => p.LocationInfos)
                .HasForeignKey(d => d.FloorInfoId)
                .HasConstraintName("FK__LocationI__Floor__4316F928");
        });

        modelBuilder.Entity<PlaceInfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__PlaceInf__A25C5AA65885FD48");

            entity.ToTable("PlaceInfo");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateDT");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Note)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("UpdateDT");
        });

        modelBuilder.Entity<PlantInfo>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PK__PlantInf__A25C5AA63646FD1B");

            entity.ToTable("PlantInfo");

            entity.Property(e => e.Code)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateDT");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PlaceInfoCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PlaceInfo_Code");
            entity.Property(e => e.UpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("UpdateDT");

            entity.HasOne(d => d.CodeNavigation).WithOne(p => p.PlantInfoCodeNavigation)
                .HasForeignKey<PlantInfo>(d => d.Code)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("PlaceInfo_Code");

            entity.HasOne(d => d.PlaceInfoCodeNavigation).WithMany(p => p.PlantInfoPlaceInfoCodeNavigations)
                .HasForeignKey(d => d.PlaceInfoCode)
                .HasConstraintName("FK__PlantInfo__Place__3B75D760");
        });

        modelBuilder.Entity<UserInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("UserInfo");

            entity.Property(e => e.CreateDt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("CreateDT");
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.IsAdmin).HasDefaultValueSql("((0))");
            entity.Property(e => e.Password)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.PermAdm)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Adm");
            entity.Property(e => e.PermClaim)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Claim");
            entity.Property(e => e.PermComp)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Comp");
            entity.Property(e => e.PermConst)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Const");
            entity.Property(e => e.PermDevice)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Device");
            entity.Property(e => e.PermEnergy)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Energy");
            entity.Property(e => e.PermImployee)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Imployee");
            entity.Property(e => e.PermLawck)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_lawck");
            entity.Property(e => e.PermLawedu)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_lawedu");
            entity.Property(e => e.PermMaterial)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Material");
            entity.Property(e => e.PermPlace)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Place");
            entity.Property(e => e.PermSys)
                .HasDefaultValueSql("((0))")
                .HasColumnName("Perm_Sys");
            entity.Property(e => e.PlaceInfoCode)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("PlaceInfo_Code");
            entity.Property(e => e.UpdateDt)
                .HasColumnType("datetime")
                .HasColumnName("UpdateDT");
            entity.Property(e => e.UserId)
                .HasMaxLength(15)
                .IsUnicode(false);

            entity.HasOne(d => d.PlaceInfoCodeNavigation).WithMany()
                .HasForeignKey(d => d.PlaceInfoCode)
                .HasConstraintName("FK__UserInfo__PlaceI__5535A963");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
