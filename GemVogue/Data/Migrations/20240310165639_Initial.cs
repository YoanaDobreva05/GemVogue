using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GemVogue.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
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
                name: "Jewelry",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jewelry", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jewelry_Brands_BrandId",
                        column: x => x.BrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Favorites",
                columns: table => new
                {
                    JewelId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorites", x => new { x.JewelId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Favorites_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Favorites_Jewelry_JewelId",
                        column: x => x.JewelId,
                        principalTable: "Jewelry",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8e4b72d1-a0cf-43c7-837a-22543f3c1745", "8e4b72d1-a0cf-43c7-837a-22543f3c1745", "Administrator", "ADMINISTRATOR" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "41dde345-cc88-41c1-89c2-44ff9c7bd729", 0, "302d3a19-b866-474b-b8f7-e51ade3ffada", "admin@gemvogue.com", true, false, null, "Администратор", "ADMIN@GEMVOGUE.COM", "ADMIN@GEMVOGUE.COM", "AQAAAAIAAYagAAAAEONjC2iuMmYnHW3ud0vQ9xjxeXoWlKEcduWzb3Ivx4Bh65riAM1MmXrDaX6Ci87v7A==", null, false, "1125a5fa-7672-4313-b267-fd4f619a2afa", false, "admin@gemvogue.com" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "Магазина предлага изключителна селекция висококачествени бижута от подбрани колекции за да удовлетворим нуждите на тези, които вярват, че бижутата не са просто аксесоар. При нас всеки може да намери перфектното бижу,с което да зарадва себе си, да изненада любим човек или да впечатли с подарък, който ще привлече погледите на всички.Освен сертификат за автентичност можете да видите знака ALE щампован на нашите бижута, с изключение само на най-малките ни елементи. Еквивалентът във Великобритания е знакът на спонсора, а в Дания – знак на отговорност.Нашето стерлингово сребро е маркирано с главно S за сребро, последвано от чистотата на среброто, която е цитирана като единици чисто сребро на хиляда: S925 (92.5% чисто сребро).", "\\Images\\pandora-logo.png", "Pandora" },
                    { 2, "Официалните бижутата са подходящи за различни поводи, като сватби, юбилеи, балове, приеми и други. Можете да избирате между разнообразие от модели и стилове, които отговарят на вашите предпочитания и тоалет. Независимо дали предпочитате класически или модерни дизайни, бижутата Victoria Princess ще ви очароват със своята красота и изящество.Официалните бижута са не само прекрасен аксесоар, но и ценен подарък за любим човек. Ако искате да изненадате вашата половинка, майка, сестра или приятелка с нещо специално, можете да изберете бижу от нашата колекцията, което ще говори вместо вас за вашите чувства и уважение. Бижутата Victoria Princess са символ на любов, приятелство и лоялност.", "\\Images\\victoria princess-logo.png", "Victoria Princess" },
                    { 3, "GOTO порасна, отвори магазин и в Испания, а с годините се превърна в наложена марка, символ на разнообразие, качество и класа, на която повече от 20 000 лоялни клиенти се довериха. Огромна привилегия и чест, носеща със себе си сериозна отговорност. Тя ни задължава да продължаваме да се усъвършенстваме, за да сбъднем нашата мисия и най-голяма мечта – името на GOTO да се свързва с любовта, обичта и топлия спомен, облечени в качество и стил на световно ниво.", "\\Images\\goto-logo.jpg", "Goto" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e4b72d1-a0cf-43c7-837a-22543f3c1745", "41dde345-cc88-41c1-89c2-44ff9c7bd729" });

            migrationBuilder.InsertData(
                table: "Jewelry",
                columns: new[] { "Id", "BrandId", "CreatedOn", "Description", "ImageUrl", "Material", "Name", "Type" },
                values: new object[,]
                {
                    { 1, 3, new DateTime(2024, 3, 10, 18, 56, 38, 380, DateTimeKind.Local).AddTicks(8716), "Сребърно колие с Феникс.Феникса е символ на унищожаване на старият и начало на новият по-добър живот.Размер на синджира: с регулиране от 42 до 45 смРазмер на феникса: 22x20 мм", "\\Images\\kolie-feniks.jpg", "Материал: Сребро, Камъни: кристали цирконийКарат: 925.0", "Колие Феникс", 1 },
                    { 2, 1, new DateTime(2024, 3, 10, 18, 56, 38, 380, DateTimeKind.Local).AddTicks(8766), "Сребърен пръстен с изключително рядка зелена разновидност на скъпоценният камък Аметист.Произход на камъка Бразилия.Вярва се, че бижутата от аметист помагат на притежателя си да очарова хората около себе си, като засилва харизматичното му излъчване.Размер на камъка: 8x6 мм, 2,3 cм", "\\Images\\prsten-ss-zelen-ametist.jpg", "Материал: СреброКамъни: скъпоценен камък зелен АметистКарат: 925.0", "Пръстен със зелен аметист", 2 },
                    { 3, 1, new DateTime(2024, 3, 10, 18, 56, 38, 380, DateTimeKind.Local).AddTicks(8769), "Гривна Pandora Moments Звездопад.Този продукт е съвместим само с модели от колекция Pandora MomentsКарат: 925.0", "\\Images\\grivna-zvezdopdad.png", "Материал :СреброКамъни: Кубичен цирконий, КристалКарат: 925.0", "Гривна Звездопад", 3 },
                    { 4, 1, new DateTime(2024, 3, 10, 18, 56, 38, 380, DateTimeKind.Local).AddTicks(8774), "Обеци Game of Thrones x Pandora Домът на дракона", "\\Images\\domut-na-drakona.png", "Материал :СреброКамъни:КристалКарат: 925.0", " Домът на дракона", 4 },
                    { 5, 2, new DateTime(2024, 3, 10, 18, 56, 38, 380, DateTimeKind.Local).AddTicks(8776), "Дамски сребърен пръстен с 18К бяла позлата и създадени диаманти и сапфир.", "\\Images\\srebaren-prusten-sudadenid-sapfir.jpeg", "Материал:СреброКамъни: Създаден диамант, Създадени Скъпоценни Камъни.Карат: 925.0", "Сребърен пръстен с диаманти от сапфир", 2 },
                    { 6, 1, new DateTime(2024, 3, 10, 18, 56, 38, 380, DateTimeKind.Local).AddTicks(8779), " Сребърна дамска гривна за крак-класически стил.", "\\Images\\damska-grivna-za-krak.jpeg", "Материал: СреброКарат: 925.0", "Дамска гривна за крак", 3 }
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
                name: "IX_Favorites_UserId",
                table: "Favorites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Jewelry_BrandId",
                table: "Jewelry",
                column: "BrandId");
        }

        /// <inheritdoc />
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
                name: "Favorites");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Jewelry");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
