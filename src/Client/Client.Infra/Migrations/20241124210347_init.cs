using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Client.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Key = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    AppSettingType = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DownloadQueues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadQueues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FileTypeGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    FileExtensions = table.Column<string>(type: "TEXT", nullable: true),
                    IconName = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    SavePath = table.Column<string>(type: "TEXT", nullable: false),
                    FolderName = table.Column<string>(type: "TEXT", nullable: true),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTypeGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryGroupId = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryItems_CategoryGroups_CategoryGroupId",
                        column: x => x.CategoryGroupId,
                        principalTable: "CategoryGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FileTypeGroups",
                columns: new[] { "Id", "Created", "FileExtensions", "FolderName", "IconName", "IsDeleted", "SavePath", "Title", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2033), "zip rar", "Compressed", null, false, "C:\\Users\\Sattec\\Downloads\\Compressed", "فایل های فشرده", new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2044) },
                    { 2, new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2237), "txt docx xls", "Documents", null, false, "C:\\Users\\Sattec\\Downloads\\Documents", "اسناد", new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2238) },
                    { 3, new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2255), "mp3 wave", "Music", null, false, "C:\\Users\\Sattec\\Downloads\\Music", "موسیقی", new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2255) },
                    { 4, new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2268), "exe msi", "Video", null, false, "C:\\Users\\Sattec\\Downloads\\Video", "برنامه ها", new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2269) },
                    { 5, new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2281), "mpeg 3gp avi flv", "Compressed", null, false, "C:\\Users\\Sattec\\Downloads\\Compressed", "تصویری", new DateTime(2024, 11, 25, 0, 33, 46, 328, DateTimeKind.Local).AddTicks(2282) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryGroupId",
                table: "CategoryItems",
                column: "CategoryGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropTable(
                name: "DownloadQueues");

            migrationBuilder.DropTable(
                name: "FileTypeGroups");

            migrationBuilder.DropTable(
                name: "CategoryGroups");
        }
    }
}
