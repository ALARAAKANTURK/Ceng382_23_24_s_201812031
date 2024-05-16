using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LabProject.Models;

public partial class WebAppDataBaseContext : DbContext
{
    public WebAppDataBaseContext()
    {
    }

    public WebAppDataBaseContext(DbContextOptions<WebAppDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var builder = WebApplication.CreateBuilder();
        var connectionString = builder.Configuration.GetConnectionString ("MyConnection");
        optionsBuilder.UseSqlServer(connectionString);
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
