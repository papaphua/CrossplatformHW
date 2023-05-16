using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrossplatformHW.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.PermissionId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegisterDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    IsTfaEnabled = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Securities",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationCodeExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    NewEmailConfirmationCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConfirmationTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Securities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Securities_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AccessToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "Books", "books" },
                    { new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "Movies", "movies" },
                    { new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "Video Games", "video-games" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CustomerPermission" },
                    { 2, "AdminPermission" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Customer" },
                    { 2, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Slug" },
                values: new object[,]
                {
                    { new Guid("09727bed-58b2-4af3-b294-b43693cac3d0"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "An open-world action-adventure game set in a post-apocalyptic Hyrule", "https://upload.wikimedia.org/wikipedia/en/c/c6/The_Legend_of_Zelda_Breath_of_the_Wild.jpg", "The Legend of Zelda: Breath of the Wild", 59.99m, "the-legend-of-zelda-breath-of-the-wild" },
                    { new Guid("185d064c-2075-430a-8612-9b2ace4baf03"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A novel about the intersection of the digital and real worlds", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601474686i/53733106.jpg", "No One Is Talking About This", 23.99m, "no-one-is-talking-about-this" },
                    { new Guid("2494e70f-2a91-4827-a519-98dee55adc0c"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A thriller about a detective investigating a murder at an isolated hotel in the Swiss Alps", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1612344489i/56935099.jpg", "The Sanatorium", 19.99m, "the-sanatorium" },
                    { new Guid("292a12f7-e9fa-4ff5-bf57-ac59c20a7742"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A novel about a woman's journey through the Dust Bowl era of the 1930s", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1594925043i/53138081.jpg", "The Four Winds", 25.99m, "the-four-winds" },
                    { new Guid("2d2e8ba5-d0a0-4270-975a-f12a8793dd4e"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A drama film about a woman who embarks on a journey through the American West after the economic collapse of a company town", "https://upload.wikimedia.org/wikipedia/en/a/a5/Nomadland_poster.jpeg", "Nomadland", 14.99m, "nomadland" },
                    { new Guid("315071e2-36c9-4aeb-9a1b-7a97db38ecc6"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A novel about a robot who observes the world and learns about human behavior", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1603206535i/54120408.jpg", "Klara and the Sun", 27.99m, "klara-and-the-sun" },
                    { new Guid("32613c6e-d47a-4da8-879d-4da3a254f7b4"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A thriller film about a woman seeking revenge against those who wronged her best friend", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRt0E2TEuop7cpx_XAPCUh0iWdoPBqk4ykJKCpfNGFwlwIf-yTx", "Promising Young Woman", 14.99m, "promising-young-woman" },
                    { new Guid("4d66b4f7-37f6-403e-8772-ef55d1571ee2"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A novel about a woman who finds herself in a library between life and death, with the opportunity to try out different versions of her life", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1602190253i/52578297.jpg", "The Midnight Library", 21.99m, "the-midnight-library" },
                    { new Guid("52b7223f-72bf-4146-a59b-724b88f99b2c"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "A roguelike action game where the player takes on the role of Prince Zagreus attempting to escape from the underworld", "https://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpghttps://m.media-amazon.com/images/W/IMAGERENDERING_521856-T1/images/I/71FjVhf-SlL._AC_UF894,1000_QL80_.jpg", "Hades", 24.99m, "hades" },
                    { new Guid("5773ad70-0a1f-43bb-b7cb-f158d1be8b8c"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "An open-world role-playing game set in a dystopian future where the player takes on the role of a mercenary navigating through the criminal underworld of Night City", "https://upload.wikimedia.org/wikipedia/en/thumb/9/9f/Cyberpunk_2077_box_art.jpg/220px-Cyberpunk_2077_box_art.jpg", "Cyberpunk 2077", 59.99m, "cyberpunk-2077" },
                    { new Guid("5811bc19-776c-4c4b-8da6-7c6dd821f5a4"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A memoir about a woman's relationship with her Korean mother and the grieving process after her mother's death", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1601937850i/54814676.jpg", "Crying in H Mart", 22.99m, "crying-in-h-mart" },
                    { new Guid("5d3bd681-f261-46ee-b2ad-ac191d3a50a7"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "An action-adventure game set in 13th century Japan where the player takes on the role of a samurai warrior fighting against invading Mongol forces", "https://upload.wikimedia.org/wikipedia/en/b/b6/Ghost_of_Tsushima.jpg", "Ghost of Tsushima", 49.99m, "ghost-of-tsushima" },
                    { new Guid("687bd7fd-81ad-40af-a0da-bffa90e38981"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A historical legal drama film about the trial of seven defendants charged with conspiracy and inciting riots at the 1968 Democratic National Convention in Chicago", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQpYXw7g_VNc6BgTpeO_teA9iFcaz56RNKE4yke-CfHLulmC4mC", "The Trial of the Chicago 7", 14.99m, "the-trial-of-the-chicago-7" },
                    { new Guid("6a334a54-4aee-4410-91e2-2aa47b379f53"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "A first-person shooter game where the player takes on the role of the Doom Slayer and battles demons from hell", "https://upload.wikimedia.org/wikipedia/en/9/9d/Cover_Art_of_Doom_Eternal.png", "Doom Eternal", 59.99m, "doom-eternal" },
                    { new Guid("6f91955f-f39e-4fae-abd9-08241cd08db5"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "An action-adventure game where the player takes on the role of Miles Morales as he becomes the new Spider-Man and fights crime in New York City", "https://image.api.playstation.com/vulcan/ap/rnd/202008/1020/T45iRN1bhiWcJUzST6UFGBvO.png", "Marvel's Spider-Man: Miles Morales", 49.99m, "spider-man-miles-morales" },
                    { new Guid("7050044f-dff0-46ad-934a-45eee7739871"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A novel about a man on a solo mission to save the world from extinction", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1597695864i/54493401.jpg", "Project Hail Mary", 24.99m, "project-hail-mary" },
                    { new Guid("757b230b-5c00-4162-b279-e891a4f4f63b"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A war drama film about a group of Vietnam War veterans who return to the country in search of treasure and their fallen squad leader's remains", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcQ6Y8U3gK1QlfBmjVh_mx9-Ll_YzI3d6K2DQIMQQkUxLuew5K7N", "Da 5 Bloods", 14.99m, "da-5-bloods" },
                    { new Guid("7b6def5b-ea2f-4137-83a9-35c2e2d77e75"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A drama film about a recording session with Ma Rainey and her band in 1920s Chicago", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcQbwaPsGL1aZVMgWOFxy3vTTEKm-Mdsqr4g5ZH_EOVLTXqVKOEU", "Ma Rainey's Black Bottom", 14.99m, "ma-raineys-black-bottom" },
                    { new Guid("8bb09c92-053a-40ba-be14-3fef88a6421f"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A non-fiction book about the woman who helped develop CRISPR gene-editing technology", "https://m.media-amazon.com/images/I/41an9tLSfBL._SX327_BO1,204,203,200_.jpg", "The Code Breaker", 28.99m, "the-code-breaker" },
                    { new Guid("90fd17e3-9e47-46af-aa95-11f23bb016dd"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A novel about a mother's intense desire for perfection and the consequences of her actions", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1609854219i/52476830.jpg", "The Push", 20.99m, "the-push" },
                    { new Guid("928556ae-db47-4562-817b-a6474184b453"), new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"), "A non-fiction book about the Sackler family and their role in the opioid crisis", "https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1611952534i/43868109.jpg", "Empire of Pain", 26.99m, "empire-of-pain" },
                    { new Guid("95d93c40-c142-47d0-8e33-d8998e0b4ead"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "A battle royale party game where the player competes with up to 60 players in various obstacle courses", "https://upload.wikimedia.org/wikipedia/en/thumb/5/5e/Fall_Guys_cover.jpg/220px-Fall_Guys_cover.jpg", "Fall Guys: Ultimate Knockout", 19.99m, "fall-guys-ultimate-knockout" },
                    { new Guid("9ef00b7e-fb33-4416-9851-84273dd66f32"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A drama film about a Korean American family who moves to Arkansas in search of the American Dream", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRO2Ubq5Jw9K26Yf2FIs5Hn4qAmBw9iN5f33KXfOS9-7SrDji-a", "Minari", 14.99m, "minari" },
                    { new Guid("a0b240f5-f29f-40e1-b349-59bb6103e1d1"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "A survival horror game set in a post-apocalyptic United States where the player must navigate through dangerous environments and fight off infected creatures and hostile human factions", "https://image.api.playstation.com/vulcan/img/rnd/202010/2618/w48z6bzefZPrRcJHc7L8SO66.png", "The Last of Us Part II", 59.99m, "the-last-of-us-part-ii" },
                    { new Guid("b7c080e4-b9ad-43d4-b8e2-2c32a36ff619"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A drama film about a heavy metal drummer who begins to lose his hearing", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcRBan44FQYlb0XJ-54n54uUojA9QxH7s6lhppT9mSsLOGRcSnai", "Sound of Metal", 14.99m, "sound-of-metal" },
                    { new Guid("cc51d8fe-4850-4d1c-a63b-990c145c5916"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "An action game set in a post-apocalyptic world where the player must deliver supplies and build connections between isolated cities", "https://cdn1.epicgames.com/offer/0a9e3c5ab6684506bd624a849ca0cf39/EGS_DeathStrandingDirectorsCut_KOJIMAPRODUCTIONS_S4_1200x1600-5f99e16507795f9b497716b470cfd876", "Death Stranding", 49.99m, "death-stranding" },
                    { new Guid("d58b23f8-83bf-459f-90ed-499301790e30"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "An animated film about a middle school music teacher who dreams of being a jazz musician", "https://encrypted-tbn1.gstatic.com/images?q=tbn:ANd9GcSWzrHSIZFXCrHAgxd2omcvTVB5jqPkmCVemT0XYPj-CWgRoMs_", "Soul", 14.99m, "soul" },
                    { new Guid("dd8e8543-2098-49ec-b354-f83a37a23129"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A science fiction action film about a secret agent who must prevent World War III through time inversion", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcR4o4eBZdZWCR0iNFjiu1p4BKAIwIOkm_tZr3A-WUu4IAAcrq57", "Tenet", 14.99m, "tenet" },
                    { new Guid("df03fa58-2a70-4d22-8b23-5a892da95f53"), new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"), "A drama film about a man with dementia and his daughter's struggles to care for him", "https://encrypted-tbn3.gstatic.com/images?q=tbn:ANd9GcRY6PkexuVznH6FEgo0by3HRofrGLE9cK6MoC2SiyZHponQb3oY", "The Father", 14.99m, "the-father" },
                    { new Guid("e9b31795-bf04-45c4-9371-088515d54d4a"), new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"), "A life simulation game where the player moves to a deserted island and builds a community with anthropomorphic animals", "https://animal-crossing.com/new-horizons/assets/img/share-tw.jpg", "Animal Crossing: New Horizons", 59.99m, "animal-crossing-new-horizons" }
                });

            migrationBuilder.InsertData(
                table: "RolePermissions",
                columns: new[] { "PermissionId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ProductId",
                table: "Comments",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Securities_UserId",
                table: "Securities",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Securities");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
