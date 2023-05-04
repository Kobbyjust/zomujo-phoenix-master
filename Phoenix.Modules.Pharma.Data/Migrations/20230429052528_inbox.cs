using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.Pharma.Data.Migrations
{
    /// <inheritdoc />
    public partial class inbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "ProcessInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 433, DateTimeKind.Utc).AddTicks(223),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 475, DateTimeKind.Utc).AddTicks(2165));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "ProcessInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 432, DateTimeKind.Utc).AddTicks(9152),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 475, DateTimeKind.Utc).AddTicks(1202));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "PharmaPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 437, DateTimeKind.Utc).AddTicks(4143),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 480, DateTimeKind.Utc).AddTicks(1024));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "PharmaPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 437, DateTimeKind.Utc).AddTicks(3201),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 480, DateTimeKind.Utc).AddTicks(147));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "PharmaNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 416, DateTimeKind.Utc).AddTicks(7788),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 457, DateTimeKind.Utc).AddTicks(3480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "PharmaNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 416, DateTimeKind.Utc).AddTicks(6922),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 457, DateTimeKind.Utc).AddTicks(2572));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "PharmaIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 412, DateTimeKind.Utc).AddTicks(6676),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 453, DateTimeKind.Utc).AddTicks(3738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "PharmaIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 412, DateTimeKind.Utc).AddTicks(5863),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 453, DateTimeKind.Utc).AddTicks(2914));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 428, DateTimeKind.Utc).AddTicks(1459),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 470, DateTimeKind.Utc).AddTicks(2928));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 428, DateTimeKind.Utc).AddTicks(383),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 470, DateTimeKind.Utc).AddTicks(1841));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Drugs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 405, DateTimeKind.Utc).AddTicks(3012),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 445, DateTimeKind.Utc).AddTicks(7975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Drugs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 405, DateTimeKind.Utc).AddTicks(2097),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 445, DateTimeKind.Utc).AddTicks(6417));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DispatchInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 422, DateTimeKind.Utc).AddTicks(4656),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 464, DateTimeKind.Utc).AddTicks(6302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DispatchInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 422, DateTimeKind.Utc).AddTicks(3699),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 464, DateTimeKind.Utc).AddTicks(5336));

            migrationBuilder.CreateTable(
                name: "PharmaInbox",
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
                    table.PrimaryKey("PK_PharmaInbox", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PharmaInbox");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "ProcessInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 475, DateTimeKind.Utc).AddTicks(2165),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 433, DateTimeKind.Utc).AddTicks(223));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "ProcessInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 475, DateTimeKind.Utc).AddTicks(1202),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 432, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "PharmaPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 480, DateTimeKind.Utc).AddTicks(1024),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 437, DateTimeKind.Utc).AddTicks(4143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "PharmaPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 480, DateTimeKind.Utc).AddTicks(147),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 437, DateTimeKind.Utc).AddTicks(3201));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "PharmaNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 457, DateTimeKind.Utc).AddTicks(3480),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 416, DateTimeKind.Utc).AddTicks(7788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "PharmaNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 457, DateTimeKind.Utc).AddTicks(2572),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 416, DateTimeKind.Utc).AddTicks(6922));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "PharmaIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 453, DateTimeKind.Utc).AddTicks(3738),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 412, DateTimeKind.Utc).AddTicks(6676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "PharmaIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 453, DateTimeKind.Utc).AddTicks(2914),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 412, DateTimeKind.Utc).AddTicks(5863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 470, DateTimeKind.Utc).AddTicks(2928),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 428, DateTimeKind.Utc).AddTicks(1459));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Orders",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 470, DateTimeKind.Utc).AddTicks(1841),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 428, DateTimeKind.Utc).AddTicks(383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Drugs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 445, DateTimeKind.Utc).AddTicks(7975),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 405, DateTimeKind.Utc).AddTicks(3012));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Drugs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 445, DateTimeKind.Utc).AddTicks(6417),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 405, DateTimeKind.Utc).AddTicks(2097));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DispatchInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 464, DateTimeKind.Utc).AddTicks(6302),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 422, DateTimeKind.Utc).AddTicks(4656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DispatchInfos",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 16, 36, 51, 464, DateTimeKind.Utc).AddTicks(5336),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 25, 28, 422, DateTimeKind.Utc).AddTicks(3699));
        }
    }
}
