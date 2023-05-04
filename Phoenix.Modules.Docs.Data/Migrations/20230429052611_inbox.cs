using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Phoenix.Modules.Docs.Data.Migrations
{
    /// <inheritdoc />
    public partial class inbox : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Sessions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 612, DateTimeKind.Utc).AddTicks(2185),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 663, DateTimeKind.Utc).AddTicks(1418));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Sessions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 612, DateTimeKind.Utc).AddTicks(679),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 663, DateTimeKind.Utc).AddTicks(317));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "SessionMedium",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 622, DateTimeKind.Utc).AddTicks(4419),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 675, DateTimeKind.Utc).AddTicks(4729));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "SessionMedium",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 622, DateTimeKind.Utc).AddTicks(2323),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 675, DateTimeKind.Utc).AddTicks(3222));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 602, DateTimeKind.Utc).AddTicks(2271),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 652, DateTimeKind.Utc).AddTicks(4382));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 602, DateTimeKind.Utc).AddTicks(525),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 652, DateTimeKind.Utc).AddTicks(3269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "ServiceCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 592, DateTimeKind.Utc).AddTicks(8422),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 642, DateTimeKind.Utc).AddTicks(59));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "ServiceCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 592, DateTimeKind.Utc).AddTicks(6594),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 641, DateTimeKind.Utc).AddTicks(8720));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 581, DateTimeKind.Utc).AddTicks(1469),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 632, DateTimeKind.Utc).AddTicks(1508));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 580, DateTimeKind.Utc).AddTicks(9913),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 632, DateTimeKind.Utc).AddTicks(275));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Questions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 557, DateTimeKind.Utc).AddTicks(2568),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 611, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Questions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 557, DateTimeKind.Utc).AddTicks(387),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 610, DateTimeKind.Utc).AddTicks(9901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Questionnaires",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 571, DateTimeKind.Utc).AddTicks(1535),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 622, DateTimeKind.Utc).AddTicks(7377));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Questionnaires",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 570, DateTimeKind.Utc).AddTicks(9874),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 622, DateTimeKind.Utc).AddTicks(6178));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Prescriptions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 477, DateTimeKind.Utc).AddTicks(116),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 537, DateTimeKind.Utc).AddTicks(3138));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Prescriptions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 476, DateTimeKind.Utc).AddTicks(8332),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 537, DateTimeKind.Utc).AddTicks(2162));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Options",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 519, DateTimeKind.Utc).AddTicks(9437),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 596, DateTimeKind.Utc).AddTicks(3985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Options",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 519, DateTimeKind.Utc).AddTicks(8511),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 596, DateTimeKind.Utc).AddTicks(2656));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Faqs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 509, DateTimeKind.Utc).AddTicks(1680),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 583, DateTimeKind.Utc).AddTicks(6532));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Faqs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 509, DateTimeKind.Utc).AddTicks(496),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 583, DateTimeKind.Utc).AddTicks(3570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DocsPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 463, DateTimeKind.Utc).AddTicks(1163),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 528, DateTimeKind.Utc).AddTicks(2667));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DocsPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 462, DateTimeKind.Utc).AddTicks(9600),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 528, DateTimeKind.Utc).AddTicks(1731));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DocsNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 453, DateTimeKind.Utc).AddTicks(3620),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 520, DateTimeKind.Utc).AddTicks(6266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DocsNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 453, DateTimeKind.Utc).AddTicks(1952),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 520, DateTimeKind.Utc).AddTicks(5276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DocsIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 444, DateTimeKind.Utc).AddTicks(9148),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 513, DateTimeKind.Utc).AddTicks(2753));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DocsIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 444, DateTimeKind.Utc).AddTicks(7608),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 513, DateTimeKind.Utc).AddTicks(1185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 424, DateTimeKind.Utc).AddTicks(5708),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 496, DateTimeKind.Utc).AddTicks(8481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 424, DateTimeKind.Utc).AddTicks(3319),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 496, DateTimeKind.Utc).AddTicks(5048));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Answers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 495, DateTimeKind.Utc).AddTicks(8560),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 564, DateTimeKind.Utc).AddTicks(9018));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Answers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 495, DateTimeKind.Utc).AddTicks(5053),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 564, DateTimeKind.Utc).AddTicks(2912));

            migrationBuilder.CreateTable(
                name: "DocsInbox",
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
                    table.PrimaryKey("PK_DocsInbox", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DocsInbox");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Sessions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 663, DateTimeKind.Utc).AddTicks(1418),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 612, DateTimeKind.Utc).AddTicks(2185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Sessions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 663, DateTimeKind.Utc).AddTicks(317),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 612, DateTimeKind.Utc).AddTicks(679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "SessionMedium",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 675, DateTimeKind.Utc).AddTicks(4729),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 622, DateTimeKind.Utc).AddTicks(4419));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "SessionMedium",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 675, DateTimeKind.Utc).AddTicks(3222),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 622, DateTimeKind.Utc).AddTicks(2323));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 652, DateTimeKind.Utc).AddTicks(4382),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 602, DateTimeKind.Utc).AddTicks(2271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Services",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 652, DateTimeKind.Utc).AddTicks(3269),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 602, DateTimeKind.Utc).AddTicks(525));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "ServiceCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 642, DateTimeKind.Utc).AddTicks(59),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 592, DateTimeKind.Utc).AddTicks(8422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "ServiceCategories",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 641, DateTimeKind.Utc).AddTicks(8720),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 592, DateTimeKind.Utc).AddTicks(6594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 632, DateTimeKind.Utc).AddTicks(1508),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 581, DateTimeKind.Utc).AddTicks(1469));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Reviews",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 632, DateTimeKind.Utc).AddTicks(275),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 580, DateTimeKind.Utc).AddTicks(9913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Questions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 611, DateTimeKind.Utc).AddTicks(1643),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 557, DateTimeKind.Utc).AddTicks(2568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Questions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 610, DateTimeKind.Utc).AddTicks(9901),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 557, DateTimeKind.Utc).AddTicks(387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Questionnaires",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 622, DateTimeKind.Utc).AddTicks(7377),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 571, DateTimeKind.Utc).AddTicks(1535));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Questionnaires",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 622, DateTimeKind.Utc).AddTicks(6178),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 570, DateTimeKind.Utc).AddTicks(9874));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Prescriptions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 537, DateTimeKind.Utc).AddTicks(3138),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 477, DateTimeKind.Utc).AddTicks(116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Prescriptions",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 537, DateTimeKind.Utc).AddTicks(2162),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 476, DateTimeKind.Utc).AddTicks(8332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Options",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 596, DateTimeKind.Utc).AddTicks(3985),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 519, DateTimeKind.Utc).AddTicks(9437));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Options",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 596, DateTimeKind.Utc).AddTicks(2656),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 519, DateTimeKind.Utc).AddTicks(8511));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Faqs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 583, DateTimeKind.Utc).AddTicks(6532),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 509, DateTimeKind.Utc).AddTicks(1680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Faqs",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 583, DateTimeKind.Utc).AddTicks(3570),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 509, DateTimeKind.Utc).AddTicks(496));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DocsPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 528, DateTimeKind.Utc).AddTicks(2667),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 463, DateTimeKind.Utc).AddTicks(1163));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DocsPayments",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 528, DateTimeKind.Utc).AddTicks(1731),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 462, DateTimeKind.Utc).AddTicks(9600));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DocsNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 520, DateTimeKind.Utc).AddTicks(6266),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 453, DateTimeKind.Utc).AddTicks(3620));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DocsNotifications",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 520, DateTimeKind.Utc).AddTicks(5276),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 453, DateTimeKind.Utc).AddTicks(1952));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "DocsIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 513, DateTimeKind.Utc).AddTicks(2753),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 444, DateTimeKind.Utc).AddTicks(9148));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "DocsIssues",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 513, DateTimeKind.Utc).AddTicks(1185),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 444, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 496, DateTimeKind.Utc).AddTicks(8481),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 424, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Consultations",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 496, DateTimeKind.Utc).AddTicks(5048),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 424, DateTimeKind.Utc).AddTicks(3319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_UpdatedAt",
                table: "Answers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 564, DateTimeKind.Utc).AddTicks(9018),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 495, DateTimeKind.Utc).AddTicks(8560));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Audit_CreatedAt",
                table: "Answers",
                type: "timestamp with time zone",
                nullable: true,
                defaultValue: new DateTime(2023, 4, 15, 22, 40, 22, 564, DateTimeKind.Utc).AddTicks(2912),
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true,
                oldDefaultValue: new DateTime(2023, 4, 29, 5, 26, 10, 495, DateTimeKind.Utc).AddTicks(5053));
        }
    }
}
