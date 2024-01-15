using System;
using System.Collections.Generic;
using CourierCastingApp.Data;
using Microsoft.EntityFrameworkCore;

namespace CourierCastingApp.Models;

public partial class CourierCastingAppDbContext : DbContext
{
    public DbSet<SessionHistory> SessionHistory { get; set; }

    public CourierCastingAppDbContext()
    {
    }

    public CourierCastingAppDbContext(DbContextOptions<CourierCastingAppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SessionHistory>().HasIndex(s => s.Id);
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
