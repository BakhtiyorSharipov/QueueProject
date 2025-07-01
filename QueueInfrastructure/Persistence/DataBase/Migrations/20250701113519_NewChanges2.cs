using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueueInfrastructure.Persistence.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddres",
                table: "Customers",
                newName: "EmailAddress");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                table: "Customers",
                newName: "EmailAddres");
        }
    }
}
