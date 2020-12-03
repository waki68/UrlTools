using Microsoft.EntityFrameworkCore.Migrations;

namespace Shortener.DA.Migrations
{
    public partial class fixcomputedcolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TotalRedirectCount",
                schema: "Url",
                table: "Url",
                type: "bigint",
                nullable: false,
                computedColumnSql: "[Url].[udf_CalculateTotalRedirectCount]([Id])",
                oldClrType: typeof(long),
                oldType: "bigint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "TotalRedirectCount",
                schema: "Url",
                table: "Url",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComputedColumnSql: "[Url].[udf_CalculateTotalRedirectCount]([Id])");
        }
    }
}
