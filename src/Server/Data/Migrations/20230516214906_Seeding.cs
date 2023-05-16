using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CrossplatformHW.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("09727bed-58b2-4af3-b294-b43693cac3d0"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("185d064c-2075-430a-8612-9b2ace4baf03"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2494e70f-2a91-4827-a519-98dee55adc0c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("292a12f7-e9fa-4ff5-bf57-ac59c20a7742"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2d2e8ba5-d0a0-4270-975a-f12a8793dd4e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("315071e2-36c9-4aeb-9a1b-7a97db38ecc6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("32613c6e-d47a-4da8-879d-4da3a254f7b4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4d66b4f7-37f6-403e-8772-ef55d1571ee2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("52b7223f-72bf-4146-a59b-724b88f99b2c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5773ad70-0a1f-43bb-b7cb-f158d1be8b8c"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5811bc19-776c-4c4b-8da6-7c6dd821f5a4"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("5d3bd681-f261-46ee-b2ad-ac191d3a50a7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("687bd7fd-81ad-40af-a0da-bffa90e38981"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a334a54-4aee-4410-91e2-2aa47b379f53"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6f91955f-f39e-4fae-abd9-08241cd08db5"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7050044f-dff0-46ad-934a-45eee7739871"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("757b230b-5c00-4162-b279-e891a4f4f63b"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("7b6def5b-ea2f-4137-83a9-35c2e2d77e75"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("8bb09c92-053a-40ba-be14-3fef88a6421f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("90fd17e3-9e47-46af-aa95-11f23bb016dd"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("928556ae-db47-4562-817b-a6474184b453"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("95d93c40-c142-47d0-8e33-d8998e0b4ead"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9ef00b7e-fb33-4416-9851-84273dd66f32"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("a0b240f5-f29f-40e1-b349-59bb6103e1d1"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("b7c080e4-b9ad-43d4-b8e2-2c32a36ff619"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("cc51d8fe-4850-4d1c-a63b-990c145c5916"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d58b23f8-83bf-459f-90ed-499301790e30"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dd8e8543-2098-49ec-b354-f83a37a23129"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("df03fa58-2a70-4d22-8b23-5a892da95f53"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("e9b31795-bf04-45c4-9371-088515d54d4a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("716b2a7e-d491-41a0-8fcc-2390fe65396a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("84e6439b-bdec-410b-a26d-0c37080e293c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9ac2f732-bdb1-41c6-9b1e-3d2103b7a525"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name", "Slug" },
                values: new object[,]
                {
                    { new Guid("235c4883-0358-40a4-8d59-b3020a9e19d4"), "Бізнес одяг", "business clothes" },
                    { new Guid("3b4c8f18-6a42-4f3c-97ae-6e07e9749d49"), "Пляжний одяг", "sand-clothes" },
                    { new Guid("58dceb53-774d-47d9-80ee-148a1fa89f8c"), "Спортивний одяг", "sport-clothes" },
                    { new Guid("be1289c1-b911-467f-91d0-56fee40eee56"), "Вечірній одяг", "evening-clothes" },
                    { new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"), "Звичайний одяг", "default-clothes" },
                    { new Guid("ed5af860-c2f2-443a-9d05-b32bc0c67bc1"), "Верхній одяг", "upper-clothes" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Description", "ImageUrl", "Name", "Price", "Slug" },
                values: new object[,]
                {
                    { new Guid("0d57c36c-1707-4e7e-9927-98d552188fdb"), new Guid("235c4883-0358-40a4-8d59-b3020a9e19d4"), "Краватка", "https://cdn.lbtq.io/productImage/resize/300x400_40cd750bba9870f18aada2478b24840a/20210810/160/20210810160317_005841155_1.jpg", "Краватка", 13.24m, "tie" },
                    { new Guid("14ca04e2-58ef-4b3a-922b-74a4dc400743"), new Guid("3b4c8f18-6a42-4f3c-97ae-6e07e9749d49"), "Купальник", "https://swimstore.by/assets/components/phpthumbof/cache/2a243-055-5.f93d8153e4bae606f1ec449a4d218fdc13.f93d8153e4bae606f1ec449a4d218fdc13.jpg", "Купальник", 17.99m, "swimmer" },
                    { new Guid("2cd7f405-ef1a-4705-ac2d-5a89526a3319"), new Guid("58dceb53-774d-47d9-80ee-148a1fa89f8c"), "Бігові кросівки", "https://hadi.ua/image/cache/catalog/asics/10/1014A226-101-1024x1024.jpg", "Бігові кросівки", 34.99m, "runners" },
                    { new Guid("4c479cb6-0959-4e51-963a-d95d08df9985"), new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"), "Світшот", "https://static.reserved.com/media/catalog/product/cache/1200/a4e40ebdc3e371adff845072e1c73f37/0/4/0401M-MLC-010-1_8.jpg", "Світшот", 16.49m, "sweatshirt" },
                    { new Guid("6a6d10e9-c3a6-4783-a3d5-a301f574d35f"), new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"), "Шорти", "https://burdastyle.ua/sites/default/files/models/burdastyle_shorty_na_kulisci_119_6_2020.jpg", "Шорти", 6.99m, "shorts" },
                    { new Guid("6c8e0b64-2b72-43ef-acbe-5b1931141bb6"), new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"), "Футболка", "https://static.athletics.kiev.ua/static/i/395_380/products/253314/22CpzFlU.jpeg", "Футболка", 5.99m, "tshirt" },
                    { new Guid("6e0ddc66-eff8-4b9b-a8e4-42632ade33f7"), new Guid("3b4c8f18-6a42-4f3c-97ae-6e07e9749d49"), "Парео", "https://cdn.shopify.com/s/files/1/0067/6446/2144/files/Blog_pictures_f2560263-5922-434e-8e2b-15c46544661e_600x600.jpg?v=1649677525", "Парео", 33.24m, "pareo" },
                    { new Guid("797d2da5-29ab-4fb0-a109-b92e4d5fba6e"), new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"), "Сорочка", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSzFHH6zjvPiqtNNOQldZCzVS8XUNYxl-OnY7jqg1E&s", "Сорочка", 7m, "shirt" },
                    { new Guid("903ff978-9b46-4663-9912-5db35459bedb"), new Guid("ed5af860-c2f2-443a-9d05-b32bc0c67bc1"), "Куртка", "https://borec.in.ua/5463-medium_default/kurtka-manto-winter-jacket-alpha.jpg", "Куртка", 25.99m, "jacket" },
                    { new Guid("9440d8bf-2eb7-45b0-86af-736e66d5b4ee"), new Guid("ed5af860-c2f2-443a-9d05-b32bc0c67bc1"), "Пальто", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQKTkDVuYPEshdgAbCOrhUGh-7Ey-eY-N9O3Q&usqp=CAU", "Пальто", 47.99m, "coat" },
                    { new Guid("d3638f75-bd86-4e1b-a1d7-ab7bf0b95237"), new Guid("235c4883-0358-40a4-8d59-b3020a9e19d4"), "Сорочка з манжетами", "https://soro4ka.com.ua/image/cache/catalog/Products/Sorochku/Astron/138692320238/138692320238-1-1000x1000.jpg", "Сорочка з манжетами", 26.67m, "cuffs" },
                    { new Guid("d7ac905f-20ef-4e64-aa6b-79d7c68746b2"), new Guid("be1289c1-b911-467f-91d0-56fee40eee56"), "Сукня", "https://foberini.com/image/cache/catalog/product/women/SS16/01067/01067%20site-cr-493x739.jpg", "Сукня", 33.29m, "dress" },
                    { new Guid("dbe1a199-3525-44d2-b515-6677242b3f61"), new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"), "Спідниця", "https://content.rozetka.com.ua/goods/images/big/32645949.jpg", "Спідниця", 11.5m, "skirt" },
                    { new Guid("fb92320b-8482-4e06-84b6-04073818ab9a"), new Guid("be1289c1-b911-467f-91d0-56fee40eee56"), "Смокінг", "https://images.prom.ua/1510914484_muzhskoj-smoking-west-fashion.jpg", "Смокінг", 87.99m, "tuxedo" },
                    { new Guid("fc990e54-c244-42c7-b274-cc85ab780c21"), new Guid("58dceb53-774d-47d9-80ee-148a1fa89f8c"), "Спортивні штани", "https://unimarket.com.ua/wp-content/uploads/2020/02/DJ-9404.jpg", "Спортивні штани", 87.99m, "sport-pants" },
                    { new Guid("fea1da48-32b3-4569-b678-86884356fe03"), new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"), "Джинси", "https://static.reserved.com/media/catalog/product/cache/1200/a4e40ebdc3e371adff845072e1c73f37/6/0/6048H-50J-010-1_13.jpg", "Джинси", 8.99m, "jeans" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("0d57c36c-1707-4e7e-9927-98d552188fdb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("14ca04e2-58ef-4b3a-922b-74a4dc400743"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("2cd7f405-ef1a-4705-ac2d-5a89526a3319"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("4c479cb6-0959-4e51-963a-d95d08df9985"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6a6d10e9-c3a6-4783-a3d5-a301f574d35f"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6c8e0b64-2b72-43ef-acbe-5b1931141bb6"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("6e0ddc66-eff8-4b9b-a8e4-42632ade33f7"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("797d2da5-29ab-4fb0-a109-b92e4d5fba6e"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("903ff978-9b46-4663-9912-5db35459bedb"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("9440d8bf-2eb7-45b0-86af-736e66d5b4ee"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d3638f75-bd86-4e1b-a1d7-ab7bf0b95237"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("d7ac905f-20ef-4e64-aa6b-79d7c68746b2"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("dbe1a199-3525-44d2-b515-6677242b3f61"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fb92320b-8482-4e06-84b6-04073818ab9a"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fc990e54-c244-42c7-b274-cc85ab780c21"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("fea1da48-32b3-4569-b678-86884356fe03"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("235c4883-0358-40a4-8d59-b3020a9e19d4"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("3b4c8f18-6a42-4f3c-97ae-6e07e9749d49"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58dceb53-774d-47d9-80ee-148a1fa89f8c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("be1289c1-b911-467f-91d0-56fee40eee56"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("e08829ac-71db-4982-86a9-b183e69b0e5a"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("ed5af860-c2f2-443a-9d05-b32bc0c67bc1"));

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
        }
    }
}
