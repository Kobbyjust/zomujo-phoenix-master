using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.MentalHealthTools.Data.Migrations
{
    /// <inheritdoc />
    public partial class inbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "UserQuoteFavorites",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 813, DateTimeKind.Utc).AddTicks(1548),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 764, DateTimeKind.Utc).AddTicks(645));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "UserQuoteFavorites",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 813, DateTimeKind.Utc).AddTicks(732),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 763, DateTimeKind.Utc).AddTicks(9805));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "SubCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 809, DateTimeKind.Utc).AddTicks(794),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 754, DateTimeKind.Utc).AddTicks(2787));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "SubCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 808, DateTimeKind.Utc).AddTicks(9990),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 753, DateTimeKind.Utc).AddTicks(9429));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Quotes",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 803, DateTimeKind.Utc).AddTicks(9425),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 735, DateTimeKind.Utc).AddTicks(4988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Quotes",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 803, DateTimeKind.Utc).AddTicks(8636),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 735, DateTimeKind.Utc).AddTicks(4166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 795, DateTimeKind.Utc).AddTicks(1039),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 722, DateTimeKind.Utc).AddTicks(5588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 795, DateTimeKind.Utc).AddTicks(407),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 722, DateTimeKind.Utc).AddTicks(4147));

            migrationBuilder.CreateTable(
                name: "MHToolsInbox",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    DateOccurred = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DateProcessed = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Error = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MHToolsInbox", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MHToolsInbox");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "UserQuoteFavorites",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 764, DateTimeKind.Utc).AddTicks(645),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 813, DateTimeKind.Utc).AddTicks(1548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "UserQuoteFavorites",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 763, DateTimeKind.Utc).AddTicks(9805),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 813, DateTimeKind.Utc).AddTicks(732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "SubCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 754, DateTimeKind.Utc).AddTicks(2787),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 809, DateTimeKind.Utc).AddTicks(794));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "SubCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 753, DateTimeKind.Utc).AddTicks(9429),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 808, DateTimeKind.Utc).AddTicks(9990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Quotes",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 735, DateTimeKind.Utc).AddTicks(4988),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 803, DateTimeKind.Utc).AddTicks(9425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Quotes",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 735, DateTimeKind.Utc).AddTicks(4166),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 803, DateTimeKind.Utc).AddTicks(8636));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 722, DateTimeKind.Utc).AddTicks(5588),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 795, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Categories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 4, 722, DateTimeKind.Utc).AddTicks(4147),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 27, 0, 795, DateTimeKind.Utc).AddTicks(407));
        }
    }
}
