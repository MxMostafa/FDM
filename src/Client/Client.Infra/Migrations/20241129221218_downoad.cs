using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Client.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class downoad : Migration
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

            migrationBuilder.CreateTable(
                name: "DownloadFiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DownloadQueueId = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    FileTypeGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    DownloadStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<long>(type: "INTEGER", nullable: false),
                    LocalSavePath = table.Column<string>(type: "TEXT", nullable: false),
                    DownloadPath = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadFiles_DownloadQueues_DownloadQueueId",
                        column: x => x.DownloadQueueId,
                        principalTable: "DownloadQueues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DownloadFiles_FileTypeGroups_FileTypeGroupId",
                        column: x => x.FileTypeGroupId,
                        principalTable: "FileTypeGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "DownloadQueues",
                columns: new[] { "Id", "Created", "IsDeleted", "Title", "Updated" },
                values: new object[] { 1, new DateTime(2024, 11, 30, 1, 42, 17, 627, DateTimeKind.Local).AddTicks(6020), false, "صف اصلی", new DateTime(2024, 11, 30, 1, 42, 17, 627, DateTimeKind.Local).AddTicks(6024) });

            migrationBuilder.InsertData(
                table: "FileTypeGroups",
                columns: new[] { "Id", "Created", "FileExtensions", "FolderName", "IconName", "IsDeleted", "SavePath", "Title", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 11, 30, 1, 42, 17, 624, DateTimeKind.Local).AddTicks(2489), "zip rar", "Compressed", null, false, "C:\\Users\\Sattec\\Downloads\\Compressed", "فایل های فشرده", new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(2430) },
                    { 2, new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(8364), "txt docx xls", "Documents", null, false, "C:\\Users\\Sattec\\Downloads\\Documents", "اسناد", new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(8367) },
                    { 3, new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(8913), "mp3 wave", "Music", null, false, "C:\\Users\\Sattec\\Downloads\\Music", "موسیقی", new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(8914) },
                    { 4, new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(9329), "exe msi", "Video", null, false, "C:\\Users\\Sattec\\Downloads\\Video", "برنامه ها", new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(9330) },
                    { 5, new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(9730), "mpeg 3gp avi flv", "Compressed", null, false, "C:\\Users\\Sattec\\Downloads\\Compressed", "تصویری", new DateTime(2024, 11, 30, 1, 42, 17, 626, DateTimeKind.Local).AddTicks(9731) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryGroupId",
                table: "CategoryItems",
                column: "CategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadFiles_DownloadQueueId",
                table: "DownloadFiles",
                column: "DownloadQueueId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadFiles_FileTypeGroupId",
                table: "DownloadFiles",
                column: "FileTypeGroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppSettings");

            migrationBuilder.DropTable(
                name: "CategoryItems");

            migrationBuilder.DropTable(
                name: "DownloadFiles");

            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.DropTable(
                name: "DownloadQueues");

            migrationBuilder.DropTable(
                name: "FileTypeGroups");
        }
    }
}
