using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.Auth.Data.Migrations
{
    /// <inheritdoc />
    public partial class inbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 970, DateTimeKind.Utc).AddTicks(8934),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(2328));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 970, DateTimeKind.Utc).AddTicks(7988),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(1062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 965, DateTimeKind.Utc).AddTicks(5896),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 965, DateTimeKind.Utc).AddTicks(4745),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 959, DateTimeKind.Utc).AddTicks(4616),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 948, DateTimeKind.Utc).AddTicks(777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 959, DateTimeKind.Utc).AddTicks(3498),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 947, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 953, DateTimeKind.Utc).AddTicks(8776),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 939, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 953, DateTimeKind.Utc).AddTicks(4671),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 938, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 906, DateTimeKind.Utc).AddTicks(1128),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(9303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 905, DateTimeKind.Utc).AddTicks(7857),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(6163));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 895, DateTimeKind.Utc).AddTicks(5204),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 728, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 895, DateTimeKind.Utc).AddTicks(4393),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 727, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.CreateTable(
                name: "AuthInbox",
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
                    table.PrimaryKey("PK_AuthInbox", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuthInbox");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(2328),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 970, DateTimeKind.Utc).AddTicks(8934));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(1062),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 970, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(3991),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 965, DateTimeKind.Utc).AddTicks(5896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(1346),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 965, DateTimeKind.Utc).AddTicks(4745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 948, DateTimeKind.Utc).AddTicks(777),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 959, DateTimeKind.Utc).AddTicks(4616));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 947, DateTimeKind.Utc).AddTicks(9486),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 959, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 939, DateTimeKind.Utc).AddTicks(2507),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 953, DateTimeKind.Utc).AddTicks(8776));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 938, DateTimeKind.Utc).AddTicks(9155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 953, DateTimeKind.Utc).AddTicks(4671));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 906, DateTimeKind.Utc).AddTicks(1128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(6163),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 905, DateTimeKind.Utc).AddTicks(7857));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 728, DateTimeKind.Utc).AddTicks(1390),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 895, DateTimeKind.Utc).AddTicks(5204));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 727, DateTimeKind.Utc).AddTicks(8034),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 24, 46, 895, DateTimeKind.Utc).AddTicks(4393));
        }
    }
}
