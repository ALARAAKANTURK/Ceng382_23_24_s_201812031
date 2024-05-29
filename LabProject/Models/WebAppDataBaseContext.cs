using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Models;

public partial class WebAppDatabaseContext : DbContext
{
    public WebAppDatabaseContext()
    {
    }

    public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LogTable> LogTables { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

   
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = WebApplication.CreateBuilder();
        var connectionString = builder.Configuration.GetConnectionString ("MyConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LogTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LogTable__3214EC27C9C9A156");

            entity.ToTable("LogTable");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Details).HasMaxLength(450);
            entity.Property(e => e.LogDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.Property(e => e.ReserverName).HasMaxLength(255);

            entity.HasOne(d => d.Room).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_Reservations_Rooms");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.Property(e => e.RoomName)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
