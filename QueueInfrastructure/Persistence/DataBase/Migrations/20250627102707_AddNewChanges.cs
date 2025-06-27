using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QueueInfrastructure.Persistence.DataBase.Migrations
{
    /// <inheritdoc />
    public partial class AddNewChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedCustomers_Customers_CustomerId",
                table: "BlockedCustomers");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "QueueId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Queues");

            migrationBuilder.DropColumn(
                name: "ServiceId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "BlockedCustomers");

            migrationBuilder.RenameColumn(
                name: "BlockedCustomerId",
                table: "Customers",
                newName: "BlockedCustomerEntityId");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "BlockedCustomers",
                newName: "CustomerEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockedCustomers_CustomerId",
                table: "BlockedCustomers",
                newName: "IX_BlockedCustomers_CustomerEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedCustomers_Customers_CustomerEntityId",
                table: "BlockedCustomers",
                column: "CustomerEntityId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlockedCustomers_Customers_CustomerEntityId",
                table: "BlockedCustomers");

            migrationBuilder.RenameColumn(
                name: "BlockedCustomerEntityId",
                table: "Customers",
                newName: "BlockedCustomerId");

            migrationBuilder.RenameColumn(
                name: "CustomerEntityId",
                table: "BlockedCustomers",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_BlockedCustomers_CustomerEntityId",
                table: "BlockedCustomers",
                newName: "IX_BlockedCustomers_CustomerId");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Services",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QueueId",
                table: "Reviews",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Queues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeId",
                table: "Queues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Queues",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ServiceId",
                table: "Employees",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "BlockedCustomers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BlockedCustomers_Customers_CustomerId",
                table: "BlockedCustomers",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
