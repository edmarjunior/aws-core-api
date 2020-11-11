using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Data.Migrations
{
    public partial class AddIndexUniqueInProviderEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Providers_Email",
                table: "Providers");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_Email",
                table: "Providers",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Providers_Email",
                table: "Providers");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Providers_Email",
                table: "Providers",
                column: "Email");
        }
    }
}
