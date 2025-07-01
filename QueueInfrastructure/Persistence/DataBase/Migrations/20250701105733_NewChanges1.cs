using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueueInfrastructure.Persistence.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Customers_EmailAddres_PhoneNumber",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Customers_EmailAddres_PhoneNumber",
                table: "Customers",
                columns: new[] { "EmailAddres", "PhoneNumber" });
        }
    }
}
