using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortener.DA.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Url");

            migrationBuilder.CreateTable(
                name: "Url",
                schema: "Url",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReqUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalRedirectCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Url", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShortCode",
                schema: "Url",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrlId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReqDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RedirectCount = table.Column<long>(type: "bigint", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShortCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShortCode_Url_UrlId",
                        column: x => x.UrlId,
                        principalSchema: "Url",
                        principalTable: "Url",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShortCode_Code",
                schema: "Url",
                table: "ShortCode",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShortCode_UrlId",
                schema: "Url",
                table: "ShortCode",
                column: "UrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShortCode",
                schema: "Url");

            migrationBuilder.DropTable(
                name: "Url",
                schema: "Url");
        }
    }
}
