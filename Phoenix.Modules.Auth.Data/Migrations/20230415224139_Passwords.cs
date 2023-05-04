using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.Auth.Data.Migrations
{
    /// <inheritdoc />
    public partial class Passwords : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Courier");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Counsellors");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Admins");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(2328),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(8035));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(1062),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(6642));

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Users",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Users",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(3991),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 873, DateTimeKind.Utc).AddTicks(1353));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(1346),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 872, DateTimeKind.Utc).AddTicks(7722));

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Pharmacies",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Pharmacies",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 948, DateTimeKind.Utc).AddTicks(777),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 864, DateTimeKind.Utc).AddTicks(1570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 947, DateTimeKind.Utc).AddTicks(9486),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 863, DateTimeKind.Utc).AddTicks(9524));

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Doctors",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Doctors",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 939, DateTimeKind.Utc).AddTicks(2507),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(3437));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 938, DateTimeKind.Utc).AddTicks(9155),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(694));

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Courier",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Courier",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(9303),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(6694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(6163),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(4553));

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Counsellors",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Counsellors",
                type: "bytea",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 728, DateTimeKind.Utc).AddTicks(1390),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(5285));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 727, DateTimeKind.Utc).AddTicks(8034),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(4320));

            migrationBuilder.AddColumn<byte[]>(
                name: "Password",
                table: "Admins",
                type: "bytea",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordKey",
                table: "Admins",
                type: "bytea",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Pharmacies");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Courier");

            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Courier");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Counsellors");

            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Counsellors");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Admins");

            migrationBuilder.DropColumn(
                name: "PasswordKey",
                table: "Admins");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(8035),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(2328));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 884, DateTimeKind.Utc).AddTicks(6642),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 965, DateTimeKind.Utc).AddTicks(1062));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 873, DateTimeKind.Utc).AddTicks(1353),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(3991));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Pharmacies",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 872, DateTimeKind.Utc).AddTicks(7722),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 956, DateTimeKind.Utc).AddTicks(1346));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Pharmacies",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 864, DateTimeKind.Utc).AddTicks(1570),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 948, DateTimeKind.Utc).AddTicks(777));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Doctors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 863, DateTimeKind.Utc).AddTicks(9524),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 947, DateTimeKind.Utc).AddTicks(9486));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Doctors",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(3437),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 939, DateTimeKind.Utc).AddTicks(2507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Courier",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 856, DateTimeKind.Utc).AddTicks(694),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 938, DateTimeKind.Utc).AddTicks(9155));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Courier",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(6694),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(9303));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Counsellors",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 840, DateTimeKind.Utc).AddTicks(4553),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 920, DateTimeKind.Utc).AddTicks(6163));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Counsellors",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(5285),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 728, DateTimeKind.Utc).AddTicks(1390));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Admins",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 14, 22, 43, 47, 825, DateTimeKind.Utc).AddTicks(4320),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 41, 38, 727, DateTimeKind.Utc).AddTicks(8034));

            migrationBuilder.AddColumn<string>(
                name: "PasswordHash",
                table: "Admins",
                type: "text",
                nullable: true);
        }
    }
}
