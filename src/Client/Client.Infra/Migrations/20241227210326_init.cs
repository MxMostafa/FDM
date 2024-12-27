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

            migrationBuilder.CreateTable(
                name: "DownloadFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DownloadQueueId = table.Column<int>(type: "INTEGER", nullable: false),
                    FileName = table.Column<string>(type: "TEXT", nullable: false),
                    FileTypeGroupId = table.Column<int>(type: "INTEGER", nullable: true),
                    DownloadStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Size = table.Column<long>(type: "INTEGER", nullable: false),
                    DownloadedBytes = table.Column<long>(type: "INTEGER", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "DownloadFileChunks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DownloadFileId = table.Column<long>(type: "INTEGER", nullable: false),
                    Size = table.Column<long>(type: "INTEGER", nullable: false),
                    Index = table.Column<int>(type: "INTEGER", nullable: false),
                    Start = table.Column<long>(type: "INTEGER", nullable: false),
                    End = table.Column<long>(type: "INTEGER", nullable: false),
                    TempFilePath = table.Column<string>(type: "TEXT", nullable: false),
                    DownloadFileChunkStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    Created = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Updated = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadFileChunks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadFileChunks_DownloadFiles_DownloadFileId",
                        column: x => x.DownloadFileId,
                        principalTable: "DownloadFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppSettings",
                columns: new[] { "Id", "AppSettingType", "Created", "Key", "Updated", "Value" },
                values: new object[] { 1, 0, new DateTime(2024, 12, 28, 0, 33, 25, 678, DateTimeKind.Local).AddTicks(1323), "TempSavePathTextbox", new DateTime(2024, 12, 28, 0, 33, 25, 678, DateTimeKind.Local).AddTicks(1327), "C:\\Users\\Sattec\\AppData\\Roaming\\FDM" });

            migrationBuilder.InsertData(
                table: "DownloadQueues",
                columns: new[] { "Id", "Created", "IsDeleted", "Title", "Updated" },
                values: new object[] { 1, new DateTime(2024, 12, 28, 0, 33, 25, 677, DateTimeKind.Local).AddTicks(3700), false, "صف اصلی", new DateTime(2024, 12, 28, 0, 33, 25, 677, DateTimeKind.Local).AddTicks(3704) });

            migrationBuilder.InsertData(
                table: "FileTypeGroups",
                columns: new[] { "Id", "Created", "FileExtensions", "FolderName", "IconName", "IsDeleted", "SavePath", "Title", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 28, 0, 33, 25, 674, DateTimeKind.Local).AddTicks(92), "zip rar", "Compressed", null, false, "C:\\Users\\Sattec\\Downloads\\Compressed", "فایل های فشرده", new DateTime(2024, 12, 28, 0, 33, 25, 675, DateTimeKind.Local).AddTicks(9433) },
                    { 2, new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(5644), "txt docx xls", "Documents", null, false, "C:\\Users\\Sattec\\Downloads\\Documents", "اسناد", new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(5647) },
                    { 3, new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(6149), "mp3 wave", "Music", null, false, "C:\\Users\\Sattec\\Downloads\\Music", "موسیقی", new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(6150) },
                    { 4, new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(6575), "exe msi", "Video", null, false, "C:\\Users\\Sattec\\Downloads\\Video", "برنامه ها", new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(6576) },
                    { 5, new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(6977), "mpeg 3gp avi flv", "Compressed", null, false, "C:\\Users\\Sattec\\Downloads\\Compressed", "تصویری", new DateTime(2024, 12, 28, 0, 33, 25, 676, DateTimeKind.Local).AddTicks(6978) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItems_CategoryGroupId",
                table: "CategoryItems",
                column: "CategoryGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DownloadFileChunks_DownloadFileId",
                table: "DownloadFileChunks",
                column: "DownloadFileId");

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
                name: "DownloadFileChunks");

            migrationBuilder.DropTable(
                name: "CategoryGroups");

            migrationBuilder.DropTable(
                name: "DownloadFiles");

            migrationBuilder.DropTable(
                name: "DownloadQueues");

            migrationBuilder.DropTable(
                name: "FileTypeGroups");
        }
    }
}
