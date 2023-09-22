using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCWebApplication.Models;

public partial class MobileDbContext : DbContext
{
    public MobileDbContext()
    {
    }

    public MobileDbContext(DbContextOptions<MobileDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MobileDetail> MobileDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MobileDetail>(entity =>
        {
            entity.Property(e => e.MobileName).HasMaxLength(100);
            entity.Property(e => e.Ram).HasColumnName("RAM");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
