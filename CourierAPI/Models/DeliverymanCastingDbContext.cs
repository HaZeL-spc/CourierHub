using System;
using System.Collections.Generic;
using CourierAPI.Data;
using CourierAPI.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;

namespace CourierAPI.Models;

public partial class DeliverymanCastingDbContext : DbContext
{
    public DbSet<Delivery> Deliveries { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Inquiry> Inquiries { get; set; }

    public DeliverymanCastingDbContext()
    {
    }

    public DeliverymanCastingDbContext(DbContextOptions<DeliverymanCastingDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new DeliveryConfiguration())
            .ApplyConfiguration(new InquiryConfiguration())
            .ApplyConfiguration(new ClientConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
