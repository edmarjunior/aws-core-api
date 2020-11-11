using Microsoft.EntityFrameworkCore.Migrations;

namespace Schedule.Data.Migrations
{
    public partial class AddTableProvidersDocuments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProvidersDocuments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    ProviderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvidersDocuments", x => x.Id);
                    table.UniqueConstraint("AK_ProvidersDocuments_Name", x => x.Name);
                    table.ForeignKey(
                        name: "FK_ProvidersDocuments_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProvidersDocuments_ProviderId",
                table: "ProvidersDocuments",
                column: "ProviderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProvidersDocuments");
        }
    }
}
