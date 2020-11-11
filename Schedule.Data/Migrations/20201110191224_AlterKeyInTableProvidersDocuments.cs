using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Data.Migrations
{
    public partial class AlterKeyInTableProvidersDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProvidersDocuments_Name",
                table: "ProvidersDocuments");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProvidersDocuments_Name_ProviderId",
                table: "ProvidersDocuments",
                columns: new[] { "Name", "ProviderId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_ProvidersDocuments_Name_ProviderId",
                table: "ProvidersDocuments");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_ProvidersDocuments_Name",
                table: "ProvidersDocuments",
                column: "Name");
        }
    }
}
