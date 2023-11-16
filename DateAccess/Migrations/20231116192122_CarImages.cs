using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DateAccess.Migrations
{
    public partial class CarImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthDay = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdCar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalPrice = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelCar = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ColorCar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: true),
                    Discription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quantity = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Storage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storage_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "BMW" },
                    { 2, "Toyota" },
                    { 3, "Citroen" },
                    { 4, "Renault" },
                    { 5, "Peugeot" }
                });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "CategoryId", "ColorCar", "Discription", "ImagePath", "ModelCar", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, 1, "Black", "Розгінна динаміка (0-100 км / год), сек.	3,9\nМаксимальна швидкість, км / год	225\nПотужність двигуна, к.с.	544", "BMW_i4_M50.jpg", "BMW i4 M50", 2902760, 7 },
                    { 2, 1, "Blue", "Розгінна динаміка (0-100 км / год), сек.	3,9\nМаксимальна швидкість, км / год	225\nПотужність двигуна, к.с.	544", "bmw-i4-m50-blue.jpg", "BMW i4 M50", 2942351, 7 },
                    { 3, 1, "Grey", "Розгінна динаміка (0-100 км / год), сек.	3,9\nМаксимальна швидкість, км / год	225\nПотужність двигуна, к.с.	544", "bmw-i4-m50-grey.jpg", "BMW i4 M50", 2964435, 13 },
                    { 4, 1, "Black", "Розгінна динаміка (0-100 км / год), сек.	6,8\nМаксимальна швидкість, км / год	180\nПотужність двигуна, к.с.	210 (286)", "bmw-ix3-m-sport-black.jpg", "BMW iX3 M Sport", 2504303, 32 },
                    { 5, 2, "Red", "Highlander отримав гібридну силову установку четвертого покоління, яка дозволяє вам насолоджуватися усіма перевагами великого кросовера без шкоди для його потужності та екологічності. Завдяки 2,5-літровому гібридному двигуну Hybrid Dynamic Force потужністю 248 к. с. Highlander пропонує провідний у своєму класі баланс потужності та ефективності.", "gold-car.png", "Toyota Highlander Hybrid", 888282, 100 },
                    { 6, 2, "Gold", "Завдяки переконливому кліренсу та високій посадці за кермом компактний Yaris Cross надає упевненості при русі містом. Насолоджуйтеся подорожжю із сучасними функціями комфорту та містким салоном, що відповідає повсякденним потребам.", "gold-car.png", "Yaris Cross", 1058322, 12 },
                    { 7, 2, "Grey", "У 2006 році назві Corolla виповнилося 40 років, протягом яких змінилося десять поколінь цих доступних і надійних автомобілів, а загальний обсяг випуску перевалив за 32 мільйонів. І ця рекордна цифра продажів, занесена до Книги рекордів Гіннесса, збільшується щорічно.", "white-car.png", "Corola", 757620, 4 },
                    { 8, 3, "Red", "Нові Citroën C4 та ë-C4 з високим дорожнім просвітом, великими колесами та зручними розмірами виглядають готовими до будь-яких випробувань. Вони не тільки місткі, але й аеродинамічні.", "Qwiqlu-car.jpg", "C4 & Ë-C4", 1018300, 2 },
                    { 9, 3, "Grey", "Новий плагін-гібрид Citroën C5 Aircross, що підходить для будь-яких щоденних поїздок, пропонує плавний і динамічний рух із потужністю 180 к.с. із двигуном внутрішнього згоряння й електродвигуном на 81,2 кВт (110 к.с.) із загальною потужністю 225 к.с. й обертальним моментом 360 Н-м.", "Citroen-C5-Aircross.jpg", "CITROEN C5 AIRCROSS", 1018300, 0 },
                    { 10, 4, "Orange", "Надійний та перевірений часом і досвідом повний привод залишається головною перевагою оновленого Renault Duster. Завдяки зручним режимам роботи 2WD, AUTO або 4WD LOCK кожен водій може приборкати бездоріжжя. Повноприводний новий Renault Duster 4x4 можна купити як з бензиновим атмосферним, так і з дизельним турбо двигуном.", "Orange.jpg", "DUSTER", 1018300, 1 },
                    { 11, 4, "Blue", "Новий Renault EXPRESS поєднав у собі фірмові характеристики Renault, які підкреслять ваш смак та педантичність вибору. Ви пишатиметесь своїм Express: виразна передня частина із широким капотом, хромована радіаторна решітка, фірмові денні світлодіодні ліхтарі тощо. Саме цей достойний силует без зайвих деталей надійно супроводжуватиме вас у щоденних справах!", "Blue-Silver.jpg", "RENAULT EXPRESS", 1100300, 3 },
                    { 12, 5, "Blue", "Вражаюча форма нового PEUGEOT 408 характеризується динамічною натхненною позицією фастбеку. Сучасна елегантність фастбеку виділяє його на дорозі. Завдяки підвищеному дорожньому просвіту, але водночас помірній висоті, його спортивний дизайн і плавні лінії підкреслюють його аеродинамічні властивості. ", "CarCar.jpg", "PEUGEOT 408", 1000000, 5 },
                    { 13, 5, "White", "Вражаюча форма нового PEUGEOT 408 характеризується динамічною натхненною позицією фастбеку. Сучасна елегантність фастбеку виділяє його на дорозі. Завдяки підвищеному дорожньому просвіту, але водночас помірній висоті, його спортивний дизайн і плавні лінії підкреслюють його аеродинамічні властивості. Відкрийте для себе технологічний кросовер PEUGEOT 3008 з його інноваційним та натхненним дизайном, який підносить вишуканість на ще вищий рівень, більш елегантний та футуристичний. Його виразні лінії кузова поєднують силу, динаміку та плавність. Для підвищення рівня Вашого комфорту та безпеки було впроваджено низку новаторських технологій та розроблено: сучасний, вдосконалений та просторий салон PEUGEOT 3008 з концепцією організації простору водія PEUGEOT i-Cockpit.", "Run.jpg", "PEUGEOT 3008 ", 970000, 2 },
                    { 14, 5, "White", "Відкрийте для себе PEUGEOT 2008 або електрокросовер PEUGEOT 2008: компактний, потужний, динамічний та економічний кросовер.\r\nНасолоджуйтесь динамікою під час руху за рахунок сучаних технологій, які забезпечують тишу та комфорт в салоні автомобіля.", "OrangeCar.jpg", "PEUGEOT 2008", 1370000, 3 }
                });

            migrationBuilder.InsertData(
                table: "Storage",
                columns: new[] { "Id", "CarId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 5 },
                    { 6, 6 },
                    { 7, 7 },
                    { 8, 8 },
                    { 9, 9 },
                    { 10, 10 },
                    { 11, 11 },
                    { 12, 12 },
                    { 13, 13 },
                    { 14, 14 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cars_CategoryId",
                table: "Cars",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AppUserId",
                table: "Orders",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Storage_CarId",
                table: "Storage",
                column: "CarId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Storage");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
