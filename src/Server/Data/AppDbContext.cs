using CrossplatformHW.Server.Common;
using CrossplatformHW.Server.Data.Entities;
using CrossplatformHW.Server.Data.Entities.Joints;
using Microsoft.EntityFrameworkCore;

namespace CrossplatformHW.Server.Data;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Permission> Permissions { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Security> Securities { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<RolePermission> RolePermissions { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Relations
        modelBuilder.Entity<User>().HasOne(user => user.Role)
            .WithMany();
        modelBuilder.Entity<Product>()
            .HasMany(product => product.Comments)
            .WithOne(comment => comment.Product);
        modelBuilder.Entity<Role>()
            .HasMany(role => role.Permissions)
            .WithMany()
            .UsingEntity<RolePermission>();

        //Seeding roles
        var permissions = Enum.GetValues<Permissions>()
            .Select(permission => new Permission
            {
                Id = (int)permission,
                Name = permission.ToString()
            });
        var roles = Enum.GetValues<Roles>()
            .Select(role => new Role
            {
                Id = (int)role,
                Name = role.ToString()
            });

        modelBuilder.Entity<Permission>()
            .HasData(permissions);
        modelBuilder.Entity<Role>()
            .HasData(roles);
        modelBuilder.Entity<RolePermission>()
            .HasData(
                new RolePermission
                    { RoleId = (int)Common.Roles.Customer, PermissionId = (int)Common.Permissions.CustomerPermission },
                new RolePermission
                    { RoleId = (int)Common.Roles.Admin, PermissionId = (int)Common.Permissions.CustomerPermission },
                new RolePermission
                    { RoleId = (int)Common.Roles.Admin, PermissionId = (int)Common.Permissions.AdminPermission }
            );


        //Seeding products data
        var defaultClothesId = Guid.NewGuid();
        var upperClothesId = Guid.NewGuid();
        var eveningClothesId = Guid.NewGuid();
        var sportClothesId = Guid.NewGuid();
        var sandClothesId = Guid.NewGuid();
        var businessClothesId = Guid.NewGuid();

        modelBuilder.Entity<Category>()
            .HasData(
                new Category { Id = defaultClothesId, Name = "Звичайний одяг", Slug = "default-clothes" },
                new Category { Id = upperClothesId, Name = "Верхній одяг", Slug = "upper-clothes" },
                new Category { Id = eveningClothesId, Name = "Вечірній одяг", Slug = "evening-clothes" },
                new Category { Id = sportClothesId, Name = "Спортивний одяг", Slug = "sport-clothes" },
                new Category { Id = sandClothesId, Name = "Пляжний одяг", Slug = "sand-clothes" },
                new Category { Id = businessClothesId, Name = "Бізнес одяг", Slug = "business clothes" }
            );

        modelBuilder.Entity<Product>()
            .HasData(
                new Product
                {
                    Name = "Футболка",
                    Description = "Футболка",
                    Slug = "tshirt",
                    ImageUrl =
                        "https://static.athletics.kiev.ua/static/i/395_380/products/253314/22CpzFlU.jpeg",
                    Price = 5.99m,
                    CategoryId = defaultClothesId
                },
                new Product
                {
                    Name = "Джинси",
                    Description = "Джинси",
                    Slug = "jeans",
                    ImageUrl =
                        "https://static.reserved.com/media/catalog/product/cache/1200/a4e40ebdc3e371adff845072e1c73f37/6/0/6048H-50J-010-1_13.jpg",
                    Price = 8.99m,
                    CategoryId = defaultClothesId
                },
                new Product
                {
                    Name = "Сорочка",
                    Description = "Сорочка",
                    Slug = "shirt",
                    ImageUrl =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSzFHH6zjvPiqtNNOQldZCzVS8XUNYxl-OnY7jqg1E&s",
                    Price = 7m,
                    CategoryId = defaultClothesId
                },
                new Product
                {
                    Name = "Спідниця",
                    Description = "Спідниця",
                    Slug = "skirt",
                    ImageUrl =
                        "https://content.rozetka.com.ua/goods/images/big/32645949.jpg",
                    Price = 11.5m,
                    CategoryId = defaultClothesId
                },
                new Product
                {
                    Name = "Світшот",
                    Description = "Світшот",
                    Slug = "sweatshirt",
                    ImageUrl =
                        "https://static.reserved.com/media/catalog/product/cache/1200/a4e40ebdc3e371adff845072e1c73f37/0/4/0401M-MLC-010-1_8.jpg",
                    Price = 16.49m,
                    CategoryId = defaultClothesId
                },
                new Product
                {
                    Name = "Шорти",
                    Description = "Шорти",
                    Slug = "shorts",
                    ImageUrl =
                        "https://burdastyle.ua/sites/default/files/models/burdastyle_shorty_na_kulisci_119_6_2020.jpg",
                    Price = 6.99m,
                    CategoryId = defaultClothesId
                },
                new Product
                {
                    Name = "Куртка",
                    Description = "Куртка",
                    Slug = "jacket",
                    ImageUrl =
                        "https://borec.in.ua/5463-medium_default/kurtka-manto-winter-jacket-alpha.jpg",
                    Price = 25.99m,
                    CategoryId = upperClothesId
                },
                new Product
                {
                    Name = "Пальто",
                    Description = "Пальто",
                    Slug = "coat",
                    ImageUrl =
                        "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKTkDVuYPEshdgAbCOrhUGh-7Ey-eY-N9O3Q&usqp=CAU",
                    Price = 47.99m,
                    CategoryId = upperClothesId
                },
                new Product
                {
                    Name = "Сукня",
                    Description = "Сукня",
                    Slug = "dress",
                    ImageUrl =
                        "https://foberini.com/image/cache/catalog/product/women/SS16/01067/01067%20site-cr-493x739.jpg",
                    Price = 33.29m,
                    CategoryId = eveningClothesId
                },
                new Product
                {
                    Name = "Смокінг",
                    Description = "Смокінг",
                    Slug = "tuxedo",
                    ImageUrl =
                        "https://images.prom.ua/1510914484_muzhskoj-smoking-west-fashion.jpg",
                    Price = 87.99m,
                    CategoryId = eveningClothesId
                },
                new Product
                {
                    Name = "Спортивні штани",
                    Description = "Спортивні штани",
                    Slug = "sport-pants",
                    ImageUrl =
                        "https://unimarket.com.ua/wp-content/uploads/2020/02/DJ-9404.jpg",
                    Price = 87.99m,
                    CategoryId = sportClothesId
                },
                new Product
                {
                    Name = "Бігові кросівки",
                    Description = "Бігові кросівки",
                    Slug = "runners",
                    ImageUrl =
                        "https://hadi.ua/image/cache/catalog/asics/10/1014A226-101-1024x1024.jpg",
                    Price = 34.99m,
                    CategoryId = sportClothesId
                },
                new Product
                {
                    Name = "Купальник",
                    Description = "Купальник",
                    Slug = "swimmer",
                    ImageUrl =
                        "https://swimstore.by/assets/components/phpthumbof/cache/2a243-055-5.f93d8153e4bae606f1ec449a4d218fdc13.f93d8153e4bae606f1ec449a4d218fdc13.jpg",
                    Price = 17.99m,
                    CategoryId = sandClothesId
                },
                new Product
                {
                    Name = "Парео",
                    Description = "Парео",
                    Slug = "pareo",
                    ImageUrl =
                        "https://cdn.shopify.com/s/files/1/0067/6446/2144/files/Blog_pictures_f2560263-5922-434e-8e2b-15c46544661e_600x600.jpg?v=1649677525",
                    Price = 33.24m,
                    CategoryId = sandClothesId
                },
                new Product
                {
                    Name = "Краватка",
                    Description = "Краватка",
                    Slug = "tie",
                    ImageUrl =
                        "https://cdn.lbtq.io/productImage/resize/300x400_40cd750bba9870f18aada2478b24840a/20210810/160/20210810160317_005841155_1.jpg",
                    Price = 13.24m,
                    CategoryId = businessClothesId
                },
                new Product
                {
                    Name = "Сорочка з манжетами",
                    Description = "Сорочка з манжетами",
                    Slug = "cuffs",
                    ImageUrl =
                        "https://soro4ka.com.ua/image/cache/catalog/Products/Sorochku/Astron/138692320238/138692320238-1-1000x1000.jpg",
                    Price = 26.67m,
                    CategoryId = businessClothesId
                }
            );
    }
}