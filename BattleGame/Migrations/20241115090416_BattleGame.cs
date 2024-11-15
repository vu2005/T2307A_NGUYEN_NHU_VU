using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BattleGame.Migrations
{
    /// <inheritdoc />
    public partial class BattleGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Assets",
                columns: table => new
                {
                    AssetId = table.Column<string>(type: "TEXT", nullable: false),
                    AssetName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    LevelRequire = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assets", x => x.AssetId);
                });

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    PlayerId = table.Column<string>(type: "TEXT", nullable: false),
                    PlayerName = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false),
                    FullName = table.Column<string>(type: "TEXT", maxLength: 128, nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: false),
                    Level = table.Column<int>(type: "INTEGER", nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.PlayerId);
                });

            migrationBuilder.CreateTable(
                name: "PlayerAssets",
                columns: table => new
                {
                    PlayerId = table.Column<string>(type: "TEXT", nullable: false),
                    AssetId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlayerAssets", x => new { x.PlayerId, x.AssetId });
                    table.ForeignKey(
                        name: "FK_PlayerAssets_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "AssetId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlayerAssets_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "PlayerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Assets",
                columns: new[] { "AssetId", "AssetName", "LevelRequire" },
                values: new object[,]
                {
                    { "1", "Sword of Light", 5 },
                    { "2", "Shield of Darkness", 3 },
                    { "3", "Potion of Health", 1 }
                });

            migrationBuilder.InsertData(
                table: "Players",
                columns: new[] { "PlayerId", "Age", "Email", "FullName", "Level", "PlayerName" },
                values: new object[,]
                {
                    { "1", 25, "alice@wonderland.com", "Alice Wonderland", 10, "Alice" },
                    { "2", 30, "bob@smith.com", "Robert Smith", 15, "Bob" },
                    { "3", 28, "charlie@chaplin.com", "Charles Chaplin", 8, "Charlie" }
                });

            migrationBuilder.InsertData(
                table: "PlayerAssets",
                columns: new[] { "AssetId", "PlayerId" },
                values: new object[,]
                {
                    { "1", "1" },
                    { "3", "1" },
                    { "2", "2" },
                    { "3", "3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PlayerAssets_AssetId",
                table: "PlayerAssets",
                column: "AssetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PlayerAssets");

            migrationBuilder.DropTable(
                name: "Assets");

            migrationBuilder.DropTable(
                name: "Players");
        }
    }
}
