using MyIceDream.Areas.Identity.Data;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyIceDream.Models;
using System.Reflection.Emit;

namespace MyIceDream.Areas.Identity.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<VwUser> VwUsers { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<CartItem> CartItems { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.Entity<VwUser>(entity =>
        {

            entity.HasNoKey();
            entity.ToView("VwUsers");
        });
        builder.Entity<Product>()
                .Property(p => p.Price)
                .HasPrecision(18, 2);  
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        builder.Entity<Product>()
            .HasOne( p => p.Category)
            .WithMany(k => k.Products)
            .HasForeignKey(p => p.CategoryId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId)
            .OnDelete(DeleteBehavior.Cascade);
        //.Property(o => o.TotalPrice)
        //.HasPrecision(18, 2);
        builder.Entity<OrderItem>()
        .HasOne(oi => oi.Product)
        .WithMany()
        .HasForeignKey(oi => oi.ProductId);

        builder.Entity<Cart>(entity =>
        {
            entity.HasKey(c => c.Id);
        });

        base.OnModelCreating(builder);

        builder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Dessert", Description = "Lækre desserter" },
                new Category { Id = 2, Name = "Is", Description = "Forfriskende hjemmelavet is" },
                new Category { Id = 3, Name = "Varm drikke", Description = "Varme drikke for enhver smag" },
                new Category { Id = 4, Name = "Kolde drikke", Description = "Kolde og opkvikkende drikke" }
            );
        builder.Entity<Product>().HasData(
           // Dessert
           new Product { Id = 1, Name = "Dubai chokolade - Lille (80g)", Price = 60m, CategoryId = 1, Availability = true, Image = "/images/MiniDubaichokolade.png" },
           new Product { Id = 2, Name = "Dubai chokolade - Mellem (200g)", Price = 125m, CategoryId = 1, Availability = true, Image= "/images/DubaiChoc.png" },
           new Product { Id = 3, Name = "Dubai chokolade - Store (450g)", Price = 225m, CategoryId = 1, Availability = true, Image = "/images/DubaiChoc.png" },
           new Product { Id = 4, Name = "Kunafa med kashta", Price = 50m, CategoryId = 1, Availability = true, Image = "/images/Kunafa.png" },
           new Product { Id = 5, Name = "Kunafa nabelssia med ost", Price = 50m, CategoryId = 1, Availability = true, Image = "/images/KunafaOst.jpeg" },
           new Product { Id = 6, Name = "Tyrkisk baklava", Price = 50m, CategoryId = 1, Availability = true, Image = "/images/NoImage.jpeg" },
           new Product { Id = 7, Name = "Tyrkisk baklava med is", Price = 70m, CategoryId = 1, Availability = true, Image = "/images/TyrkiskBaklawa.jpeg" },
           new Product { Id = 8, Name = "Baklava mix", Price = 50m, CategoryId = 1, Availability = true, Image = "/images/Baklavamix.jpeg" },
           new Product { Id = 9, Name = "Bubble waffle med nutella", Price = 50m, CategoryId = 1, Availability = true, Image = "/images/Bubble.png" },
           new Product { Id = 10, Name = "Bubble waffle med nutella og frugt", Price = 65m, CategoryId = 1, Availability = true, Image = "/images/BubbleWaffleIs.png" },
           new Product { Id = 11, Name = "Bubble waffle med nutella og is", Price = 65m, CategoryId = 1, Availability = true, Image = "/images/BubffleWaffle.jpeg" },
           new Product { Id = 12, Name = "Bubble waffle med nutella, is og frugt", Price = 80m, CategoryId = 1, Availability = true, Image = "/images/NoImage.jpeg" },
           new Product { Id = 13, Name = "Belgisk waffle", Price = 50m, CategoryId = 1, Availability = true, Image = "/images/belgisk.jpeg" },
           new Product { Id = 14, Name = "Belgisk waffle med nutella og frugt", Price = 50m, CategoryId = 1, Availability = true, Image = "/images/NoImage.jpeg" },
           new Product { Id = 15, Name = "Belgisk waffle med nutella og is", Price = 60m, CategoryId = 1, Availability = true, Image = "/images/NoImage.jpeg" },
           new Product { Id = 16, Name = "Belgisk waffle med nutella, is og frugt", Price = 70m, CategoryId = 1, Availability = true, Image = "/images/NoImage.jpeg" },
           new Product { Id = 17, Name = "Pandekager med nutella", Price = 65m, CategoryId = 1, Availability = true, Image = "/images/MiniPankager.png" },
           new Product { Id = 18, Name = "Pandekager med nutella og frugt", Price = 75m, CategoryId = 1, Availability = true, Image = "/images/MiniPankager.png" },
           new Product { Id = 19, Name = "Pandekager med nutella og is", Price = 80m, CategoryId = 1, Availability = true, Image = "/images/MiniPankager.png" },
           new Product { Id = 20, Name = "Pandekager med nutella, is og frugt", Price = 85m, CategoryId = 1, Availability = true, Image = "/images/MiniPankager.png" },
           new Product { Id = 21, Name = "Churros med nutella", Price = 65m, CategoryId = 1, Availability = true, Image = "/images/Churros.jpeg" },
           new Product { Id = 22, Name = "Churros med nutella og is", Price = 75m, CategoryId = 1, Availability = true, Image = "/images/Churros.jpeg" },

// Is
new Product { Id = 23, Name = "Is box - 0.75 liter (3 smage)", Price = 115m, CategoryId = 2, Availability = true, Image = "/images/IsBOx.jpeg" },
new Product { Id = 24, Name = "Is box - 1 liter (4 smage)", Price = 145m, CategoryId = 2, Availability = true, Image = "/images/IsBOx.jpeg" },
new Product { Id = 25, Name = "Is box - 1.5 liter (5 smage)", Price = 190m, CategoryId = 2, Availability = true, Image = "/images/IsBOx.jpeg" },
new Product { Id = 26, Name = "Isrulle", Price = 50m, CategoryId = 2, Availability = true, Image = "/images/IceRolle.jpeg" },
new Product { Id = 27, Name = "Is kugle - 1 kugle", Price = 32m, CategoryId = 2, Availability = true, Image = "/images/Is.png" },
new Product { Id = 28, Name = "Is kugle - 2 kugler", Price = 42m, CategoryId = 2, Availability = true, Image = "/images/Is.png" },
new Product { Id = 29, Name = "Is kugle - 3 kugler", Price = 52m, CategoryId = 2, Availability = true, Image = "/images/Is.png" },

// Varm drikke
new Product { Id = 30, Name = "Americano", Price = 30m, CategoryId = 3, Availability = true, Image = "/images/Kaffe.jpeg" },
new Product { Id = 31, Name = "Espresso", Price = 25m, CategoryId = 3, Availability = true, Image = "/images/Espresso.jpeg" },
new Product { Id = 32, Name = "Cappuccino", Price = 45m, CategoryId = 3, Availability = true, Image = "/images/cappucino.jpeg" },
new Product { Id = 33, Name = "Kaffe latte", Price = 45m, CategoryId = 3, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 34, Name = "Chai latte", Price = 45m, CategoryId = 3, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 35, Name = "Matcha latte", Price = 50m, CategoryId = 3, Availability = true, Image = "/images/matcha.jpeg" },
new Product { Id = 36, Name = "Te", Price = 25m, CategoryId = 3, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 37, Name = "Arabisk kaffe", Price = 45m, CategoryId = 3, Availability = true, Image = "/images/Coffe.jpeg" },
new Product { Id = 38, Name = "Varm kakao", Price = 35m, CategoryId = 3, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 39, Name = "Macchiato", Price = 40m, CategoryId = 3, Availability = true, Image = "/images/NoImage.jpeg" },

// Kolde drikke
new Product { Id = 40, Name = "Bubble tea med frugt", Price = 55m, CategoryId = 4, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 41, Name = "Bubble tea med mælk tapioka", Price = 60m, CategoryId = 4, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 42, Name = "Milkshake", Price = 55m, CategoryId = 4, Availability = true, Image = "/images/Shakes.png" },
new Product { Id = 43, Name = "Mojito", Price = 50m, CategoryId = 4, Availability = true, Image = "/images/Mojito.png" },
new Product { Id = 44, Name = "Matcha", Price = 50m, CategoryId = 4, Availability = true, Image = "/images/matchaLatte.jpeg" },
new Product { Id = 45, Name = "Lemonade", Price = 45m, CategoryId = 4, Availability = true, Image = "/images/lemonade.jpeg" },
new Product { Id = 46, Name = "Iskaffe", Price = 40m, CategoryId = 4, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 47, Name = "Sodavand", Price = 20m, CategoryId = 4, Availability = true, Image = "/images/NoImage.jpeg" },
new Product { Id = 48, Name = "Vand", Price = 15m, CategoryId = 4, Availability = true, Image = "/images/NoImage.jpeg" }

);
    }
}

public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}
