using ChronoMarketplace.Areas.Identity.Data;
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
        builder.Entity<IdentityUserLogin<string>>(entity =>
        {
            entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
        });

        builder.Entity<IdentityRole>().HasData(
            new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" }
            );

        var harsher = new PasswordHasher<ChronoMarketplaceUser>();
        builder.Entity<ChronoMarketplaceUser>().HasData(

            new ChronoMarketplaceUser
            {
                Id = "1",
                FirstName = "Admin",
                LastName = "Team",
                UserName = "admin@chronomarketplace.com",
                NormalizedUserName = "ADMIN@CHRONOMARKETPLACE.COM",
                Email = "admin@chronomarketplace.com",
                NormalizedEmail = "ADMIN@CHRONOMARKETPLACE.COM",
                EmailConfirmed = true,
                PasswordHash = harsher.HashPassword(null, "Admin123")
            }

        );

        builder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string> { RoleId = "1", UserId = "1" }
        );

    }

    public DbSet<ChronoMarketplace.Models.Brand> Brand { get; set; } = default!;

    public DbSet<ChronoMarketplace.Models.Payment> Payment { get; set; } = default!;

    public DbSet<ChronoMarketplace.Models.Product> Product { get; set; } = default!;

    public DbSet<ChronoMarketplace.Models.ShoppingItem> Shopping_Cart { get; set; } = default!;

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

