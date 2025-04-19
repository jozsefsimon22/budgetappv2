using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BudgetAppV2.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FinancialTransactions",
                columns: new[] { "Id", "CurrentAmount", "EndDate", "IsRecurring", "Name", "StartDate", "TransactionFrequency", "TransactionType" },
                values: new object[,]
                {
                    { new Guid("0993573a-9d10-46d2-887a-5e29b3b32308"), 150.0, new DateOnly(2024, 5, 20), false, "Concert Tickets", new DateOnly(2024, 5, 20), 3, 1 },
                    { new Guid("6ea81ae4-3bf4-4099-b844-72348a47bb0b"), 1200.0, new DateOnly(2024, 2, 10), false, "New Laptop", new DateOnly(2024, 2, 10), 3, 1 },
                    { new Guid("73489b93-b090-4746-bbcc-b99c729f36ab"), 25.0, null, true, "Gym Membership", new DateOnly(2023, 3, 1), 1, 1 },
                    { new Guid("b1501478-fdba-49aa-8599-e23cdd8ad3b1"), 15.99, null, true, "Netflix Subscription", new DateOnly(2023, 1, 1), 1, 1 },
                    { new Guid("c02ee91f-7c3a-42c6-ba14-7a2df4934a3d"), 2500.0, null, true, "Salary", new DateOnly(2022, 6, 15), 1, 0 },
                    { new Guid("e36e7193-fd9d-4b53-929b-46dd90dc7317"), 800.0, null, false, "Freelance Project", new DateOnly(2024, 1, 15), 3, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinancialTransactions",
                keyColumn: "Id",
                keyValue: new Guid("0993573a-9d10-46d2-887a-5e29b3b32308"));

            migrationBuilder.DeleteData(
                table: "FinancialTransactions",
                keyColumn: "Id",
                keyValue: new Guid("6ea81ae4-3bf4-4099-b844-72348a47bb0b"));

            migrationBuilder.DeleteData(
                table: "FinancialTransactions",
                keyColumn: "Id",
                keyValue: new Guid("73489b93-b090-4746-bbcc-b99c729f36ab"));

            migrationBuilder.DeleteData(
                table: "FinancialTransactions",
                keyColumn: "Id",
                keyValue: new Guid("b1501478-fdba-49aa-8599-e23cdd8ad3b1"));

            migrationBuilder.DeleteData(
                table: "FinancialTransactions",
                keyColumn: "Id",
                keyValue: new Guid("c02ee91f-7c3a-42c6-ba14-7a2df4934a3d"));

            migrationBuilder.DeleteData(
                table: "FinancialTransactions",
                keyColumn: "Id",
                keyValue: new Guid("e36e7193-fd9d-4b53-929b-46dd90dc7317"));
        }
    }
}
