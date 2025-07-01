using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueueInfrastructure.Persistence.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class NewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Employees_EmailAddress_PhoneNumber",
                table: "Employees");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Companies_EmailAddress_PhoneNumber",
                table: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_BlockedCustomers_CustomerEntityId",
                table: "BlockedCustomers");

            migrationBuilder.DropColumn(
                name: "BlockedCustomerEntityId",
                table: "Customers");

            migrationBuilder.CreateIndex(
                name: "IX_BlockedCustomers_CustomerEntityId",
                table: "BlockedCustomers",
                column: "CustomerEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_BlockedCustomers_CustomerEntityId",
                table: "BlockedCustomers");

            migrationBuilder.AddColumn<int>(
                name: "BlockedCustomerEntityId",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Employees_EmailAddress_PhoneNumber",
                table: "Employees",
                columns: new[] { "EmailAddress", "PhoneNumber" });

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Companies_EmailAddress_PhoneNumber",
                table: "Companies",
                columns: new[] { "EmailAddress", "PhoneNumber" });

            migrationBuilder.CreateIndex(
                name: "IX_BlockedCustomers_CustomerEntityId",
                table: "BlockedCustomers",
                column: "CustomerEntityId",
                unique: true);
        }
    }
}
