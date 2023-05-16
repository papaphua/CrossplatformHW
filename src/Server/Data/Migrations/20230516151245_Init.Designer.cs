﻿// <auto-generated />
using System;
using CrossplatformHW.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CrossplatformHW.Server.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230516151245_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Name = "Books",
                            Slug = "books"
                        },
                        new
                        {
                            Id = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Name = "Movies",
                            Slug = "movies"
                        },
                        new
                        {
                            Id = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Name = "Video Games",
                            Slug = "video-games"
                        });
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Comment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Joints.RolePermission", b =>
                {
                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("PermissionId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RolePermissions");

                    b.HasData(
                        new
                        {
                            PermissionId = 1,
                            RoleId = 1
                        },
                        new
                        {
                            PermissionId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            PermissionId = 2,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "CustomerPermission"
                        },
                        new
                        {
                            Id = 2,
                            Name = "AdminPermission"
                        });
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = new Guid("292a12f7-e9fa-4ff5-bf57-ac59c20a7742"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A novel about a woman's journey through the Dust Bowl era of the 1930s",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1594925043i/53138081.jpg",
                            Name = "The Four Winds",
                            Price = 25.99m,
                            Slug = "the-four-winds"
                        },
                        new
                        {
                            Id = new Guid("4d66b4f7-37f6-403e-8772-ef55d1571ee2"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A novel about a woman who finds herself in a library between life and death, with the opportunity to try out different versions of her life",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1602190253i/52578297.jpg",
                            Name = "The Midnight Library",
                            Price = 21.99m,
                            Slug = "the-midnight-library"
                        },
                        new
                        {
                            Id = new Guid("315071e2-36c9-4aeb-9a1b-7a97db38ecc6"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A novel about a robot who observes the world and learns about human behavior",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1603206535i/54120408.jpg",
                            Name = "Klara and the Sun",
                            Price = 27.99m,
                            Slug = "klara-and-the-sun"
                        },
                        new
                        {
                            Id = new Guid("7050044f-dff0-46ad-934a-45eee7739871"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A novel about a man on a solo mission to save the world from extinction",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1597695864i/54493401.jpg",
                            Name = "Project Hail Mary",
                            Price = 24.99m,
                            Slug = "project-hail-mary"
                        },
                        new
                        {
                            Id = new Guid("2494e70f-2a91-4827-a519-98dee55adc0c"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A thriller about a detective investigating a murder at an isolated hotel in the Swiss Alps",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1612344489i/56935099.jpg",
                            Name = "The Sanatorium",
                            Price = 19.99m,
                            Slug = "the-sanatorium"
                        },
                        new
                        {
                            Id = new Guid("90fd17e3-9e47-46af-aa95-11f23bb016dd"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A novel about a mother's intense desire for perfection and the consequences of her actions",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1609854219i/52476830.jpg",
                            Name = "The Push",
                            Price = 20.99m,
                            Slug = "the-push"
                        },
                        new
                        {
                            Id = new Guid("8bb09c92-053a-40ba-be14-3fef88a6421f"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A non-fiction book about the woman who helped develop CRISPR gene-editing technology",
                            ImageUrl = "https://m.media-amazon.com/images/I/41an9tLSfBL._SX327_BO1,204,203,200_.jpg",
                            Name = "The Code Breaker",
                            Price = 28.99m,
                            Slug = "the-code-breaker"
                        },
                        new
                        {
                            Id = new Guid("5811bc19-776c-4c4b-8da6-7c6dd821f5a4"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A memoir about a woman's relationship with her Korean mother and the grieving process after her mother's death",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601937850i/54814676.jpg",
                            Name = "Crying in H Mart",
                            Price = 22.99m,
                            Slug = "crying-in-h-mart"
                        },
                        new
                        {
                            Id = new Guid("185d064c-2075-430a-8612-9b2ace4baf03"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A novel about the intersection of the digital and real worlds",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601474686i/53733106.jpg",
                            Name = "No One Is Talking About This",
                            Price = 23.99m,
                            Slug = "no-one-is-talking-about-this"
                        },
                        new
                        {
                            Id = new Guid("928556ae-db47-4562-817b-a6474184b453"),
                            CategoryId = new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"),
                            Description = "A non-fiction book about the Sackler family and their role in the opioid crisis",
                            ImageUrl = "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1611952534i/43868109.jpg",
                            Name = "Empire of Pain",
                            Price = 26.99m,
                            Slug = "empire-of-pain"
                        },
                        new
                        {
                            Id = new Guid("2d2e8ba5-d0a0-4270-975a-f12a8793dd4e"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A drama film about a woman who embarks on a journey through the American West after the economic collapse of a company town",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/a/a5/Nomadland_poster.jpeg",
                            Name = "Nomadland",
                            Price = 14.99m,
                            Slug = "nomadland"
                        },
                        new
                        {
                            Id = new Guid("9ef00b7e-fb33-4416-9851-84273dd66f32"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A drama film about a Korean American family who moves to Arkansas in search of the American Dream",
                            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRO2Ubq5Jw9K26Yf2FIs5Hn4qAmBw9iN5f33KXfOS9-7SrDji-a",
                            Name = "Minari",
                            Price = 14.99m,
                            Slug = "minari"
                        },
                        new
                        {
                            Id = new Guid("687bd7fd-81ad-40af-a0da-bffa90e38981"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A historical legal drama film about the trial of seven defendants charged with conspiracy and inciting riots at the 1968 Democratic National Convention in Chicago",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpYXw7g_VNc6BgTpeO_teA9iFcaz56RNKE4yke-CfHLulmC4mC",
                            Name = "The Trial of the Chicago 7",
                            Price = 14.99m,
                            Slug = "the-trial-of-the-chicago-7"
                        },
                        new
                        {
                            Id = new Guid("7b6def5b-ea2f-4137-83a9-35c2e2d77e75"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A drama film about a recording session with Ma Rainey and her band in 1920s Chicago",
                            ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQbwaPsGL1aZVMgWOFxy3vTTEKm-Mdsqr4g5ZH_EOVLTXqVKOEU",
                            Name = "Ma Rainey's Black Bottom",
                            Price = 14.99m,
                            Slug = "ma-raineys-black-bottom"
                        },
                        new
                        {
                            Id = new Guid("32613c6e-d47a-4da8-879d-4da3a254f7b4"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A thriller film about a woman seeking revenge against those who wronged her best friend",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt0E2TEuop7cpx_XAPCUh0iWdoPBqk4ykJKCpfNGFwlwIf-yTx",
                            Name = "Promising Young Woman",
                            Price = 14.99m,
                            Slug = "promising-young-woman"
                        },
                        new
                        {
                            Id = new Guid("b7c080e4-b9ad-43d4-b8e2-2c32a36ff619"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A drama film about a heavy metal drummer who begins to lose his hearing",
                            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRBan44FQYlb0XJ-54n54uUojA9QxH7s6lhppT9mSsLOGRcSnai",
                            Name = "Sound of Metal",
                            Price = 14.99m,
                            Slug = "sound-of-metal"
                        },
                        new
                        {
                            Id = new Guid("df03fa58-2a70-4d22-8b23-5a892da95f53"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A drama film about a man with dementia and his daughter's struggles to care for him",
                            ImageUrl = "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRY6PkexuVznH6FEgo0by3HRofrGLE9cK6MoC2SiyZHponQb3oY",
                            Name = "The Father",
                            Price = 14.99m,
                            Slug = "the-father"
                        },
                        new
                        {
                            Id = new Guid("d58b23f8-83bf-459f-90ed-499301790e30"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "An animated film about a middle school music teacher who dreams of being a jazz musician",
                            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSWzrHSIZFXCrHAgxd2omcvTVB5jqPkmCVemT0XYPj-CWgRoMs_",
                            Name = "Soul",
                            Price = 14.99m,
                            Slug = "soul"
                        },
                        new
                        {
                            Id = new Guid("757b230b-5c00-4162-b279-e891a4f4f63b"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A war drama film about a group of Vietnam War veterans who return to the country in search of treasure and their fallen squad leader's remains",
                            ImageUrl = "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQ6Y8U3gK1QlfBmjVh_mx9-Ll_YzI3d6K2DQIMQQkUxLuew5K7N",
                            Name = "Da 5 Bloods",
                            Price = 14.99m,
                            Slug = "da-5-bloods"
                        },
                        new
                        {
                            Id = new Guid("dd8e8543-2098-49ec-b354-f83a37a23129"),
                            CategoryId = new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"),
                            Description = "A science fiction action film about a secret agent who must prevent World War III through time inversion",
                            ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4o4eBZdZWCR0iNFjiu1p4BKAIwIOkm_tZr3A-WUu4IAAcrq57",
                            Name = "Tenet",
                            Price = 14.99m,
                            Slug = "tenet"
                        },
                        new
                        {
                            Id = new Guid("09727bed-58b2-4af3-b294-b43693cac3d0"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "An open-world action-adventure game set in a post-apocalyptic Hyrule",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg",
                            Name = "The Legend of Zelda: Breath of the Wild",
                            Price = 59.99m,
                            Slug = "the-legend-of-zelda-breath-of-the-wild"
                        },
                        new
                        {
                            Id = new Guid("cc51d8fe-4850-4d1c-a63b-990c145c5916"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "An action game set in a post-apocalyptic world where the player must deliver supplies and build connections between isolated cities",
                            ImageUrl = "https://cdn1.epicgames.com/offer/0a9e3c5ab6684506bd624a849ca0cf39/EGS_DeathStrandingDirectorsCut_KOJIMAPRODUCTIONS_S4_1200x1600-5f99e16507795f9b497716b470cfd876",
                            Name = "Death Stranding",
                            Price = 49.99m,
                            Slug = "death-stranding"
                        },
                        new
                        {
                            Id = new Guid("a0b240f5-f29f-40e1-b349-59bb6103e1d1"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "A survival horror game set in a post-apocalyptic United States where the player must navigate through dangerous environments and fight off infected creatures and hostile human factions",
                            ImageUrl = "https://image.api.playstation.com/vulcan/img/rnd/202010/2618/w48z6bzefZPrRcJHc7L8SO66.png",
                            Name = "The Last of Us Part II",
                            Price = 59.99m,
                            Slug = "the-last-of-us-part-ii"
                        },
                        new
                        {
                            Id = new Guid("5d3bd681-f261-46ee-b2ad-ac191d3a50a7"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "An action-adventure game set in 13th century Japan where the player takes on the role of a samurai warrior fighting against invading Mongol forces",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg",
                            Name = "Ghost of Tsushima",
                            Price = 49.99m,
                            Slug = "ghost-of-tsushima"
                        },
                        new
                        {
                            Id = new Guid("52b7223f-72bf-4146-a59b-724b88f99b2c"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "A roguelike action game where the player takes on the role of Prince Zagreus attempting to escape from the underworld",
                            ImageUrl = "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpghttps://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpg",
                            Name = "Hades",
                            Price = 24.99m,
                            Slug = "hades"
                        },
                        new
                        {
                            Id = new Guid("e9b31795-bf04-45c4-9371-088515d54d4a"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "A life simulation game where the player moves to a deserted island and builds a community with anthropomorphic animals",
                            ImageUrl = "https://animal-crossing.com/new-horizons/assets/img/share-tw.jpg",
                            Name = "Animal Crossing: New Horizons",
                            Price = 59.99m,
                            Slug = "animal-crossing-new-horizons"
                        },
                        new
                        {
                            Id = new Guid("6a334a54-4aee-4410-91e2-2aa47b379f53"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "A first-person shooter game where the player takes on the role of the Doom Slayer and battles demons from hell",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/9/9d/Cover_Art_of_Doom_Eternal.png",
                            Name = "Doom Eternal",
                            Price = 59.99m,
                            Slug = "doom-eternal"
                        },
                        new
                        {
                            Id = new Guid("95d93c40-c142-47d0-8e33-d8998e0b4ead"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "A battle royale party game where the player competes with up to 60 players in various obstacle courses",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/5/5e/Fall_Guys_cover.jpg/220px-Fall_Guys_cover.jpg",
                            Name = "Fall Guys: Ultimate Knockout",
                            Price = 19.99m,
                            Slug = "fall-guys-ultimate-knockout"
                        },
                        new
                        {
                            Id = new Guid("6f91955f-f39e-4fae-abd9-08241cd08db5"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "An action-adventure game where the player takes on the role of Miles Morales as he becomes the new Spider-Man and fights crime in New York City",
                            ImageUrl = "https://image.api.playstation.com/vulcan/ap/rnd/202008/1020/T45iRN1bhiWcJUzST6UFGBvO.png",
                            Name = "Marvel's Spider-Man: Miles Morales",
                            Price = 49.99m,
                            Slug = "spider-man-miles-morales"
                        },
                        new
                        {
                            Id = new Guid("5773ad70-0a1f-43bb-b7cb-f158d1be8b8c"),
                            CategoryId = new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"),
                            Description = "An open-world role-playing game set in a dystopian future where the player takes on the role of a mercenary navigating through the criminal underworld of Night City",
                            ImageUrl = "https://upload.wikimedia.org/wikipedia/en/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg",
                            Name = "Cyberpunk 2077",
                            Price = 59.99m,
                            Slug = "cyberpunk-2077"
                        });
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Customer"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Security", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConfirmationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ConfirmationCodeExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("ConfirmationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ConfirmationTokenExpiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("NewEmailConfirmationCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Securities");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Session", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AccessToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsTfaEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Comment", b =>
                {
                    b.HasOne("CrossplatformHW.Server.Data.Entities.Product", "Product")
                        .WithMany("Comments")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrossplatformHW.Server.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Joints.RolePermission", b =>
                {
                    b.HasOne("CrossplatformHW.Server.Data.Entities.Permission", null)
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CrossplatformHW.Server.Data.Entities.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Product", b =>
                {
                    b.HasOne("CrossplatformHW.Server.Data.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Security", b =>
                {
                    b.HasOne("CrossplatformHW.Server.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Session", b =>
                {
                    b.HasOne("CrossplatformHW.Server.Data.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.User", b =>
                {
                    b.HasOne("CrossplatformHW.Server.Data.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("CrossplatformHW.Server.Data.Entities.Product", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}