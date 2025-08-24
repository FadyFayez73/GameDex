using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleColumnFromCompanyGameAsToCompositePK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyGames",
                table: "CompanyGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyGames",
                table: "CompanyGames",
                columns: new[] { "GameID", "CompanyID", "Role" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyGames",
                table: "CompanyGames");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyGames",
                table: "CompanyGames",
                columns: new[] { "GameID", "CompanyID" });
        }
    }
}
