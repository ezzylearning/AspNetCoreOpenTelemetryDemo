using System;
using System.Collections.Generic;
using AspNetCoreOpenTelemetryDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreOpenTelemetryDemo.Data;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=HOME-PC; Database=MyDatabase; Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK_app_Countries_Id")
                .IsClustered(false);

            entity.ToTable("Countries", "app");

            entity.HasIndex(e => e.SequenceId, "IX_app_Countries_SequenceId")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => e.Code, "UQ_app_Countries_Code").IsUnique();

            entity.HasIndex(e => e.Name, "UQ_app_Countries_Name").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Capital).HasMaxLength(100);
            entity.Property(e => e.Code).HasMaxLength(2);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.IsoCode3).HasMaxLength(3);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Nationality).HasMaxLength(200);
            entity.Property(e => e.PhoneCode).HasMaxLength(20);
            entity.Property(e => e.SequenceId).ValueGeneratedOnAdd();
            entity.Property(e => e.Tld).HasMaxLength(3);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
