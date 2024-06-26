﻿using ChronoMarketplace.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ChronoMarketplace.Models;

namespace ChronoMarketplace.Areas.Identity.Data;

public class ChronoMarketplaceDbContext : IdentityDbContext<ChronoMarketplaceUser>
{
    public ChronoMarketplaceDbContext(DbContextOptions<ChronoMarketplaceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);


        builder.ApplyConfiguration(new ChronoMarketplaceUserEntityConfiguration());


    }

    public DbSet<ChronoMarketplace.Models.Category> Category { get; set; } = default!;

    public DbSet<ChronoMarketplace.Models.Payment> Payment { get; set; } = default!;

    public DbSet<ChronoMarketplace.Models.Product> Product { get; set; } = default!;

    public DbSet<ChronoMarketplace.Models.ShoppingCart> Shopping_Cart { get; set; } = default!;

    public DbSet<ChronoMarketplace.Models.ShoppingOrder> Shopping_Order { get; set; } = default!;

}

public class ChronoMarketplaceUserEntityConfiguration : IEntityTypeConfiguration<ChronoMarketplaceUser>
{
    public void Configure(EntityTypeBuilder<ChronoMarketplaceUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}