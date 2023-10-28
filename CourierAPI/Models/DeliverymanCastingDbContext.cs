using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CourierAPI.Models;

public partial class DeliverymanCastingDbContext : DbContext
{
    public DeliverymanCastingDbContext()
    {
    }

    public DeliverymanCastingDbContext(DbContextOptions<DeliverymanCastingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
