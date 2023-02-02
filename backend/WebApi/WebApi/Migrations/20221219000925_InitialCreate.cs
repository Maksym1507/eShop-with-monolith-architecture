using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "EntityFrameworkHiLoSequence",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "money", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Consist = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Index = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "date", nullable: false),
                    TotalSum = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Total = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 1, "pizza" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CategoryName" },
                values: new object[] { 2, "roll" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "Consist", "Img", "Price", "Title", "Weight" },
                values: new object[,]
                {
                    { 1, 1, "mozzarella, mushrooms, salami, pesto sauce, tomato sauce, oregano", "https://roll-club.kh.ua/wp-content/uploads/2021/04/svjatoi-diablo-1.jpg.webp", 245m, "Pizza Saint Diablo", 870.0 },
                    { 2, 1, "Pepperoni, hunting sausages, feta, olives, sriracha, mozzarella, oregano, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2014/08/pepperoni.jpg.webp", 235m, "Pepperoni", 800.0 },
                    { 3, 1, "mozzarella, hunting sausages, bacon, boiled pork, blue onion, tomato sauce, parsley, oregano", "https://roll-club.kh.ua/wp-content/uploads/2014/08/mjasnoj-bum.jpg.webp", 245m, "Pizza Boom of meat", 850.0 },
                    { 4, 1, "mozzarella, chicken fillet, hunting sausages, champignons, parsley, ham, tomato sauce, oregano", "https://roll-club.kh.ua/wp-content/uploads/2014/08/evropejskaja.jpg.webp", 149m, "European", 550.0 },
                    { 5, 1, "mozzarella, salmon, mussels, squid, tomato, lemon, pesto, oregano, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2014/08/dary-morja.jpg.webp", 229m, "Seafood", 550.0 },
                    { 6, 1, "mozzarella, ham, olives, tomatoes, parsley, mushrooms, oregano, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2015/09/vechtchina-griby.jpg.webp", 239m, "Pizza with ham and mushrooms", 900.0 },
                    { 7, 1, "mozzarella, pineapple, chicken fillet, oregano, parsley, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2014/08/tropikano-1.jpg.webp", 285m, "Pizza Life", 900.0 },
                    { 8, 1, "Feta, mozzarella, broccoli, olives, olives, bell peppers, tomatoes, mars onion, oregano, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2021/04/vegetarianskaja-nju.jpg.webp", 159m, "Vegetarian", 550.0 },
                    { 9, 1, "mozzarella, boiled pork, salami, hunting sausages, ham, bacon, olives, oregano, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2014/08/sbornaja-mjasnaja.jpg.webp", 245m, "Team Meat", 850.0 },
                    { 10, 1, "mozzarella, dorblu cheese, parmesan, hard cheese, bechamel sauce, oregano", "https://roll-club.kh.ua/wp-content/uploads/2015/09/4-syra.jpg.webp", 210m, "4 Cheeses", 450.0 },
                    { 11, 1, "ham, salami, Parmesan cheese, hard cheese, mozzarella, Dorblu cheese, mushrooms, tomatoes, Bechamel sauce, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/09/2-dabl-panch-169-245-grn.jpg.webp", 169m, "Double Punch", 500.0 },
                    { 12, 1, "Veal sous-vide, salami, hunting sausages, chicken fillet, Dorblu cheese, parmesan, mozzarella, hard cheese, oregano, tomato sauce", "https://roll-club.kh.ua/wp-content/uploads/2021/04/4-mjasa-1.jpg.webp", 240m, "4 Meats", 750.0 },
                    { 13, 2, "butter, takuan, cucumber, bell pepper, mayonnaise", "https://roll-club.kh.ua/wp-content/uploads/2022/09/134-vilnii-165.jpg.webp", 165m, "Free", 230.0 },
                    { 14, 2, "salmon, shrimps, cream cheese, cucumber, spice sauce, batter, panko crackers", "https://roll-club.kh.ua/wp-content/uploads/2022/09/127-krevetkovi-kulki-199.jpg.webp", 199m, "Shrimp Balls", 240.0 },
                    { 15, 2, "smoked chicken, cream cheese, pineapple, mayonnaise, cheddar cheese, unagi sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/09/102-gavaiskii-159-grn.jpg.webp", 159m, "Hawaiian", 290.0 },
                    { 16, 2, "smoked salmon, chuka, cucumber, bell pepper, iceberg lettuce, cheddar cheese, spice sauce, french onion", "https://roll-club.kh.ua/wp-content/uploads/2022/09/93-spring-fish-165-grn.jpg.webp", 165m, "Spring Fish", 200.0 },
                    { 17, 2, "cocktail shrimp, salmon, takuan, pumpkin, cream cheese, batter, panko crackers, spice sauce, unagi sauce, peanuts", "https://roll-club.kh.ua/wp-content/uploads/2022/09/50-unagi-kranch-219-grn.jpg.webp", 219m, "Unagi Crunch", 300.0 },
                    { 18, 2, "panko shrimp, eel, salmon, tuna, tiger shrimp, cream cheese, iceberg lettuce, scrambled eggs, spice sauce, unagi sauce, nachos", "https://roll-club.kh.ua/wp-content/uploads/2022/09/57-4-ribi-275-grn-ot-shefa.jpg.webp", 275m, "4 Fishes", 300.0 },
                    { 19, 2, "salmon, takuan, scrambled eggs, nachos, mayonnaise, cheddar cheese, unag sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/09/68-losos-na-grili-225-grn.jpg.webp", 225m, "Grilled Salmon", 300.0 },
                    { 20, 2, "pumpkin, takuan, chuka, bell pepper, cream cheese", "https://roll-club.kh.ua/wp-content/uploads/2022/09/134-vilnii-165.jpg.webp", 119m, "Vegetus", 220.0 },
                    { 21, 2, "salmon, snow crab, cream cheese, cucumber, scrambled eggs, tempura, panko crackers, spice sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/06/2-vulkan-900h600.jpg.webp", 185m, "Volcano", 290.0 },
                    { 22, 2, "cream cheese, salmon sous-vide, pink salmon, butterfish, cucumber, panko crackers, green onion, tempura, spice sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/06/kopchenyj-losos-900h600-2.jpg.webp", 225m, "Tempura Mix Fish", 280.0 },
                    { 23, 2, "unagi perch, cream cheese, cucumber, unagi sauce, spice sauce", "https://roll-club.kh.ua/wp-content/uploads/2021/12/unagi-grin.jpg.webp", 145m, "Philadelphia Unagi Green", 225.0 },
                    { 24, 2, "salmon, cream cheese, pear, cheddar cheese, mayonnaise, sriracha sauce, unagi sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/09/zapechena-filadelfija-nova-2.jpg.webp", 159m, "Baked Philadelphia", 260.0 },
                    { 25, 2, "smoked salmon, scrambled eggs, toaster cheese, cream cheese, cucumber, spice sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/06/3-dabl-chiz-900h600.jpg.webp", 179m, "Double Cheese", 235.0 },
                    { 26, 2, "chicken, cream cheese, pear, cheddar cheese, mayonnaise, sesame, french onion, sriracha sauce, unagi sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/08/zapechennaja-kurochka-grusha.jpg.webp", 159m, "Baked Chicken Pear", 310.0 },
                    { 27, 2, "unagi perch, salmon, cream cheese, panko crackers, tempura batter, unagi sauce", "https://roll-club.kh.ua/wp-content/uploads/2016/02/unagi-tempura-2.jpg.webp", 185m, "Unagi Tempura", 280.0 },
                    { 28, 2, "salmon, cream cheese, scrambled eggs, cheddar cheese, mayonnaise, sesame, sriracha sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/08/zapechennyj-losos.jpg.webp", 199m, "Baked Salmon", 290.0 },
                    { 29, 2, "salmon sous-vide, bell pepper, cucumber, cream cheese, Cheddar cheese, spice sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/08/bayraktar-new.jpg.webp", 155m, "Bayraktar", 210.0 },
                    { 30, 2, "salmon, cream cheese, avocado, cucumber", "https://roll-club.kh.ua/wp-content/uploads/2021/01/filadelfiya-xl.jpg.webp", 225m, "Philadelphia XL", 310.0 },
                    { 31, 2, "salmon, snow crab, cucumber, takuan, campio, cream cheese, sauce", "https://roll-club.kh.ua/wp-content/uploads/2022/06/11-jamamoto-900h600-1.jpg.webp", 275m, "Yamamoto", 305.0 },
                    { 32, 2, "unagi perch, cream cheese, cucumber, unagi sauce, sesame", "https://roll-club.kh.ua/wp-content/uploads/2021/12/unagi-lajt.jpg.webp", 149m, "Philadelphia Unagi Light", 210.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_OrderId",
                table: "OrderProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropSequence(
                name: "EntityFrameworkHiLoSequence");
        }
    }
}
